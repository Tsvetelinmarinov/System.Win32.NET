namespace System32.Terminal
{
    /// <summary>
    ///  Provides foreground colors for the Terminal.cs class.
    /// </summary>
    public enum TerminalForeground : ushort
    {
        /// <summary>
        ///  Dark red.
        /// </summary>
        DarkRed = 0x0004,

        /// <summary>
        ///  Dark green.
        /// </summary>
        DarkGreen = 0x0002,

        /// <summary>
        ///  Dark blue
        /// </summary>
        DarkBlue = 0x0001,

        /// <summary>
        ///  Light red.
        /// </summary>
        LightRed = DarkRed | 0x0008,

        /// <summary>
        ///  Light green.
        /// </summary>
        LightGreen = DarkGreen | 0x0008,

        /// <summary>
        ///  Light blue.
        /// </summary>
        LightBlue = DarkBlue | 0x0008,

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