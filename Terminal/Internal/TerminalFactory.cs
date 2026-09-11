namespace System32.Terminal.Internal
{
    // Constructs TerminalCore object and returns it as ITerminalCore interface.
    internal static class TerminalFactory
    {
        internal static ITerminalCore GetTerminal()
            => new TerminalCore();
    }
}