namespace System32.Interoperability.Helpers
{
    //
    // Provides common error messages.
    //
    internal static class Errors
    {
        #region Platform Depended

        internal const string OnlyWin32 = "That type is supported only on Windows OS!";
        internal const string PlatformNotSupported = "This type is not supported by the current OS!";

        #endregion
        #region Memory Depended

        internal const string InvalidBytesCount = "PAL: The count of the bytes to allocate should not be negative or zero!";
        internal const string NullProcessStackPointer = "PAL: Function GetProcessHeap() fails and the stack pointer is null!";
        internal const string AllocatedMemoryIsNull = "PAL:The allocated memory is null! Function HeapAlloc() fails!";
        internal const string FreeMemoryError = "PAL: Something went wrong while releasing the memory of the object! HeapFree() fails!";
        internal const string NullMemoryToReallocate = "PAL: The memory to reallocate is null!";
        internal const string NullNewSizePointer = "PAL: The pointer to the new size of the memory block is null!";
        internal const string NullMemoryAfterReallocation = "PAL: Null memory pointer after the reallocation! Function HeapReAlloc() fails!";

        #endregion
        #region Bit Depended

        internal const string InvalidBitPosition = "The position of the bit to change should not be negative!";
        internal const string UnknownBitState = "Unknown bit state!";

        #endregion
    }
}
