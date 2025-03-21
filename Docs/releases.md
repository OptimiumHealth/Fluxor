# Releases

## New in 6.7
* Fix StoreInitialize error ([#535](https://github.com/mrpmorris/Fluxor/issues/535))

## New in 6.6
* Allow DependencyInjection >=8 < 10 for .net 8 ([#530](https://github.com/mrpmorris/Fluxor/issues/530))

## New in 6.5.2
 * False positive FLXW01 error fixed ([#522](https://github.com/mrpmorris/Fluxor/issues/522))

## New in 6.5
 * Support subscribing to fields instead of properties ([#514](https://github.com/mrpmorris/Fluxor/issues/514))

## New in 6.4
 * Optimise Roslyn analyzer
 * Use Microsoft.CodeAnalysis.CSharp instead of Microsoft.CodeAnalysis.CSharp.Workspaces

## New in 6.3
 * Downgrade Microsoft.CodeAnalysis.CSharp.Workspaces to 4.9.2 (.NET 8 version). ([#519](https://github.com/mrpmorris/Fluxor/issues/519))

## New in 6.2.1
 * Analyzer to ensure base.OnInitialized or base.OnInitializedAsync is called in Blazor apps.

## New in 6.2
 * Support only .NET 8 and 9.

## New in 6.1
* Allow relative URLs in routing middleware ([#497](https://github.com/mrpmorris/Fluxor/issues/497))
* Support JsonOptions and double.Nan serialization in Redux Dev Tools ([#503](https://github.com/mrpmorris/Fluxor/issues/503))

## New in 6.0
* **Breaking change**: Remove support for obsolete versions of .NET framework ([#384](https://github.com/mrpmorris/Fluxor/issues/384))
* **Breaking change**: Replace IDisposable with IAsyncDisposable in Blazor components ([#324](https://github.com/mrpmorris/Fluxor/issues/324))
* **Breaking change**: `UseReduxDevTools` no longer ensures `UseRouting` is called ([#360](https://github.com/mrpmorris/Fluxor/issues/360))
* **Breaking change**: `UseReduxDevTools` no longer requires `Newtonsoft.Json` ([#386](https://github.com/mrpmorris/Fluxor/issues/386))
* Support Action Filtering in Redux Dev Tools ([#383](https://github.com/mrpmorris/Fluxor/issues/383))
* Do not consider anchor (Uri.Fragment) when checking Uri for changes in routing middleware ([#455](https://github.com/mrpmorris/Fluxor/issues/455))
* Resolve bug where StoreInitializer could cause DisposableCallback to throw an exception ([#491](https://github.com/mrpmorris/Fluxor/issues/491))

## New in 5.9
* Adds additional useful information to exception thrown by `DisposableAction` ([#425](https://github.com/mrpmorris/Fluxor/issues/425))
* Fix deadlock scenario when dispatching actions from an effect triggered by store activation ([#426](https://github.com/mrpmorris/Fluxor/issues/426))

## New in 5.8
* Fixes potential for deadlock ([#407](https://github.com/mrpmorris/Fluxor/issues/407))## New in 5.7
* Fixes memory leak when using `ActionSubscriber` or `SubscribeToAction` ([#378](https://github.com/mrpmorris/Fluxor/issues/378))

## New in 5.6
* Support .NET 7
* Ensure StateSelection unsubscribes properly ([#353](https://github.com/mrpmorris/Fluxor/issues/353))

## New in 5.5
 * `DisposableCallback` includes Caller info when throwing an exception ([#320](https://github.com/mrpmorris/Fluxor/issues/320))
 * Ensured initialising the store does not overwrite manually set state ([#347](https://github.com/mrpmorris/Fluxor/issues/347))

## New in 5.4
 * ActionSubscribers are now notified after state has been reduced ([#299](https://github.com/mrpmorris/Fluxor/issues/299))
 * Routing middleware will no longer dispatch a GoAction when URl is the same value but formatted differently ([#297](https://github.com/mrpmorris/Fluxor/issues/297))
 * `IDispatcher` now queues actions whenever there are no subscribers to the `ActionDispatched` event and then
   dequeues them when a subscriber is added ([#301](https://github.com/mrpmorris/Fluxor/issues/301))

## New in 5.3
 * New method EnableStackTrace on ReduxDevToolsMiddlewareOptions to enable passing stack trace to the browser plugin ([#262](https://github.com/mrpmorris/Fluxor/issues/262))
 * ActionSubscriber demo
 * Add LifeCycle to FluxorOptions and use in registration ([#287](https://github.com/mrpmorris/Fluxor/issues/287))

## New in 5.2
 * Added Stack Trace option for Redux Dev Tools ([#262](https://github.com/mrpmorris/Fluxor/issues/262))

## New in 5.1
 * Fixed `IStateSelection<TState, TValue>` bug that threw exception stating the selector has
    already been set. ([#252](https://github.com/mrpmorris/Fluxor/issues/252))
 * Added an optional `Action<TValue> selectedValueChanged` to `IStateSelection<TState, TValue>.Select`
    that is executed whenever the selected value changes. This is a convenient alternative to hooking up event handlers.
 * Added `event EventHandler<TValue> SelectedValueChanged` to `IStateSelection<TState, TValue>` for strongly
    typed event args when the selected value changes.
 * Changed to avoid .net memory leak in dependency injection ([#271](https://github.com/mrpmorris/Fluxor/issues/271))

## New in 5.0
 * **Breaking change**: Removed need to reference `_content/Fluxor.Blazor.Web/scripts/index.js` ([#235](https://github.com/mrpmorris/Fluxor/issues/235))
 * **Breaking change**: Removed `IState<TState>` generic `StateChanged` event.
 * Separated `IDispatcher` out of `IStore`. ([#209](https://github.com/mrpmorris/Fluxor/issues/209))
 * Added `IState<TState>` alternative `IStateSelector<TState, TValue>` for selecting and subscribing to subsets of state. ([#221](https://github.com/mrpmorris/Fluxor/issues/221))
 * Made actions that are a generic type human readable in ReduxDevTools. ([#205](https://github.com/mrpmorris/Fluxor/issues/205))

## New in 4.2.1
 * Support .NET 6

## New in 4.2
 * New `[FeatureState]` attribute to avoid having to create `Feature<T>` descendant classes. ([#204](https://github.com/mrpmorris/Fluxor/issues/204))
 * Add `FluxorOptions.ScanTypes` to allow scanning of specified classes. ([#214](https://github.com/mrpmorris/Fluxor/issues/214))
 * Make `FluxorComponent` and `FluxorLayout` abstract. ([#217](https://github.com/mrpmorris/Fluxor/issues/217))
 * Add `ForceLoad` property to `GoAction`. ([#178](https://github.com/mrpmorris/Fluxor/issues/178))
 * Only call `Dispose(bool disposing)` if not already disposed. ([#222](https://github.com/mrpmorris/Fluxor/issues/222))

## New in 4.1
 * Allow custom control over JSON serialisation in Redux Dev Tools - see 
   [Redux Dev Tools](../Tutorials/02-Blazor/02D-ReduxDevToolsTutorial/) docs.


## New in 4.0
 * Changed `Effect<T>.HandleAsync` from `protected` to `public` to make unit testing easier
 * Added `Options` to `.UseReduxDevTools()` middleware extension

## New in 3.9
 * Support added for .NET 5.0

## New in 3.8
 * Allow state notification throttling to reduce time spent rendering ([#114](https://github.com/mrpmorris/Fluxor/issues/114)) - see:
   *  `FluxorComponent.MaximumStateChangedNotificationsPerSecond`
   *  `FluxorLayout.MaximumStateChangedNotificationsPerSecond`
   *  `Feature.MaximumStateChangedNotificationsPerSecond`
 * Fix for ([#105](https://github.com/mrpmorris/Fluxor/issues/105)) - 
     Allow FluxorComponent descendents to dispatch actions when overriding `Dispose(bool)`.
 * Added an optional `actionType` to `[EffectMethod]` to avoid compiler warnings when the action is not used

```c#
public class SomeEffects
{
  [EffectMethod(typeof(RefreshDataAction))]
  public Task CallItWhateverYouLike(IDispatcher dispatcher)
  {
    ... code here ...
  }

  // is equivalent to

  [EffectMethod]
  public Task CallItWhateverYouLike(RefreshDataAction unusedParameter, IDispatcher dispatcher)
  {
    ... code here ...
  }
}
```

 * Added an optional `actionType` to `[ReducerMethod]` to avoid compiler warnings when the action is not used

```c#
public class SomeReducers
{
  [ReducerMethod(typeof(IncrementCounterAction))]
  public MyState CallItWhateverYouLike(MyState state) =>
    new MyState(state.Count + 1);

  // is equivalent to

  [ReducerMethod]
  public MyState CallItWhateverYouLike(MyState state, IncrementCounterAction unusedParameter) =>
    new MyState(state.Count + 1);
}
```

 * Added support for declaring `[ReducerMethod]` on generic classes

```c#
public class TestIntReducer: AbstractGenericStateReducers<int>
{
}

public class TestStringReducer: AbstractGenericStateReducers<string>
{
}

public abstract class AbstractGenericStateReducers<T>
  where T : IEquatable<T>
{
  [ReducerMethod]
  public static TestState<T> ReduceRemoveItemAction(TestState<T> state, RemoveItemAction<T> action) =>
    new TestState<T>(state.Items.Where(x => !x.Equals(action.Item)).ToArray());
}
```

 * Added support for declaring `[EffectMethod]` on generic classes

```c#
public class GenericEffectClassForMyAction : AbstractGenericEffectClass<MyAction>
{
  public GenericEffectClassForMyAction(SomeService someService) : base(someService)
  {
  }
}

public class GenericEffectClassForAnotherAction : AbstractGenericEffectClass<AnotherAction>
{
  public GenericEffectClassForAnotherAction(SomeService someService) : base(someService)
  {
  }
}

public abstract class AbstractGenericEffectClass<T> 
{
  private readonly ISomeService SomeService;

  protected AbstractGenericEffectClass(ISomeService someService)
  {
    SomeService = someService;
  }

  [EffectMethod]
  public Task HandleTheActionAsync(T action, IDispatcher dispatcher)
  {
    return SomeService.DoSomethingAsync(action);
  }
}
```

## New in 3.7
 * Fix for ([#84](https://github.com/mrpmorris/Fluxor/issues/84) - 
   Allow observer to unsubscribe from all subscriptions whilst executing
   the callback from a previous subscription
 * Fix for ([#82](https://github.com/mrpmorris/Fluxor/issues/82)) -
   Throw an informative exception when `FluxorComponent` or `FluxorLayout`
   has been inherited and the descendant doesn't call `base.OnInitialized()`.
 * Fix for ([#77](https://github.com/mrpmorris/Fluxor/issues/87)) -
   Exception thrown initialising store in .NET 5.

## New in 3.6
 * Ensure synchronous effects are executed synchronously ([#76](https://github.com/mrpmorris/fluxor/issues/76)) -
   Reverts changes for [(#74) Endless loop redirects](https://github.com/mrpmorris/Fluxor/issues/74) as
   these are no longer occur.

## New in 3.5
 * Bug fix for ([#74](https://github.com/mrpmorris/Fluxor/issues/74)) - Handle endless loop redirects caused by Routing middleware.

## New in 3.4
 * **Breaking change**: `FluxorException` is now an `abstract` class.
 * Unhandled exceptions in Effects can now notify the UI.

## New in 3.3
 * **Breaking change**: `EffectMethod` and `ReducerMethod` decorated methods must now be public - although they can be methods of internal classes.
 * New `IActionSubscriber` to receive notifications before actions are reduced into state and before Effects are triggered
 * More speed improvements in `options.ScanAssemblies`
 * Subscriptions to the `StateChanged` event will now be triggered before FluxorComponent/FluxorLayout notified of changes (so manual subscriptions are executed before rendering)
 * Added link with more information for when `DisposableCallback` throws an error because it has not been disposed

## New in 3.2
 * Improved speed of app start-up when using `options.ScanAssemblies`
 * Assemblies are now signed
 * Set project options to treat all warnings as errors

## New in 3.1.1
 * Fixed bug that caused exception when using `.ConfigureAwait` in an Effect ([#20](https://github.com/mrpmorris/Fluxor/issues/20))
 * Ensured add/remove on events are thread safe ([#23](https://github.com/mrpmorris/Fluxor/issues/23))
 * Made it easier to find the source of DisposableCallback instances that are not disposed ([#24](https://github.com/mrpmorris/Fluxor/issues/24))
 * State properties were not discovered if they were declared as private in a base class ([#25](https://github.com/mrpmorris/Fluxor/issues/25))
 * Handle disposing of partially created DisposableAction ([#29](https://github.com/mrpmorris/Fluxor/issues/29))

## New in 3.1.0
  * Used Newtonsoft entirely for JS interop to ReduxDevTools to prevent serialization errors ([#7](https://github.com/mrpmorris/Fluxor/issues/7))
  * Added new FluxorLayout for auto-subscribing to state ([#8](https://github.com/mrpmorris/Fluxor/issues/8))

## New in 3.0.2
  * Bug fix for ([#134](https://github.com/mrpmorris/blazor-fluxor/issues/134)) - URLs not taking into account query parameters
  * Update NuGet package icons.

## New in 3.0.0
  * Rewritten to make the library UI agnostic `Fluxor`
  * Separated out `Blazor.Fluxor` into `Fluxor.Blazor.Web`
  * Separated out `Fluxor.Blazor.Web.ReduxDevTools`
  * Added new documentation
  * Added basic-concepts tutorials demonstrating how to use Fluxor in a console app.

## Previous versions (Blazor-Fluxor)

### New in 2.0
  * Change `@Store.Initialize` to `<Blazor.Fluxor.StoreInitializer/>` component, to allow async calls (fixes #120)
 
**2.0 Release notes**

In your `App.razor` files replace the call to `@Store.Initialize` with `<Blazor.Fluxor.StoreInitializer/>`

### New in 1.4.1
  * Handle TaskCanceledException when initialising the store and server has disconnected from the client.
  * Updated to SDK 3.1.2

### New in 1.4.0
  * Made dispatching actions thread safe (#117)

### New in 1.3.2
  * Fixed bug #110 (Cannot use Redux Dev Tools on server side)
 
### New in 1.3.1
  * Fixed bug #98 (Cannot initialize store)

### New in 1.3.0
  * Upgraded to DotNet Core 3.1 preview 4

### New in 1.2.0
  * Prevent JavaScript initialisation from being executed twice.
  * Add `IState.Unsubscribe`

### New in 1.1.0
  * Change store initialization technique to make server-side Blazor apps work on iOS and OSX browsers.

**NOTE:** You must manually add a script reference to `_content/Blazor.Fluxor/index.js` to the host page in server-side apps.

### New in 1.0.0
  * Initialise store in App.razor instead of MainLayout.razor
  * First major release

### New in 0.35
  * Upgraded to DotNet Core 3

### New in 0.34
  * Work around for Blazor bug that stops injected scripts working in Safari.

### New in 0.33.1
  * Allow multiple reducers in a class (and static reducers) with `[ReducerMethod]`
  * Allow multiple effects in a class (and static effects) with `[EffectMethod]`
  * Removed `MultiActionReducer<TState>` due to new `ReducerMethodAttribute`

Issues fixed
  * https://github.com/mrpmorris/blazor-fluxor/issues/76

### New in 0.32.0
  * Update to Blazor RC1

### New in 0.31.0
  * Remove White=Positive / Black=Negative terms - Use Include/Exclude instead.
  * Update to Blazor preview 9

### New in 0.30.0
  * Added a new class `MultiActionReducer<TState>` that allows you to combine multiple reducers into a single class.

### New in 0.29.0
  * Fixed a harmless null reference error when running server-side
  * Fixed FlightFinder sample's UI and binding
  * TypeExtensions.GetNamespace extension method removed in favor of Type.Namespace
  * Fixed bug that caused an error when the project contained an abstract class that implements a Fluxor interface

### New in 0.28.0
  * Added a StateChanged event to IFeature&lt;T&gt; and IState&lt;T&gt;

### New in 0.27.0
  * Update to Blazor preview 8

### New in 0.26.0
  * Update to Blazor preview 7
  * Alter the icon that appears in NuGet

### New in 0.25.0
  * Remove IAction. Actions may now be any type of object.

### New in 0.24.0
**NOTE**: Due to a [bug in System.Text.Json](https://github.com/dotnet/corefx/issues/38435) the ReduxDevTools do not work in this release.
  * Upgraded to latest packages (.net core v3.0.0-preview6.19307.2)

### New in 0.23.0
  * Upgraded to latest packages (.net core v3.0.0-preview5-19227-01)

### New in 0.22.0
  * Upgraded to latest packages (.net core v3.0.0-preview4-19216-03)
  * Rename *.cshtml to *.razor
  * Change project start up code to reflect most recent approach

### New in 0.21.0
  * Upgraded to latest packages (.net core v3.0.0-preview3-19153-02)

### New in 0.20.0
  * Upgraded to Blazor 0.9.0

### New in 0.19.0
  * Upgraded to Blazor 0.8.0 (Thanks to [@chris_sainty](https://twitter.com/chris_sainty) on Twitter)

### New in 0.18.0
  * Changed UseDependencyInjection to use `AddScoped` instead of `AddSingleton` so server-side Blazor apps do not share the same store across clients.

### New in 0.17.0
  * Upgraded to Blazor 0.7.0

### New in 0.16.0
  * Upgraded to Blazor 0.6.0
  * Added a Task to IStore named `Initialized` that can be awaited in `OnInitializedAsync`

### New in 0.15.1
  * Added setTimeout workaround because Blazor won't allow calling StateHasChanged when the page loads

### New in 0.15.0
  * Queue dispatched actions until store is initialized and then dequeue them.
  * Made demos reference NuGet packages so they can be downloaded separately.

Issues fixed
  * https://github.com/mrpmorris/blazor-fluxor/issues/28

### New in 0.14.0
  * Upgraded to Blazor 0.5.1.
  * Effects and Middlewares must now call `IDispatcher.Dispatch()` to dispatch actions.

### New in 0.13.0
  * Added state change observer pattern. Calling `SomeInjectedState.Changed(this, StateHasChanged)` in a component's `OnInitialized` method will subscribe to all state changes triggered by other components.
  * Changed `IState.Current` to `IState.Value`
  * Modified the official Blazor `Flight Finder` demo to use Fluxor. Status is incomplete but functional.

### New in 0.12.1
  * Changed the way Effects and Reducers work so the developer has more flexibility in chosing what they react to (descendant classes, implemented interfaces, etc)

### New in 0.12.0
  * Added unit tests
  * Change versioning scheme to match the Blazor approach (increment minor version per release)
  * Make BrowserInterop an injected service
  * Ensure DisposableCallback can only be disposed once
  * Change Store.Features from IEnumerable&lt;IFeature&gt; to IReadonlyDictionary&lt;string, Feature&gt; for fast lookup and prevention of duplicate keys
  * Make Store.BeginInternalMiddlewareChange re-entrant
  * Fix NullReferenceException that could occur when Middleware returned null from IMiddleware.AfterDispatch

### New in 0.0.11
  * Allow middleware to return tasks to dispatch from IMiddleware.AfterDispatch
  * Make methods of `Feature<TState>` virtual.
  * Upgraded to Blazor 0.4.0

### New in 0.0.10
  * Introduced IDispatcher for dispatching actions from Blazor components so that the whole IStore isn't required.
  * Introduced IState for providing feature state to Blazor components so that the entire IFeature&lt;T&gt; doesn't need to be referenced.

### New in 0.0.9
  * Renamed `Handle` to `HandleAsync` in effects
  * Added source docs

### New in 0.0.8
  * Added an example showing how to create Middleware modules for Fluxor
  * Fixed a bug where components were not displaying state updates when actions effecting their state were dispatched from another component

### New in 0.0.7
  * Renamed IStoreMiddleware to IMiddleware
  * Allow middleware to veto the dispatching of actions
  * Allow middleware to declare Javascript it needs to be added into the site's html page
  * Add routing middleware
  * Exclude auto-discovery of features / reducers / effects in namespaces that contain a class that implements IMiddleware
  * Auto register features / reducers / effects for classes in the same namespace (or below) of any class added with Options.AddMiddleware

### New in 0.0.6
  * Changed the signature of IStore.Dispatch to IStore.DispatchAsync
  * Upgraded to latest version of Blazor (0.3.0)

### New in 0.0.5
  * Changed the signature of ServiceCollection.AddFluxor to pass in an Options object
  * Added support for Redux Dev Tools
  * Added support for adding custom Middleware

### New in 0.0.4
  * Changed side-effects to return an array of actions to dispatch rather than limiting it to a single action

### New in 0.0.3
  * Added side-effects for calling out to async routines such as HTTP requests
  * Added a sample application to the [Sample projects][8]

### New in 0.0.2
  * Automatic discovery of store, features, and reducers via dependency injection.

### New in 0.0.1
  * Basic store / feature / reducer implementation
