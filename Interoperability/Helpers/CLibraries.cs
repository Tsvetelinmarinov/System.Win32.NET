namespace System32.Interoperability.Helpers
{
    // Holds the names of the most common C libraries on Windows, Linux and MacOS.
    internal static class CLibraries
    {
        internal const string User32Win = "user32.dll";
        internal const string UniversalCLibWin = "ucrtbase.dll";
        internal const string UniversalCLibLinux = "libc";
        internal const string UniversalCLibOSX = "libSystem";
        internal const string Kernel32Win = "kernel32.dll";
    }
}
