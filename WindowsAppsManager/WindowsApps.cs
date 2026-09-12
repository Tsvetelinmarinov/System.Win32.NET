using System32.WindowsAppManager.Internal;

namespace System32.WindowsAppsManager
{
    /// <summary>
    ///  Provides set of static methods for opening various list of windows applications.
    ///  All methods of this class runs only on Windows OS.
    /// </summary>
    public static class WindowsApps
    {
        #region Private Fields

        private static readonly IWindowsAppsCore s_CoreManager;

        #endregion
        #region Constructor

        static WindowsApps()
        {
            s_CoreManager = WindowsAppsManagerFactory.CreateWindowsAppsManager();
        }

        #endregion
        #region Functionality

        /// <summary>
        ///  Opens the Calculator.
        /// </summary>
        public static void OpenCalculator()
            => s_CoreManager.OpenCalculator();

        /// <summary>
        ///  Opens the Notepad.
        /// </summary>
        public static void OpenNotepad()
            => s_CoreManager.OpenNotepad();

        /// <summary>
        ///  Opens Paint.
        /// </summary>
        public static void OpenPaint()
            => s_CoreManager.OpenPaint();

        /// <summary>
        ///  Opens the Snipping tool for screenshots.
        /// </summary>
        public static void OpenSnippingTool()
             => s_CoreManager.OpenSnippingTool();

        /// <summary>
        ///  Opens the terminal/command propmt
        /// </summary>
        public static void OpenTerminal()
             => s_CoreManager.OpenTerminal();

        /// <summary>
        ///  Opens the Powershell terminal.
        /// </summary>
        public static void OpenPowershell()
             => s_CoreManager.OpenPowershell();

        /// <summary>
        ///  Opens the Task Manager.
        /// </summary>
        public static void OpenTaskManager()
             => s_CoreManager.OpenTaskManager();

        /// <summary>
        ///  Opens the Control Panel.
        /// </summary>
        public static void OpenControlPanel()
             => s_CoreManager.OpenControlPanel();

        /// <summary>
        ///  Opens Services.
        /// </summary>
        public static void OpenServices()
             => s_CoreManager.OpenServices();

        /// <summary>
        ///  Opens the Registry editor.
        /// </summary>
        public static void OpenRegistryEditor()
             => s_CoreManager.OpenRegistryEditor();

        /// <summary>
        ///  Opens the Resource Monitor
        /// </summary>
        public static void OpenResourceMonitor()
             => s_CoreManager.OpenResourceMonitor();

        /// <summary>
        ///  Opens the file manager with at the specified directory.
        /// </summary>
        /// <param name="path">
        ///  The directory to open. 
        ///  If not specified, the Desktop directory will load.
        ///  You can also specify the path with System32.WindowsAppManager.SystemFolder.XXX properties.
        /// </param>
        public static void OpenFileManager(string? path = null)
             => s_CoreManager.OpenFileManager(path);

        #endregion
    }
}