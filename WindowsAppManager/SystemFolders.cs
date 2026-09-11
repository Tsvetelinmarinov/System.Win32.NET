namespace System32.WindowsAppManager
{
    /// <summary>
    ///  Provides constant strings that specifies system folders paths.
    ///  Use it in System32.WindowsAppManager.WindowsApps.OpenFileManager() method to 
    ///  specify system folder to open.
    /// </summary>
    public static class SystemFolders
    {
        /// <summary>
        ///  Specifies the Desktop directory
        /// </summary>
        public static string Desktop 
            => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        ///  Specifies the Documents directory
        /// </summary>
        public static string Documents
            => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }
}