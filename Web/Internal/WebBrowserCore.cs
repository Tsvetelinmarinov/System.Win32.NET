using System.Diagnostics;

namespace System32.Web.Internal
{
    internal class WebBrowserCore : IWebBrowserCore
    {
        #region Constructor

        // Internal ctor. Use the static method to do the job.
        // Only WebBrowserFactory.cs uses this ctor.
        internal WebBrowserCore()
        {
        }

        #endregion

        #region Core

        public void OpenCore(string? url)
        {
            url ??= "https://www.google.com"; //=> default if null.

            if (IsValidUrl(url) is false)
            {
                throw new InvalidDataException("The provided URL address is invalid.");
            }

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true,
                }
            );
        }

        private static bool IsValidUrl(string url)
        {
            bool isValid = Uri.TryCreate(url, UriKind.Absolute, out Uri? resultUri);
            ArgumentNullException.ThrowIfNull(resultUri, nameof(resultUri));
            bool isWithHttp = resultUri.Scheme == Uri.UriSchemeHttp || resultUri.Scheme == Uri.UriSchemeHttps;
            return isValid && isWithHttp;
        }

        #endregion
    }
}