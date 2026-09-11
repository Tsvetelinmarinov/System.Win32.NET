namespace System32.GUI.Internal
{
    internal static class MessageWindowFactory
    {
        internal static IMessageWindowCore CreateMessageWindow()
            => new MessageWindowCore();
    }
}