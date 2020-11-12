# Overview
The package ***MakeTypesPublic*** is intended to access non-public types and members.

# How to use it
Just add metadata `MakeTypesPublic="true"` to `ProjectReference` or `PackageReference` items.

# How it works
There are two types of access checks: compile-time and run-time.
- To disable compile-time access checks one should replace original assembly with new assembly with public types and members (Ideally reference-only assembly).
The Roslyn has options to disable access checks but those options are internal. 
To learn more see the following links: 
[Link 1]:https://www.strathweb.com/2018/10/no-internalvisibleto-no-problem-bypassing-c-visibility-rules-with-roslyn/, 
[Link 2]:https://github.com/dotnet/roslyn/pull/20870, 
[Link 3]:https://github.com/dotnet/roslyn/issues/47276.
- To disable run-time access checks one should just use `IgnoresAccessChecksToAttribute` attribute.
