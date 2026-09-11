namespace System32.GUI.Internal
{
    internal interface IMessageWindowCore
    {
        Response Show(string message, string? title, WindowType? windowType);
    }
}