namespace System32.Interoperability.Helpers
{
    //
    // Provides constants that specifies how to allocate new block of 
    // memory in the HeapAlloc() C function.
    //
    internal static class MemoryAllocationType
    {
        // Tells HeapAlloc() to initialize the new block of memory with zeros.
        internal const uint InitializeWithZeros = 0x00000008;

        // Tells HeapReAlloc() to resize the block of memory, and if the new size 
        // is bigger that the old, then the new bytes receives values of zero.
        // If there is no enough memory at that place in the memory, the block
        // will be moved to another place.
        internal const uint ReallocateWithZerosAdded = 0x00000008;

        // Tells HeapReAlloc() to resize the block of memory WITHOUT relocating it
        // on other place in the memory -> so the block will be resized only, if there is
        // enough place.
        internal const uint ReallocateWithoutMoving = 0x00000010;
    }
}