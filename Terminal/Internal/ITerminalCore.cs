namespace System32.Terminal.Internal
{
    //
    // Defines Terminal
    //
    internal interface ITerminalCore
    {
        // Gets next line of input from the console.
        string GetLineCore();

        // Prints the text to the console.
        int PrintCore(object data);

        // Prints the text and a new line to the console.
        int PrintLineCore(object data);

        // Changes the terminal foreground.
        void ChangeTerminalColorsCore(TerminalForeground foregroundColor, TerminalBackground backgroundColor);

        // Reset the original foreground color.
        void ResetColorsCore();

        // Beeps.
        void BeepCore(int duration, int? frequency);
    }
}