![](https://img.shields.io/badge/Status-Preview%20.NET%2011-yellowgreen)

# A .NET library for working with the Azure Maps SDK in JavaScript interop scenarios.

## NOTE: This library is in preview and is not yet production-ready.

## Features
- Provides a set of .NET classes and methods to interact with the Azure Maps SDK in interop scenarios, focused on Blazor applications.
- Supports common Azure Maps functionalities such as map initialization, adding layers, and handling events.
- Designed to be easy to use and integrate into existing Blazor projects.
- Script is loaded as a lazy module, so you can use it without any additional setup in your Blazor application (other than Azure Maps SDK configuration).
- Supports multiple maps on the same page.
- Custom JavaScript interop can be added to extend the library's capabilities. 
  This is accomplished by creating your own JavaScript library and passing an Azure Map `IJSObjectReference` to your library;
  which can be obtained using the `IAzureMapsInterop` instance created by the `MapProvider` component. 
  See the `Sandbox.Azure.Maps` project for an example of how to do this.

## Azure Maps SDK
- See the [Azure Maps Documentation](https://docs.microsoft.com/en-us/azure/azure-maps/) on how to create an Azure Maps account. 
  Normally, authentication is done using an Azure Maps subscription key, which can be obtained from the Azure portal.
- See the [Configuration](Documents/Configuration.md) document for all supported authentication scenarios.

## [Quickstart](Documents/Quickstart.md)

## [Build Solution](Documents/BuildSolution.md)

## [Release Notes](Documents/ReleaseNotes.md)
