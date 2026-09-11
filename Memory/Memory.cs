using System32.Memory.Internal;

namespace System32.Memory
{
    /// <summary>
    ///  Provides static methods for allocating, releasing and etc.. of block of memory.
    /// </summary>
    public static class Memory
    {
        #region Private Fields

        // Internal memory object.
        private static readonly IMemoryCore s_MemoryCore;

        #endregion
        #region Constructor

        static Memory()
        {
            s_MemoryCore = MemoryConstructor.CreateMemory();
        }

        #endregion
        #region Functionality

        /// <summary>
        ///  Allocates block of memory with specified length(<paramref name="bytesCount"/>)
        ///  and returns pointer to the first byte. The pointer is converted as nint.
        /// </summary>
        /// <param name="bytesCount">
        ///  The count of the bytes to allocate.
        /// </param>
        /// <returns>
        ///  Pointer to the first byte of the allocated memory block.
        /// </returns>
        public static nint Allocate(uint bytesCount)
            => s_MemoryCore.AllocateCore(bytesCount);

        /// <summary>
        ///  Resizes the block of memory specified with <paramref name="memoryPointer"/>
        ///  and move its to another place in the memory if needed.
        /// </summary>
        /// <param name="memoryPointer">
        ///  The pointer to the memory to resize and optionally reallocate.
        /// </param>
        /// <param name="newSizeInBytes">
        ///  The new size of the memory block in bytes.
        /// </param>
        /// <returns>
        ///  Pointer to the first byte of the resized block.
        ///  If the memory block is not reallocated, only resized, 
        ///  the address is still the same.
        /// </returns>
        public static nint Reallocate(nint memoryPointer, uint newSizeInBytes)
            => s_MemoryCore.ReallocateCore(memoryPointer, newSizeInBytes);

        /// <summary>
        ///  Releases the memory used by the specified object.
        /// </summary>
        /// <param name="dynamicObject">
        ///  The memory to release
        /// </param>
        public static void Free(nint dynamicObject)
            => s_MemoryCore.FreeCore(dynamicObject);

        #endregion
    }
}