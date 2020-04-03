# Captain.Common
![version: 0.1](https://img.shields.io/badge/version-0.1-blue.svg)
![license: Public Domain/MIT](https://img.shields.io/badge/license-Public_Domain/MIT-brightgreen.svg)
> Shared library for [Captain](https://github.com/CaptainApp) extension developers

## What's this?
[Captain](https://github.com/CaptainApp) is an application for capturing the screen. This is a library that
implements common source code shared among the different application modules, including third-party extensions.

## Building from source
### Environment Requirements
- Windows 7 SP1 or newer (build only tested on latest Windows 10)
- [Visual Studio 2017](https://www.visualstudio.com/downloads/) or newer (Community edition is fine)  
  VS 2015 will most likely **not** work.

### Building
```
$ git clone https://github.com/CaptainApp/Captain.Common
$ cd Captain.Common
$ nuget restore
$ devenv Captain.Common.csproj /Build
```

## Adding Captain.Common to my project
You could just add a reference to the `Captain.Common.dll` file on the Captain application directory.
But we're not savages, we do NuGet:

```
PM> Install-Package Captain.Common
```

Or at least we will, once we reach a stable release. For the time being, you can hack it around by building from
source.

## Distributing your plugin
Just ship your assembly DLL and Captain will take care of the rest. Do not include a copy of the `Captain.Common`
assembly alongside yours, Captain will use the latest version and will try to remain backwards-compatible.

## Documentation
_None yet (:_

## Licensing
The following files are licensed under the MIT license and copyrighted by third-parties.
Refer to the
[`Source/Native/README.md`](https://github.com/CaptainApp/Captain.Common/tree/master/Source/Native/README.md)
file for further details on authoring, licensing and copyrights.
- `Gdi32/Gdi32.cs`
- `User32/POINT.cs`
- `User32/RECT.cs`
- `User32/User32.cs`
- `User32/WINDOWPOS.cs`

All other source files are released into the public domain unless otherwise stated.