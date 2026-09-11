using System32.Interoperability.PlatformAbstractionLayer;

namespace System32.Terminal.Internal
{
    //
    // Prides implementation for ITerminalCore interface.
    // Communicates with the Terminal PAL.
    //
    internal class TerminalCore : ITerminalCore
    {
        internal TerminalCore()
        {
        }

        public void BeepCore(int duration, int? frequency)
        {
            frequency ??= 1000; // 1000 hrz default if null.
            TerminalPAL.BeepPAL(duration, (int)frequency);
        }
        public void ChangeTerminalColorsCore(TerminalForeground foregroundColor, TerminalBackground backgroundColor)
            => TerminalPAL.ChangeTerminalColorsPAL((ushort)((ushort)foregroundColor | (ushort)backgroundColor));
        public string GetLineCore()
            => TerminalPAL.GetLinePAL();
        public int PrintCore(object data)
            => TerminalPAL.PrintPAL(data);
        public int PrintLineCore(object data)
            => TerminalPAL.PrintLinePAL(data);
        public void ResetColorsCore()
            => TerminalPAL.ResetColorsPAL();
    }
}