using System32.Terminal.Internal;

namespace System32.Terminal
{
    /// <summary>
    ///  Provides methods for console I/O.
    /// </summary>
    public static class Terminal
    {
        #region Private Fields

        // Internal Terminal object.
        private static readonly ITerminalCore s_CoreTerminal;

        #endregion

        #region Constructor

        // Static type ctor.
        // This type is not designed to be instantiated.
        // Use the static methods instead to do the job.
        static Terminal()
        {
            s_CoreTerminal = TerminalFactory.GetTerminal();
        }

        #endregion

        #region Functionality -> Static Methods

        /// <summary>
        ///  Reads the next line of input from the console.
        /// </summary>
        /// <returns>
        ///  The next line of input as string.
        /// </returns>
        public static string GetLine()
            => s_CoreTerminal.GetLineCore();

        /// <summary>
        ///  Prints the data to the console.
        /// </summary>
        /// <param name="data">
        ///  The data to be printed.
        /// </param>
        /// <returns>
        ///  The number of the printed symbols.
        /// </returns>
        public static int Print(object data)
            => s_CoreTerminal.PrintCore(data);

        /// <summary>
        ///  Prints the data to the console followed by a new line.
        /// </summary>
        /// <param name="data">
        ///  The data to be printed.
        /// </param>
        /// <returns>
        ///  The number of the printed symbols.
        /// </returns>
        public static int PrintLine(object data)
            => s_CoreTerminal.PrintLineCore(data);

        /// <summary>
        ///  Changes the foreground color of the terminal.
        /// </summary>
        /// <param name="foregroundColor">
        ///  The new foreground color.
        /// </param>
        /// <param name="backgroundColor">
        ///  The new background color.
        /// </param>
        public static void ChangeTerminalColors(TerminalForeground foregroundColor, TerminalBackground backgroundColor)
            => s_CoreTerminal.ChangeTerminalColorsCore(foregroundColor, backgroundColor);

        /// <summary>
        ///  Reset the original white foreground color.
        /// </summary>
        public static void ResetColors()
            => s_CoreTerminal.ResetColorsCore();

        /// <summary>
        ///  Beeps with the specified frequency with duration
        ///  the specified time in milliseconds.
        /// </summary>
        /// <param name="duration">
        ///  The duration of the sound in milliseconds.
        /// </param>
        /// <param name="frequency">
        ///  The frequency of the sound.
        /// </param>
        public static void Beep(int duration, int? frequency = null)
            => s_CoreTerminal.BeepCore(duration, frequency);

        #endregion
    }
}