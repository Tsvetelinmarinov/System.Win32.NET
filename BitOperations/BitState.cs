namespace System32.BitOperations
{
    /// <summary>
    ///  Describes the state of a bit.
    /// </summary>
    public enum BitState : byte
    {
        /// <summary>
        ///  Specifies that the bit is active.
        /// </summary>
        Active = 0,

        /// <summary>
        ///  Specifies that the bit is inactive.
        /// </summary>
        Inactive = 1,

        /// <summary>
        ///  Specifies that the bit value should be switched.
        /// </summary>
        Switch = 2
    }
}