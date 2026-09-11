using System.Numerics;

namespace System32.BitOperations.Internal
{
    internal interface IBitCore
    {
        T ChangeBitAtCore<T>(T number, int bitPosition, BitState bitState) where T : IBinaryInteger<T>;
        T InvertAllBitsCore<T>(T number) where T : IBinaryInteger<T>;
        T SetAllBits<T>(T number, BitState bitState) where T : IBinaryInteger<T>;
    }
}
