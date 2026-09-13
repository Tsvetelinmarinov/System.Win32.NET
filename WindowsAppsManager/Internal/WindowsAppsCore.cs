namespace System32.WindowsAppsManager.Internal
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System32.Interoperability.Helpers;

    /// <summary>
    ///  Provides set of static methods for opening various list of windows applications.
    ///  All methods of this class runs only on Windows OS.
    /// </summary>
    internal sealed class WindowsAppsCore : IWindowsAppsCore
    {
        #region Private Fields

        //
        // Following private fields bellow describes various windows applications.
        //
        private static readonly string s_Calculator = "calc.exe";
        private static readonly string s_Notepad = "notepad.exe";
        private static readonly string s_Paint = "mspaint.exe";
        private static readonly string s_SnippingTool = "snippingtool.exe";
        private static readonly string s_CommandPrompt = "cmd.exe";
        private static readonly string s_PowerShell = "powershell.exe";
        private static readonly string s_TaskManager = "taskmgr.exe";
        private static readonly string s_ControlPanel = "control.exe";
        private static readonly string s_Services = "services.msc";
        private static readonly string s_RegistryEditor = "regedit.exe";
        private static readonly string s_ResourceMonitor = "resmon.exe";
        private static readonly string s_FileManager = "explorer.exe";

        // Desktop directory
        // For internal needs. Loads when no directory has been specified
        // in the OpenFileManager() command bellow.
        private static readonly string s_DesktopDir 
            = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        #endregion
        #region Constructor

        internal WindowsAppsCore()
        {
        }

        #endregion
        #region Core Functionality

        /// <summary>
        ///  Opens the Calculator.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)] //=> Export with exact same signature.
        public void OpenCalculator()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_Calculator, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Notepad.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenNotepad()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_Notepad, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens Paint.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenPaint()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_Paint, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Snipping tool for screenshots.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenSnippingTool()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_SnippingTool, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the terminal/command propmt
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenTerminal()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_CommandPrompt, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Powershell terminal.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenPowershell()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_PowerShell, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Task Manager.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenTaskManager()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_TaskManager, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Control Panel.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenControlPanel()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_ControlPanel, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens Services.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenServices()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_Services, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Registry editor.
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenRegistryEditor()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_RegistryEditor, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the Resource Monitor
        /// </summary>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenResourceMonitor()
        {
            ThrowIfNotWindows();
            Process.Start(new ProcessStartInfo { FileName = s_ResourceMonitor, UseShellExecute = true });
        }

        /// <summary>
        ///  Opens the file manager with at the specified directory.
        /// </summary>
        /// <param name="path">
        ///  The directory to open. If not specified, the Desktop directory will load.
        /// </param>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public void OpenFileManager(string? path = null)
        {
            ThrowIfNotWindows();

            path ??= s_DesktopDir; // If null - Desktop directory.

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new SystemException("The path is only white spaces!");
            }

            if (Directory.Exists(path) is true)
            {
                _ = Process.Start(new ProcessStartInfo
                {
                    FileName = s_FileManager, // File explorer
                    Arguments = path,       // Directory to load
                    UseShellExecute = true
                });
            }
            else
            {
                throw new SystemException($"The file at \"{path}\" does not exist!");
            }
        }

        #endregion
        #region Private Core Functionality

        // Throws if the current OS is not Windows.
        // All methods of this class are Windows-only, so this check is run first in every one of them.
        [MethodImpl(MethodImplOptions.PreserveSig)]
        private static void ThrowIfNotWindows()
        {
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }
        }

        #endregion
    }
}