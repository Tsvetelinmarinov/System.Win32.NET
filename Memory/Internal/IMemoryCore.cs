namespace System32.Memory.Internal
{
    //
    // Defines memory core functionality.
    //
    internal interface IMemoryCore
    {
        void FreeCore(nint dynamicObject);
        nint AllocateCore(uint bytesCount);
        nint ReallocateCore(nint memoryPointer, uint newSizeInBytes);
    }
}
