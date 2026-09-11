namespace System32.Interoperability.Helpers
{
    //
    // Holds codes that specifies the console input or output streams.
    //
    internal static class TerminalInteropCodes
    {
        //
        // stdin code -> Specifies the stream in GetStdHandle C function.
        // The C function GetStdHandle(int handleCode) returns a pointer to the specified
        // stream.
        // That pointer is passed to the ReadConsoleW C function to read the next
        // line of input from the standard input stream(stdin).
        //
        internal const sbyte StandardInput = -10;

        //
        // stdout code -> Specifies the stream in GetStdHandle C function.
        // The C function GetStdHandle(int handleCode) returns a pointer to the specified
        // stream.
        // That pointer is passed to the WriteConsoleW C function to write the next
        // to the standard output stream(stdout).
        //
        internal const sbyte StandardOutput = -11;
    }
}