using System32.Interoperability.PlatformAbstractionLayer;

namespace System32.GUI.Internal
{
    internal sealed class MessageWindowCore : IMessageWindowCore
    {
        public Response Show(string message, string? title, WindowType? windowType)
            => (Response)MessageWindowPAL.ShowPAL(message, title, (long?)windowType);
    }
}