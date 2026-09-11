using System32.GUI.Internal;

namespace System32.GUI
{
    /// <summary>
    ///  Provides static method for opening Windows dialog window.
    /// </summary>
    public static class MessageWindow
    {
        #region Private Fields

        private static readonly IMessageWindowCore s_CoreWind;

        #endregion

        #region Constructor

        static MessageWindow()
        {
            s_CoreWind = MessageWindowFactory.CreateMessageWindow();
        }

        #endregion

        /// <summary>
        ///  Shows dialog window.
        /// </summary>
        /// <param name="message">The message of the window</param>
        /// <param name="title">The title of the window</param>
        /// <param name="windowType">The type of the window</param>
        /// <returns>The result from the window.</returns>
        public static Response Show(string message, string? title = null, WindowType? windowType = null)
            => s_CoreWind.Show(message, title, windowType);
    }
}