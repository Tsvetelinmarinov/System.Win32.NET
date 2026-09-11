using System.Runtime.InteropServices;
using System32.Interoperability.Helpers;
using System32.Interoperability.InternalServices;
using System32.Terminal;

namespace System32.Interoperability.PlatformAbstractionLayer
{
    //
    // Terminal Platform Abstraction Layer communicates
    // with the Terminal interoperability service.
    //
    internal static class TerminalPAL
    {
        // Encapsulates safety the call to the unmanaged C function ReadConsoleW
        // and validates the OS and the result string.
        internal static string GetLinePAL()
        {
            // Check the OS.
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            // AllocateCore local result buffer.
            Span<char> outputBuffer = stackalloc char[666];

            // Indicates that the reading of the stdin is successful.
            bool successReading = false;

            unsafe 
            {
                // Get a pointer to the standard input stream.
                void* inputStreamPtr 
                    = Terminal_WIN32_InteropService.GetStdHandle(TerminalInteropCodes.StandardInput);

                // Fixing a buffer pointer, so GC will not reallocate it
                // while the C function ReadConsoleW writes in it.
                fixed (char* bufferPtr = outputBuffer)
                {
                    // Try read and export the result.
                    successReading = Terminal_WIN32_InteropService.ReadConsoleW(
                        inputStreamPtr,
                        bufferPtr,
                        (uint)outputBuffer.Length,
                        out uint _, //=> In our case, readedChars is not needed. 
                        null
                    );
                }
            }

            if (successReading) //=> Now outputBuffer should be filled with the text from the input stream.
            {
                // Remove the excess and return only the text as string.
                string resultString = new(outputBuffer.Trim());
                return resultString;
            }
            else
            {
                throw new InvalidOperationException("PAL: Reading the standard input stream fails!");
            }
        }

        // Encapsulates safety the call to the unmanaged C function WriteConsoleW
        // and validates the OS and the text.
        internal static int PrintPAL(object? data)
        {
            // Check the OS.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            // Validate the input.
            data ??= string.Empty;
            string dataStr = data.ToString()!;

            bool successWrite = false; //=> Indicates successful writing.
            Span<char> textSpan = new([.. dataStr]); //=> Convert the string to span.
            uint writtenChars = 0; //=> The count of the written chars.

            unsafe
            {
                // Get pointer to the standard output stream.
                void* outputStreamPtr
                    = Terminal_WIN32_InteropService.GetStdHandle(TerminalInteropCodes.StandardOutput);

                // Creating a fixed pointer to the text for safe using of WriteConsoleW.
                fixed (char* textPtr = textSpan)
                {
                    successWrite = Terminal_WIN32_InteropService.WriteConsoleW(
                        outputStreamPtr,
                        textPtr,
                        (uint)dataStr.Length,
                        out writtenChars,
                        null
                    );
                }
            }

            if (successWrite)
            {
                return (int)writtenChars;
            }
            else
            {
                throw new InvalidOperationException("PAL: Writing the text to the standard output fails!");
            }
        }

        // Helper function for printing a text with a new line character.
        internal static int PrintLinePAL(object? text)
        {
            int printed = PrintPAL(text);
            _ = PrintPAL("\n");
            return printed;
        }

        // Encapsulates safety the call to the unmanaged C function SetConsoleTextAttribute
        internal static void ChangeTerminalColorsPAL(ushort newColors)
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            bool successfulChanging; //=> Indicates successful changing of the console foreground.

            unsafe
            {
                // Get pointer to the standard output stream.
                void* stdOutPtr 
                    = Terminal_WIN32_InteropService.GetStdHandle(TerminalInteropCodes.StandardOutput);

                successfulChanging = Terminal_WIN32_InteropService.SetConsoleTextAttribute(
                    stdOutPtr, 
                    newColors
                );
            }

            if (successfulChanging is false)
            {
                throw new InvalidOperationException("PAL: Something went wrong while changing the console foreground color!");
            }
        }

        // Helper method to reset the standard gray-white foreground.
        internal static void ResetColorsPAL()
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            ChangeTerminalColorsPAL((ushort)TerminalForeground.White | (ushort)TerminalBackground.Black);
        }

        // Encapsulates safety the call to the unmanaged C function Beep.
        internal static void BeepPAL(int duration, int frequency)
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            if (duration < 0)
            {
                duration = 0;
            }

            if (frequency < 0)
            {
                frequency = 0;
            }

            Terminal_WIN32_InteropService.Beep(frequency, duration);
        }
    }
}