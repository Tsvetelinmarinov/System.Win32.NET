namespace System32.Memory.Internal
{
    //
    // Constructs MemoryCore object and returns it as IMemoryCore.
    //
    internal static class MemoryConstructor
    {
        internal static IMemoryCore CreateMemory()
            => new MemoryCore();
    }
}