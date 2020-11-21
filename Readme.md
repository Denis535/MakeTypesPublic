# Overview
The package **MakeTypesPublic** is intended to disable access checks to non-public (private, internal) types and members.

# How to use it
You need just add metadata `IgnoreAccessChecks="true"` to `ProjectReference` or `PackageReference` items.
You can also set `IgnoreAccessChecks` property to true/false if you want to enable/disable it. By default it's enabled only for not design-time builds. So, Visual Studio will show errors but compiler and runtime will work.

# How it works
There are a few types of access checks:
- Compile-time access checks. You should compile with fake assemblies with public types and members (ideally reference-only assembly) to disable it.
The Roslyn has options to disable access checks but those options are internal.
To learn more see the following links:
[Link 1](https://www.strathweb.com/2018/10/no-internalvisibleto-no-problem-bypassing-c-visibility-rules-with-roslyn/), 
[Link 2](https://github.com/dotnet/roslyn/pull/20870), 
[Link 3](https://github.com/dotnet/roslyn/issues/47276).
- Run-time access checks. You should add `IgnoresAccessChecksToAttribute` assembly attributes to disable it.
- Design-time access checks. There is a problem here. 
You could feed Visual Studio the fake assemblies with public types. But this can lead to some problems. So I preferred just ignore those errors. 
Maybe there are other ways to suppress these errors? But I don't know them.
If you still want to feed Visual Studio the fake assemblies you can set `IgnoreAccessChecks` property to true. By default this property is true only for not design-time builds.