namespace System32.BitOperations.Internal
{
    internal static class BitFactory
    {
        internal static IBitCore CreateBitManager()
            => new BitCore();
    }
}