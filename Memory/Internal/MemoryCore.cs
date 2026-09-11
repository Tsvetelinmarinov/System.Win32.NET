using System32.Interoperability.PlatformAbstractionLayer;

namespace System32.Memory.Internal
{
    //
    // Implements IMemoryCore and communicates with the PAL.
    // Provides base functionality for System32.Memory.Memory.cs class.
    //
    internal class MemoryCore : IMemoryCore
    {
        internal MemoryCore()
        {
        }

        public nint AllocateCore(uint bytesCount)
            => MemoryPAL.AllocatePAL(bytesCount);
        public void FreeCore(nint dynamicObject)
            => MemoryPAL.FreePAL(dynamicObject);
        public nint ReallocateCore(nint memoryPointer, uint newSizeInBytes)
            => MemoryPAL.HeapReAllocPAL(memoryPointer, newSizeInBytes);
    }
}