namespace System32.WindowsAppManager.Internal
{
    internal static class WindowsAppsManagerFactory
    {
        internal static IWindowsAppsCore CreateWindowsAppsManager()
            => new WindowsAppsCore();
    }
}