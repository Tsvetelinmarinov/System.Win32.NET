namespace System32.WindowsAppsManager
{
    /// <summary>
    ///  Provides system folders paths.
    ///  Use it in System32.WindowsAppsManager.WindowsApps.OpenFileManager(string? path)
    ///  method to specify system folder to open on start.
    /// </summary>
    public static class SystemFolders
    {
        /// <summary>
        ///  Specifies the Desktop directory.
        /// </summary>
        public static string Desktop 
            => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        ///  Specifies the Documents directory.
        /// </summary>
        public static string Documents
            => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        ///  Specifies MyMusic directory.
        /// </summary>
        public static string Music
            => Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        /// <summary>
        ///  Specifies MyPictures directory.
        /// </summary>
        public static string Pictures
            => Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        /// <summary>
        ///  Specifies MyVideos directory.
        /// </summary>
        public static string Videos
            => Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

        /// <summary>
        ///  Specifies Windows directory.
        /// </summary>
        public static string Windows
            => Environment.GetFolderPath(Environment.SpecialFolder.Windows);
    }
}