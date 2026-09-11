using System32.Interoperability.Helpers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System32.Interoperability.InternalServices
{
    internal static partial class ProcessLauncher_CrossPlatform_InteropService
    {
        //=> C function system() for Windows.
        [LibraryImport(
            CLibraries.UniversalCLibWin,
            EntryPoint = "system",
            StringMarshalling = StringMarshalling.Utf8,
            SetLastError = true
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static partial int ExecuteProcCore_WIN32(string procNm);


        //=> C function system() for Linux.
        [LibraryImport(
            CLibraries.UniversalCLibLinux,
            EntryPoint = "system",
            StringMarshalling = StringMarshalling.Utf8,
            SetLastError = true
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static partial int ExecuteProcCore_LINUX(string procNm);


        //=> C function system() for MacOS.
        [LibraryImport(
            CLibraries.UniversalCLibOSX,
            EntryPoint = "system",
            StringMarshalling = StringMarshalling.Utf8,
            SetLastError = true
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static partial int ExecuteProcCore_OSX(string procNm);
    }
}