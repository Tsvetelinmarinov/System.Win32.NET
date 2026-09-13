# System.Win32.NET

![License](https://img.shields.io/badge/license-Apache--2.0-blue)
![Target](https://img.shields.io/badge/.NET-10.0-512BD4)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey)

**System.Win32.NET** is a low-level .NET utility library that wraps common Win32 API calls and OS
primitives behind clean, static, high-level C# APIs. It covers bit manipulation, unmanaged memory
allocation, classic Windows message boxes, console/terminal I/O, cross-platform process launching,
opening the default web browser, and launching built-in Windows applications.

The library is built directly on top of the Win32 API (`kernel32.dll`, `user32.dll`) using
source-generated P/Invoke (`LibraryImport`), rather than higher-level BCL wrappers — making it a
good reference for low-level Windows interop in modern .NET.

- **Target Framework:** `net10.0`
- **Nullable reference types:** enabled
- **Implicit usings:** enabled
- **Unsafe blocks:** allowed (required for raw pointer P/Invoke signatures)
- **XML documentation:** generated on build
- **License:** Apache License 2.0
- **External dependencies:** none

## Table of Contents

- [Architecture](#architecture)
- [Installation](#installation)
- [Platform Support](#platform-support)
- [Modules](#modules)
  - [BitOperations](#bitoperations)
  - [GUI (MessageWindow)](#gui-messagewindow)
  - [Memory](#memory)
  - [ProcessLauncher](#processlauncher)
  - [Terminal](#terminal)
  - [Web (WebBrowser)](#web-webbrowser)
  - [WindowsAppsManager](#windowsappsmanager)
- [Building](#building)
- [License](#license)

## Architecture

Every module in the library follows the same layered design:

```
Public static API  →  Internal Core (interface + implementation)  →  Platform Abstraction Layer (PAL)  →  Interop Service (P/Invoke)
```

| Layer | Example | Responsibility |
|---|---|---|
| **Public API** | `System32.Terminal.Terminal` | The only public surface. Thin static wrapper, resolves a `Core` instance via a static constructor + factory. |
| **Internal Core** | `Terminal.Internal.ITerminalCore` / `TerminalCore` | Implements the public contract, applies OS guards where needed, and delegates to the PAL (or, for `WindowsAppsManager`, directly to `Process.Start`). Instantiated through a `*Factory` class. |
| **PAL** | `Interoperability.PlatformAbstractionLayer.TerminalPAL` | Validates input, checks the OS (`OperatingSystem.IsWindows()`, etc.), converts managed ↔ unmanaged types, and calls the interop service. This is where argument checks and exceptions live. |
| **Interop Service** | `Interoperability.InternalServices.Terminal_WIN32_InteropService` | Raw `[LibraryImport]` P/Invoke declarations for the underlying native functions (`kernel32.dll`, `user32.dll`, `libc`, etc.). |

Every Windows-only module (`GUI`, `Memory`, `Terminal`, `WindowsAppsManager`) consistently throws
`PlatformNotSupportedException` (using the shared `Errors.OnlyWin32` message) when called on a
non-Windows OS, checked via `OperatingSystem.IsWindows()` before any native call is made.

This separation means every public type is a stateless static facade, all P/Invoke declarations
are isolated and testable independently of the public API, and swapping the underlying
implementation (e.g. per OS) only requires changing the factory/PAL layer.

A ready-to-use compiled DLL and its XML documentation are also included under
`Compiled ready-to-use DLL/` for consumers who don't want to build from source.

## Installation

No NuGet package is published. To use the library:

1. Clone or download the repository.
2. Reference `System.Win32.NET.csproj` from your solution, **or**
3. Reference the prebuilt binary directly:

```xml
<ItemGroup>
  <Reference Include="System.Win32.NET">
    <HintPath>path\to\Compiled ready-to-use DLL\System.Win32.NET.dll</HintPath>
  </Reference>
</ItemGroup>
```

```bash
git clone <repository-url>
dotnet add reference path/to/System.Win32.NET.csproj
```

## Platform Support

Every Win32-backed module explicitly checks the OS and throws `PlatformNotSupportedException`
when run outside Windows.

| Module | Platform |
|---|---|
| `BitOperations.Bit` | Cross-platform |
| `GUI.MessageWindow` | Windows only |
| `Memory.Memory` | Windows only |
| `ProcessLauncher.Launcher` | Cross-platform (Windows, Linux, macOS) |
| `Terminal.Terminal` | Windows only |
| `Web.WebBrowser` | Cross-platform |
| `WindowsAppsManager.WindowsApps` | Windows only |

## Modules

### BitOperations

Namespace: `System32.BitOperations`

Generic, allocation-free bit manipulation for any type implementing `IBinaryInteger<T>` (`int`,
`long`, `byte`, etc.).

```csharp
using System32.BitOperations;

long number = 0b0000_1001;

long turnedOn  = Bit.ChangeBitAt(number, bitPosition: 1, BitState.Active);
long turnedOff = Bit.ChangeBitAt(number, bitPosition: 0, BitState.Inactive);
long switched  = Bit.ChangeBitAt(number, bitPosition: 3, BitState.Switch);

long inverted  = Bit.InvertAllBits(number);       // flips every bit
long allOn     = Bit.SetAllBits(number, BitState.Active);   // all bits to 1
long allOff    = Bit.SetAllBits(number, BitState.Inactive); // all bits to 0
```

`BitState` values: `Active` (turn bit on), `Inactive` (turn bit off), `Switch` (toggle).

### GUI (MessageWindow)

Namespace: `System32.GUI` — **Windows only**

Opens a classic Win32 `MessageBoxW` dialog.

```csharp
using System32.GUI;

Response result = MessageWindow.Show(
    message: "Do you want to continue?",
    title: "Confirm",
    windowType: WindowType.WithButtonsYesNo | WindowType.WithQuestionMark
);

if (result is Response.Yes)
{
    // ...
}
```

- `message`, `title`, and `windowType` are all optional — sensible defaults (`"."`, `"Message Window"`, OK button) are applied if omitted or invalid.
- `WindowType` flags combine a button set (`WithButtonOK`, `WithButtonsYesNo`, `WithButtonsYesNoCancel`, `WithButtonOKCancel`, `WithButtonsRetryCancel`, `WithButtonsAbortRetryIgnore`, `WithButtonsCancelTryAgainContinue`) with an icon (`WithErrorIcon`, `WithQuestionMark`, `WithWarningIcon`, `WithInfoIcon`) via bitwise OR.
- `Response` mirrors the native `MessageBoxW` return codes: `OK`, `Cancel`, `Abort`, `Retry`, `Ignore`, `Yes`, `No`, `TryAgain`, `Continue`.

### Memory

Namespace: `System32.Memory` — **Windows only**

Thin wrapper around the Win32 process heap (`GetProcessHeap` / `HeapAlloc` / `HeapReAlloc` /
`HeapFree`) for manual unmanaged memory management.

```csharp
using System32.Memory;

nint block = Memory.Allocate(256);           // zero-initialized 256-byte block
block = Memory.Reallocate(block, 512);       // grow to 512 bytes (may move address)
Memory.Free(block);                          // release the block
```

⚠️ This is raw manual memory management — the caller is responsible for freeing every block
allocated with `Allocate`/`Reallocate`. Passing an invalid or already-freed pointer results in
exceptions raised from the PAL (`SystemException`) rather than undefined behavior, since each
native call result is validated.

### ProcessLauncher

Namespace: `System32.ProcessLauncher` — **cross-platform**

Runs a native process/command via the C standard library's `system()` function.

```csharp
using System32.ProcessLauncher;

int exitCode = Launcher.Launch("notepad.exe"); // Windows
int exitCode = Launcher.Launch("ls -la");      // Linux / macOS
```

Returns `0` on success and `-1` if the process fails to start (a Win32 message box is also shown
in that case). Because it shells out through `system()`, it **cannot** open URLs directly — use
`Web.WebBrowser` for that.

### Terminal

Namespace: `System32.Terminal` — **Windows only**

Low-level console I/O implemented directly through `kernel32.dll` (`ReadConsoleW`,
`WriteConsoleW`, `SetConsoleTextAttribute`, `Beep`) instead of `System.Console`.

```csharp
using System32.Terminal;

Terminal.PrintLine("Enter your name:");
string name = Terminal.GetLine();

Terminal.ChangeTerminalColors(TerminalForeground.LightGreen, TerminalBackground.Black);
Terminal.PrintLine($"Hello, {name}!");
Terminal.ResetColors();

Terminal.Beep(duration: 300, frequency: 1000);
```

- `Print` / `PrintLine` accept any `object` (`ToString()` is called internally).
- `TerminalForeground` / `TerminalBackground` are `[Flags]`-style enums that combine into a single
  console attribute value.

### Web (WebBrowser)

Namespace: `System32.Web` — **cross-platform**

```csharp
using System32.Web;

WebBrowser.Open();                                   // opens https://www.google.com
WebBrowser.Open("https://github.com");               // opens a specific URL
```

The URL is validated (`http`/`https` scheme required via `Uri.TryCreate`) before
`Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true })` is invoked; an
invalid URL throws `InvalidDataException`. Note that `UseShellExecute`-based URL launching is most
reliable on Windows — behavior on Linux/macOS depends on the configured default handler for `http(s)` URLs.

### WindowsAppsManager

Namespace: `System32.WindowsAppsManager` — **Windows only**

Launches common built-in Windows applications and utilities. Every method checks the OS first and
throws `PlatformNotSupportedException` when called outside Windows.

```csharp
using System32.WindowsAppsManager;

WindowsApps.OpenCalculator();
WindowsApps.OpenNotepad();
WindowsApps.OpenTaskManager();
WindowsApps.OpenFileManager(SystemFolders.Documents); // defaults to Desktop if no path given
```

Available launchers: `OpenCalculator`, `OpenNotepad`, `OpenPaint`, `OpenSnippingTool`,
`OpenTerminal` (Command Prompt), `OpenPowershell`, `OpenTaskManager`, `OpenControlPanel`,
`OpenServices`, `OpenRegistryEditor`, `OpenResourceMonitor`, `OpenFileManager(string? path)`.

`SystemFolders` provides ready-made paths for `OpenFileManager`: `Desktop`, `Documents`, `Music`,
`Pictures`, `Videos`, `Windows`.

## Building

```bash
dotnet build
```

No test project is currently included in the repository.

## License

Licensed under the [Apache License 2.0](LICENSE.txt).