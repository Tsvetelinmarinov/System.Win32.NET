using System32.Interoperability.Helpers;
using System32.Interoperability.InternalServices;

namespace System32.Interoperability.PlatformAbstractionLayer
{
    //
    // Communicates with Memory_WIN32_InteropService.
    // Provides core functionality for System32.Memory.Memory.cs class.
    //
    internal static class MemoryPAL
    {
        // Encapsulates safety the call to the unmanaged C function HeapAlloc.
        internal static nint AllocatePAL(uint bytesCount)
        {
            // Check the OS.
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            // Validate that byte count is positive integer.
            if (bytesCount <= 0)
            {
                throw new InvalidOperationException(Errors.InvalidBytesCount);
            }

            unsafe
            {
                // Get pointer to the current process stack.
                void* currProcStackPtr = Memory_WIN32_InteropService.GetProcessHeap();

                if (currProcStackPtr is null)
                {
                    throw new SystemException(Errors.NullProcessStackPointer);
                }

                void* allocatedMemoryPtr = Memory_WIN32_InteropService.HeapAlloc(
                    currProcStackPtr,
                    MemoryAllocationType.InitializeWithZeros,
                    (uint*)bytesCount
                );

                if (allocatedMemoryPtr is null)
                {
                    throw new SystemException(Errors.AllocatedMemoryIsNull);
                }

                return (nint)allocatedMemoryPtr;
            }
        }
        
        // Encapsulates safety the call to the unmanaged C function HeapFree.
        internal static void FreePAL(nint dynamicObject)
        {
            if (dynamicObject == nint.Zero)
            {
                return; // If null pointer -> do nothing.
            }

            unsafe
            {
                void* currStackPointer = Memory_WIN32_InteropService.GetProcessHeap();

                bool successReleasing = Memory_WIN32_InteropService.HeapFree(
                    currStackPointer,
                    0U,
                    (void*)dynamicObject
                );

                if (successReleasing is false)
                {
                    throw new SystemException(Errors.FreeMemoryError);
                }
            }
        }

        // Encapsulates safety the call to the unmanaged C function HeapReAlloc.
        internal static nint HeapReAllocPAL(
            nint memoryPointer,
            uint newSizeInBytes
        ){
            // Check the OS first.
            if (OperatingSystem.IsWindows() is false)
            {
                throw new PlatformNotSupportedException(Errors.OnlyWin32);
            }

            // Pointer to the new address in the memory.
            // Return value of the method.
            nint newMemAddrPtr = nint.Zero; 

            unsafe
            {
                // Get pointer to the current process heap.
                void* appProcHeapPtr = Memory_WIN32_InteropService.GetProcessHeap();

                // Converting parameters types to C data types.
                void* memPtr = (void*)memoryPointer;
                uint* newLenPtr = (uint*)newSizeInBytes;

                // Check for full validation of the parameters.
                if (appProcHeapPtr is null)
                {
                    throw new SystemException(Errors.NullProcessStackPointer);
                }

                if (memPtr is null)
                {
                    throw new SystemException(Errors.NullMemoryToReallocate);
                }

                if (newLenPtr is null)
                {
                    throw new SystemException(Errors.NullNewSizePointer);
                }

                if (newSizeInBytes < 0)
                {
                    throw new SystemException(Errors.InvalidBytesCount);
                }

                // Resize and reallocate(if needed) the memory.
                newMemAddrPtr = (nint)Memory_WIN32_InteropService.HeapReAlloc(
                    appProcHeapPtr,
                    MemoryAllocationType.ReallocateWithZerosAdded,
                    memPtr,
                    newLenPtr
                );
            }

            if (newMemAddrPtr == nint.Zero)
            {
                throw new SystemException(Errors.NullMemoryAfterReallocation);
            }

            return newMemAddrPtr;
        }
    }
}