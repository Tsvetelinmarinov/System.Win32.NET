using System32.Interoperability.Helpers;
using System32.Interoperability.InternalServices;

namespace System32.Interoperability.PlatformAbstractionLayer
{
    internal static class MessageWindowPAL
    {
        internal static int ShowPAL(string? message, string? title, long? configuration)
        {
            // Check the OS! Platform depended type!
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            // Validate the message and the title.
            message ??= MessageWindowDefaultValues.DefMessage;
            title ??= MessageWindowDefaultValues.DefTitle;

            // Validate the window config value.
            if (configuration is null || configuration < MessageWindowDefaultValues.DefConfig)
            {
                configuration = MessageWindowDefaultValues.DefConfig; // If it`s negative -> becomes 0.
            }

            unsafe
            {
                // Fixing a pointers to the message and to the title in the memory,
                // so GC won`t reallocate it.
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