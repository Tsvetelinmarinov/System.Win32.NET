using System32.Interoperability.PlatformAbstractionLayer;

namespace System32.ProcessLauncher.Internal
{
    internal sealed class LauncherCore : ILauncherCore
    {
        public int LaunchCore(string processName)
            => ProcessLauncherPAL.LaunchProcessCore(processName);
    }
}