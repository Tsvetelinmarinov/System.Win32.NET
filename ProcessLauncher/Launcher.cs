using System32.ProcessLauncher.Internal;

namespace System32.ProcessLauncher
{
    /// <summary>
    ///  Provides static method for launching a system process.
    ///  Note that type is cross-platform, so works on Windows,
    ///  Linux and MacOS.
    /// </summary>
    public static class Launcher
    {
        #region Private Fields

        private static readonly ILauncherCore s_CoreLauncher;

        #endregion

        #region Constructor

        static Launcher()
        {
            s_CoreLauncher = LauncherFactory.CreateLauncher();
        }

        #endregion


        /// <summary>
        ///  Starts system process.
        ///  This command works with C function system(const char* cmd)
        ///  in the background. It cannot open URL links for example.
        ///  The process name/path is opened by the CommandPrompt.
        /// </summary>
        /// <param name="process">
        ///  The process to be started.
        /// </param>
        /// <returns>
        ///  The exit code of the process - 0 if success, -1 if something went wrong.
        /// </returns>
        public static int Launch(string process)
            => s_CoreLauncher.LaunchCore(process);
    }
}