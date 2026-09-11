using System32.Interoperability.Helpers;
using System32.Interoperability.InternalServices;

namespace System32.Interoperability.PlatformAbstractionLayer
{
    internal static class MessageWindowPAL
    {
        internal static int ShowPAL(string? message, string? title, long? configuration)
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            message ??= MessageWindowDefaultValues.DefMessage;
            title ??= MessageWindowDefaultValues.DefTitle;

            if (configuration is null || configuration < MessageWindowDefaultValues.DefConfig)
            {
                configuration = MessageWindowDefaultValues.DefConfig;
            }

            unsafe
            {
                fixed (char* msgPtr = message, titlePtr = title)
                {
                    return MessageWindow_WIN32_InteropService.MessageBoxW(
                        null, //=> No parent window.
                        msgPtr,
                        titlePtr,
                        (long)configuration
                    );
                }
            }
        }
    }
}