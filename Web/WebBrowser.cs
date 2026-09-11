using System32.Web.Internal;

namespace System32.Web
{
    /// <summary>
    ///  Provides static method for launching the default web browser
    ///  of the machine.
    ///  NOTE: This type is cross-platform!
    /// </summary>
    public static class WebBrowser
    {
        #region Private fields

        // Web browser engine.
        private static readonly IWebBrowserCore s_Engine
            = WebBrowserFactory.ConstructBrowser();

        #endregion


        /// <summary>
        ///  Opens the default web browser of the machine and
        ///  navigates to the specified link. If no link is specified
        ///  the Google main page will be loaded.
        /// </summary>
        /// <param name="url">
        ///  Optional url address to load on start.
        /// </param>
        public static void Open(string? url = null)
            => s_Engine.OpenCore(url);
    }
}