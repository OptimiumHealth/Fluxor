﻿using Fluxor.Blazor.Web.ReduxDevTools.Internal.CallbackObjects;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fluxor.Blazor.Web.ReduxDevTools.Internal;

public interface IReduxDevToolsInterop
{
	bool DevToolsBrowserPluginDetected { get; }
	Func<JumpToStateCallback, Task> OnJumpToState { get; set; }
	Func<Task> OnCommit { get; set; }
	ValueTask InitializeAsync(IDictionary<string, object> state);
	Task<object> DispatchAsync(
		object action,
		IDictionary<string, object> state,
		string stackTrace);
	Task DevToolsCallback(string messageAsJson);
}

/// <summary>
/// Interop for dev tools
/// </summary>
internal sealed class ReduxDevToolsInterop : IDisposable, IReduxDevToolsInterop
{
	public const string DevToolsCallbackId = "DevToolsCallback";
	public bool DevToolsBrowserPluginDetected { get; private set; }
	public Func<JumpToStateCallback, Task> OnJumpToState { get; set; }
	public Func<Task> OnCommit { get; set; }

	private const string FluxorDevToolsId = "__FluxorDevTools__";
	private const string FromJsDevToolsDetectedActionTypeName = "detected";
	private const string ToJsDispatchMethodName = "dispatch";
	private const string ToJsInitMethodName = "init";
	private bool Disposed;
	private bool IsInitializing;
	private readonly IJSRuntime JSRuntime;
	private readonly DotNetObjectReference<ReduxDevToolsInterop> DotNetRef;
	private readonly ReduxDevToolsMiddlewareOptions Options;

	/// <summary>
	/// Creates an instance of the dev tools interop
	/// </summary>
	/// <param name="jsRuntime"></param>
	public ReduxDevToolsInterop(IJSRuntime jsRuntime, ReduxDevToolsMiddlewareOptions options)
	{
		JSRuntime = jsRuntime;
		DotNetRef = DotNetObjectReference.Create(this);
		Options = options;
	}

	public async ValueTask InitializeAsync(IDictionary<string, object> state)
	{
		IsInitializing = true;
		try
		{
			await InvokeFluxorDevToolsMethodAsync<object>(ToJsInitMethodName, DotNetRef, state);
		}
		finally
		{
			IsInitializing = false;
		}
	}

	public async Task<object> DispatchAsync(
		object action,
		IDictionary<string, object> state,
		string stackTrace)
	=>
		await InvokeFluxorDevToolsMethodAsync<object>(
				ToJsDispatchMethodName,
				new ActionInfo(action), state, stackTrace)
			.ConfigureAwait(false);

	/// <summary>
	/// Called back from ReduxDevTools
	/// </summary>
	/// <param name="messageAsJson"></param>
	[JSInvokable(DevToolsCallbackId)]
	public async Task DevToolsCallback(string messageAsJson)
	{
		if (string.IsNullOrWhiteSpace(messageAsJson))
			return;

		var message = JsonSerializer.Deserialize<BaseCallbackObject>(
			json: messageAsJson,
			options: Options.JsonSerializerOptions);

		switch (message?.payload?.type)
		{
			case FromJsDevToolsDetectedActionTypeName:
				DevToolsBrowserPluginDetected = true;
				break;

			case "COMMIT":
				Func<Task> commit = OnCommit;
				if (commit is not null)
				{
					Task task = commit();
					if (task is not null)
						await task;
				}
				break;

			case "JUMP_TO_STATE":
			case "JUMP_TO_ACTION":
				Func<JumpToStateCallback, Task> jumpToState = OnJumpToState;
				if (jumpToState is not null)
				{
					var callbackInfo = JsonSerializer.Deserialize<JumpToStateCallback>(
						json: messageAsJson,
						options: Options.JsonSerializerOptions);

					Task task = jumpToState(callbackInfo);
					if (task is not null)
						await task;
				}
				break;
		}
	}

	void IDisposable.Dispose()
	{
		if (!Disposed)
		{
			DotNetRef.Dispose();
			Disposed = true;
		}
	}

	private static bool IsDotNetReferenceObject(object x) =>
		x is not null
		&& x.GetType().IsGenericType
		&& x.GetType().GetGenericTypeDefinition() == typeof(DotNetObjectReference<>);

	private ValueTask<TResult> InvokeFluxorDevToolsMethodAsync<TResult>(string identifier, params object[] args)
	{
		if (!DevToolsBrowserPluginDetected && !IsInitializing)
			return new ValueTask<TResult>(default(TResult));


		if (args is not null && args.Length > 0)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (!IsDotNetReferenceObject(args[i]))
					args[i] = JsonSerializer.Serialize(
						value: args[i],
						inputType: args[i]?.GetType() ?? typeof(object),
						options: Options.JsonSerializerOptions);
			}
		}

		string fullIdentifier = $"{FluxorDevToolsId}.{identifier}";
		return JSRuntime.InvokeAsync<TResult>(fullIdentifier, args);
	}

	internal static string GetClientScripts(ReduxDevToolsMiddlewareOptions options)
	{
		string optionsJson = BuildOptionsJson(options);

		return $@"
window.{FluxorDevToolsId} = new (function() {{
	const reduxDevTools = window.__REDUX_DEVTOOLS_EXTENSION__;
	this.{ToJsInitMethodName} = function() {{}};

	if (reduxDevTools !== undefined && reduxDevTools !== null) {{
		const fluxorDevTools = reduxDevTools.connect({{ {optionsJson} }});
		if (fluxorDevTools !== undefined && fluxorDevTools !== null) {{
			fluxorDevTools.subscribe((message) => {{ 
				if (window.fluxorDevToolsDotNetInterop) {{
					const messageAsJson = JSON.stringify(message);
					window.fluxorDevToolsDotNetInterop.invokeMethodAsync('{DevToolsCallbackId}', messageAsJson); 
				}}
			}});
		}}

		this.{ToJsInitMethodName} = function(dotNetCallbacks, state) {{
			window.fluxorDevToolsDotNetInterop = dotNetCallbacks;
			state = JSON.parse(state);
			fluxorDevTools.init(state);

			if (window.fluxorDevToolsDotNetInterop) {{
				// Notify Fluxor of the presence of the browser plugin
				const detectedMessage = {{
					payload: {{
						type: '{FromJsDevToolsDetectedActionTypeName}'
					}}
				}};
				const detectedMessageAsJson = JSON.stringify(detectedMessage);
				window.fluxorDevToolsDotNetInterop.invokeMethodAsync('{DevToolsCallbackId}', detectedMessageAsJson);
			}}
		}};

		this.{ToJsDispatchMethodName} = function(action, state, stackTrace) {{
			action = JSON.parse(action);
			state = JSON.parse(state);
			window.fluxorDevToolsDotNetInterop.stackTrace = stackTrace;
			fluxorDevTools.send(action, state);
		}};

	}}
}})();
";
	}

	private static string BuildOptionsJson(ReduxDevToolsMiddlewareOptions options)
	{
		var values = new List<string> {
			$"name:\"{options.Name}\"",
			$"maxAge:{options.MaximumHistoryLength}",
			$"latency:{options.Latency.TotalMilliseconds}"
		};
		if (options.StackTraceEnabled)
			values.Add("trace: function() { return JSON.parse(window.fluxorDevToolsDotNetInterop.stackTrace); }");
		return string.Join(",", values);
	}
}
