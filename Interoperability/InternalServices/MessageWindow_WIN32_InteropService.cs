using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System32.Interoperability.Helpers;

namespace System32.Interoperability.InternalServices
{
    internal static partial class MessageWindow_WIN32_InteropService
    {
        // Shows classical Win32 dialog window.
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.User32Win,
            EntryPoint = "MessageBoxW",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf8
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static unsafe partial int MessageBoxW(
            void* parentWindowPtr,
            char* message,
            char* title,
            long configuration
        );
    }
}