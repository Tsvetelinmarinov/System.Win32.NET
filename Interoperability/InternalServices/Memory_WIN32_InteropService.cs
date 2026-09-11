using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System32.Interoperability.Helpers;

namespace System32.Interoperability.InternalServices
{
    //
    // Holds the P/Invoke logic with Win32 API 
    //
    internal static partial class Memory_WIN32_InteropService
    {
        #region GetProcessHeap() P/Invoke Logic

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "GetProcessHeap",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        internal static unsafe partial void* GetProcessHeap();

        #endregion

        #region HeapAlloc() P/Invoke Logic

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "HeapAlloc",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        internal static unsafe partial void* HeapAlloc(
            void* processStackPtr,
            uint controlFlag,
            uint* bytesToAllocate
        );

        #endregion

        #region HeapFree() P/Invoke Logic

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "HeapFree",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static unsafe partial bool HeapFree(
            void* processStackPtr,
            uint controlFlag,
            void* allocatedMemory
        );

        #endregion

        #region HeapReAlloc P/Invoke Logic

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "HeapReAlloc",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        internal static unsafe partial void* HeapReAlloc(
            void* appProcessStackPtr,
            uint allocationFlags,
            void* memoryPtr,
            uint* newSizeInBytes
        );

        #endregion
    }
}