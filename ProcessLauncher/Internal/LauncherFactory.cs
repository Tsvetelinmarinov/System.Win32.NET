namespace System32.ProcessLauncher.Internal
{
    internal static class LauncherFactory
    {
        internal static ILauncherCore CreateLauncher()
            => new LauncherCore();
    }
}