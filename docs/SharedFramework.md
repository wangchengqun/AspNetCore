ASP.NET Core Shared Framework
=============================

Guidance on on developing the ASP.NET Core shared framework (`Microsoft.AspNetCore.App`).

### What goes into the base framework?

The ASP.NET Core shared framework, Microsoft.AspNetCore.App, will contain assemblies that are fully developed, supported, and serviceable by Microsoft. You can think of this as constituting the ASP.NET Core *platform*. As such, all assemblies which are included in the shared framework are expected to meet specific requirements. Here are the principles we are using to guide our decisions about what is allowed in the 
shared framework.

* Breaking changes are highly discouraged. Therefore, 
  * If it's in, it must be broadly useful and expected to be supported for at least several years.
  * The API for all assemblies in shared framework MUST NOT make breaking changes in patch or minor releases.
* The complete closure of all assemblies must be in the shared framework, or must be in the "base framework", Microsoft.NETCore.App
* No 3rd party dependencies. All packages must be fully serviceable by Microsoft.
* Teams which own components in the shared framework must coordinate security fixes, patches, and updates with the .NET Core team.
* Code must be open-source and buildable using only open-source tools
* Usage
   * How much an API is used is an important metric, but not the only factor
   * API we believe is essential for central experiences in .NET Core should be in the shared framework
   * Examples of central experiences: MVC, Kestrel, Razor, SignalR
* New API can ship as out-of-band packages first, and move into the base framework later when it meets these standards