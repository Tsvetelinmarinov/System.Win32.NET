using System.Numerics;
using System32.Interoperability.Helpers;

namespace System32.BitOperations.Internal
{
    internal class BitCore : IBitCore
    {
        internal BitCore()
        {
        }


        public IntType ChangeBitAtCore<IntType>(IntType number, int bitPosition, BitState bitState)
            where IntType : IBinaryInteger<IntType>              
        {
            if (Convert.ToInt32(bitPosition) < 0)
            {
                throw new ArgumentException(Errors.InvalidBitPosition, nameof(bitPosition));
            }

            /* EN Comment:
            * 
            * |----------------------------- Bit manipulation example -----------------------------|
            * 
            * Changing a bit at specified position is possible when we make mask(number) with 1 at that position
            * where we want to change the bit in the other number. All other bits of the mask are 0.
            * 
            * The tree different bitwise operations works as follows:
            *  Bitwise OR(|)  - Used to turn a bit on.
            *  Bitwise AND(&) - Used to turn a bit off.
            *  Bitwise XOR(^) - Used to switch the state of a bit.
            *  
            * Complete explanation bellow -->
            * 
            * Changing bit N to 1:
            *  N = 2
            *  00001001 ==> Changing the third bit(current is 0) to 1:
            *      00001001 
            *              | -> Bitwise OR operation.
            *      00000100  -> (1 << N(2)) - That will change the third bit to 1(if its zero) and will left
            *                   others not changed, because the operation is OR(|).
            *                              
            *      00001101 -> In the result the third bit now is 1, because OR(|) operation will return true(1 here)
            *                  only if one of both bits(of the number and the mask) are with value 1 or 0 or both are 1.
            *                  
            * Changing bit N to 0:
            *  N = 3
            *      00001001 => Changing the fourth bit to 0(current is 1).
            *          00001001
            *                  & -> Bitwise AND operation.
            *          11110111  -> ~(1 << N(3)) - Inverted mask, so all the bits will remain same
            *                       except that one that is at that place when is the 0
            *                       in the mask. That bit will accept value 0, because operation
            *                       AND(&) returns true(1 here) only if both 
            *                       bits(of the number and of the mask) are with value 1.
            *                                      
            *          00000001  -> The bit of position 3(right - left) is now 0(previously was 1).
            *          
            * Switching bit N - if 0 -> 1 and if 1 -> 0:
            *  N = 1
            *      00000101 => Switching the second bit(current is 0).
            *          00000101
            *                  ^ -> Bitwise XOR operation.
            *          00000010  -> (1 << N(1)) - That with switch the state of the second bit, because
            *                       operation XOR(^) return true only if both bits(of the number and the mask)
            *                       are with different values(0 or 1). If they both are 0 or 1 will return false(0 here).
            *          00000111  -> The second bit now is 1.
            *      
            *          00000111 => Switching again the second bit to turn it back to 0.
            *                  ^
            *          00000010
            *          00000101  -> The second bit again is 0.
            */
            /* BG Коментар:
            *
            * |---------------------------- Пример за манипулиране на битове -----------------------------|
            *
            * Промяната на бит на определена позиция е възможна, когато създадем маска(число) с 1 на тази позиция,
            * на която искаме да променим бита в другото число. Всички останали битове на маската са 0.
            *
            * Четирите различни битови операции, който са използвани тук, са следните:
            *  Побитово Инвертиране(~) - Използва се за инвертиране на всички битове на число.
            *  Побитово ИЛИ(|) - Използва се за включване на бит.
            *  Побитово И(&) - Използва се за изключване на бит.
            *  Побитово Изключващо ИЛИ(^) - Използва се за превключване на състоянието на бит.
            *
            * Пълно обяснение -->
            *
            * Промяна на бит N на 1:
            * N = 2
            *  00001001 ==> Промяна на третия бит (текущият е 0) на 1:
            *  00001001
            *          | -> Побитова ИЛИ операция.
            *  00000100  -> (1 << N) - Това ще промени третия бит на 1 (ако е нула) и ще остави
            *                          останалите непроменени, защото операцията е OR(|).
            *
            *  00001101 -> В резултатa третият бит сега е 1, защото операцията OR(|) ще върне true(1 тук)
            *              само ако един от двата бита (на числото или на маската) е със стойност 1 или 0, или и двата са 1.
            *
            * Промяна на бит N на 0:
            * N = 3
            *  00001001 => Промяна на четвъртия бит на 0 (текущата стойност е 1).
            *  00001001
            *          & -> Побитово И.
            *  11110111  -> ~(1 << N) - Инвертирана маска, така че всички битове ще останат същите
            *                           с изключение на този, който е на това място, където е 0
            *                           в маската. Този бит ще приеме стойност 0, защото операцията
            *                           AND(&) връща true (1 тук) само ако и двата
            *                           бита (на числото и на маската) са със стойност 1.
            *
            * 00000001 -> Битът на позиция 3 (дясно - ляво) вече е 0 (преди беше 1).
            *
            * Превключване на бит N - ако е 0 -> 1 и ако е 1 -> 0:
            * N = 1
            *  00000101 => Превключване на втория бит (текущата стойност е 0).
            *  00000101
            *          ^ -> Побитова XOR операция.
            *  00000010  -> (1 << N) - Това превключва състоянието на втория бит, защото
            *                          операцията XOR(^) връща true само ако и двата бита (на числото и маската)
            *                          са с различни стойности (0 или 1). Ако и двата са 0 или 1, ще върне false (0 тук).
            *  00000111 -> Вторият бит сега е 1.
            *
            *  00000111 => Превключване отново на втория бит, за да се върне обратно на 0.
            *          ^
            *  00000010
            *  00000101 -> Вторият бит отново е 0.
            */

            if (bitState is BitState.Active)
            {
                return (IntType.One << bitPosition) | number;
            }
            else if (bitState is BitState.Inactive)
            {
                return ~(IntType.One << bitPosition) & number;
            }
            else if (bitState is BitState.Switch)
            {
                return (IntType.One << bitPosition) ^ number;
            }
            else
            {
                throw new InvalidDataException(Errors.UnknownBitState);
            }
        }

        public IntType InvertAllBitsCore<IntType>(IntType number) 
            where IntType : IBinaryInteger<IntType>
            => ~number;

        public IntType SetAllBits<IntType>(IntType number, BitState bitState)
            where IntType : IBinaryInteger<IntType>
        {
            if (bitState is BitState.Inactive)
            {
                return IntType.Zero;
            }
            else if (bitState is BitState.Active)
            {
                return ~IntType.Zero;
            }
            else
            {
                throw new InvalidDataException(Errors.UnknownBitState);
            }
        }
    }
}