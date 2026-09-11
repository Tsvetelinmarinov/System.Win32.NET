namespace System32.Terminal
{
    /// <summary>
    ///  Provides flags that specifies terminal background colors.
    /// </summary>
    public enum TerminalBackground : ushort //=> The Win32 C function SetConsoleTextAttribute requires ushort.
    {
        /// <summary>
        ///  Dark blue.
        /// </summary>
        DarkBlue = 0x0010,

        /// <summary>
        ///  Dark green.
        /// </summary>
        DarkGreen = 0x0020,

        /// <summary>
        ///  Dark red.
        /// </summary>
        DarkRed = 0x0040,

        /// <summary>
        ///  Light blue.
        /// </summary>
        LightBlue = DarkBlue | 0x0080,

        /// <summary>
        ///  Light green.
        /// </summary>
        LightGreen = DarkGreen | 0x0080,

        /// <summary>
        ///  Light red.
        /// </summary>
        LightRed = DarkRed | 0x0080,

        /// <summary>
        ///  Cyan.
        /// </summary>
        Cyan = DarkBlue | DarkGreen,

        /// <summary>
        ///  Magenta.
        /// </summary>
        Magenta = DarkBlue | DarkRed,

        /// <summary>
        ///  White.
        /// </summary>
        White = DarkBlue | DarkGreen | DarkRed,

        /// <summary>
        ///  Black.
        /// </summary>
        Black = 0
    }
}