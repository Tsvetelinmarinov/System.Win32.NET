using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System32.Interoperability.Helpers;

namespace System32.Interoperability.InternalServices
{
    // 
    // Holds the P/Invoke Logic with the Win32 API kernel32.dll.
    // That interoperability service provides core functionality for the
    // System32.IO.Terminal.cs class.
    //
    internal static partial class Terminal_WIN32_InteropService
    {
        #region GetStdHandle P/Invoke Logic

        // Gets a pointer to the console standard input or output streams.
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        internal static unsafe partial void* GetStdHandle(int ioStreamCode);

        #endregion

        #region ReadConsoleW P/Invoke Logic

        // Reads the next line of input from the standard input stream.
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "ReadConsoleW",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static unsafe partial bool ReadConsoleW(
            void* consoleIoPtr,      //=> Pointer to the console I/O stream.
            char* outputBufferPtr,   //=> Pointer to the output buffer.
            uint numberOfCharsToRead,//=> Number of the chars to read.
            out uint readedChars,    //=> Readed chars.
            void* optCtlPtr          //=> Optional control pointer -> always null.
        );

        #endregion

        #region WriteConsoleW P/Invoke Logic

        // Writes the text in the buffer to the standard output stream.
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "WriteConsoleW",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static unsafe partial bool WriteConsoleW(
            void* outputStreamPtr,
            char* dataBufferPtr,
            uint numberOfCharsToWrite,
            out uint writtenChars,
            void* additionalControlPtr
        );

        #endregion

        #region SetConsoleTextAttribute P/Invoke Logic

        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "SetConsoleTextAttribute",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static unsafe partial bool SetConsoleTextAttribute(void* outputStreamPtr, ushort newColors);

        #endregion

        #region Beep P/Invoke Logic

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "Beep",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial void Beep(int frequency, int duration);

        #endregion
    }
}