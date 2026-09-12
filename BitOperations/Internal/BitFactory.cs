namespace System32.BitOperations.Internal
{
    internal static class BitFactory
    {
        public static IBitCore CreateManager()
            => new BitCore();
    }
}