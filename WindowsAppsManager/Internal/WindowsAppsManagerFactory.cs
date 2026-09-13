namespace System32.WindowsAppsManager.Internal
{
    internal static class WindowsAppsManagerFactory
    {
        internal static IWindowsAppsCore CreateWindowsAppsManager()
            => new WindowsAppsCore();
    }
}