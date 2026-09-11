namespace System32.GUI
{
    /// <summary>
    ///  Specifies the type of the <see cref="MessageWindow"/>.
    /// </summary>
    public enum WindowType : long
    {
        #region Buttons

        /// <summary>
        ///  With Ok button.
        /// </summary>
        WithButtonOK = 0x00000000L,

        /// <summary>
        ///  With buttons Yes and No.
        /// </summary>
        WithButtonsYesNo = 0x00000004L,
        
        /// <summary>
        ///  With buttons OK and Cancel.
        /// </summary>
        WithButtonOKCancel = 0x00000001L,

        /// <summary>
        ///  With buttons Yes, No and Cancel.
        /// </summary>
        WithButtonsYesNoCancel = 0x00000003L,

        /// <summary>
        ///  With buttons Retry and Cancel.
        /// </summary>
        WithButtonsRetryCancel = 0x00000005L,
       
        /// <summary>
        ///  With buttons Abort, Retry and Ignore.
        /// </summary>
        WithButtonsAbortRetryIgnore = 0x00000002L,

        /// <summary>
        ///  With buttons Cancel, Try again and Continue.
        /// </summary>
        WithButtonsCancelTryAgainContinue = 0x00000006L,

        #endregion
        #region Icons

        /// <summary>
        ///  With error icon.
        /// </summary>
        WithErrorIcon = 0x00000010L,

        /// <summary>
        ///  With question mark icon.
        /// </summary>
        WithQuestionMark = 0x00000020L,

        /// <summary>
        ///  With warning icon.
        /// </summary>
        WithWarningIcon = 0x00000030L,

        /// <summary>
        ///  With info icon.
        /// </summary>
        WithInfoIcon = 0x00000040L,

        #endregion
    }
}