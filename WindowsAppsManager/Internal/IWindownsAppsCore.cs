using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System32.WindowsAppManager.Internal
{
    internal interface IWindowsAppsCore
    {
        public void OpenCalculator();
        public void OpenNotepad();
        public void OpenPaint();
        public void OpenSnippingTool();
        public void OpenTerminal();
        public void OpenPowershell();
        public void OpenTaskManager();
        public void OpenControlPanel();
        public void OpenServices();
        public void OpenRegistryEditor();
        public void OpenResourceMonitor();
        public void OpenFileManager(string? path = null);
    }
}