namespace System32.GUI
{
    /// <summary>
    ///  Specifies the response from <see cref="MessageWindow"/>.
    /// </summary>
    public enum Response : int
    {
        /// <summary>
        ///  Button Ok is pressed.
        /// </summary>
        OK = 1,

        /// <summary>
        /// Button Cancel is pressed.
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// Button Abort is pressed.
        /// </summary>
        Abort = 3,

        /// <summary>
        /// Button Retry is pressed.
        /// </summary>
        Retry = 4,

        /// <summary>
        /// Button Ignore is pressed.
        /// </summary>
        Ignore = 5,

        /// <summary>
        /// Button Yes is pressed.
        /// </summary>
        Yes = 6,

        /// <summary>
        /// Button No is pressed.
        /// </summary>
        No = 7,

        /// <summary>
        /// Button Try again is pressed.
        /// </summary>
        TryAgain = 10,

        /// <summary>
        /// Button Continue is pressed.
        /// </summary>
        Continue = 11
    }
}