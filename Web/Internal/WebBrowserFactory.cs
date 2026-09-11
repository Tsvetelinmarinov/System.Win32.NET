namespace System32.Web.Internal
{
    // Constructs new WebBrowserCore object.
    internal static class WebBrowserFactory
    {
        internal static IWebBrowserCore ConstructBrowser()
            => new WebBrowserCore();
    }
}