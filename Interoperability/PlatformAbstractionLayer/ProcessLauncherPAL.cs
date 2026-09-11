using System32.Interoperability.InternalServices;

namespace System32.Interoperability.PlatformAbstractionLayer
{
    internal static class ProcessLauncherPAL
    {
        internal static int LaunchProcessCore(string processName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(processName, nameof(processName));

            try
            {
                if (OperatingSystem.IsWindows())
                {
                    return ProcessLauncher_CrossPlatform_InteropService
                        .ExecuteProcCore_WIN32(processName);
                }
                else if (OperatingSystem.IsLinux())
                {
                    return ProcessLauncher_CrossPlatform_InteropService
                        .ExecuteProcCore_LINUX(processName);
                }
                else if (OperatingSystem.IsMacOS())
                {
                    return ProcessLauncher_CrossPlatform_InteropService
                        .ExecuteProcCore_OSX(processName);
                }
                else
                {
                    throw new PlatformNotSupportedException("Unsupported platform detected! Only Windows, Linux and OSX are supported.");
                }
            }
            catch (Exception)
            {
                _ = MessageWindowPAL.ShowPAL(
                    $"Something went wrong while starting process {processName}.",
                    "Information Window",
                    0x00000010
                );

                return -1;
            }
        }
    }
}