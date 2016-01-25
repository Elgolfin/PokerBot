using System;
using System.Collections.Generic;

namespace Nicomputer.PokerBot.Cards.Helper
{
    public static class BinaryOperations
    {

        public static int GenerateAllCombinations(int maxBits, int combinations)
        {
            var mask = new MaskBits(maxBits, combinations);
            var numCombinations = 0;

            while (!mask.IsParsingComplete)
            {
                mask.Decrement();
                numCombinations++;
            }

            return numCombinations;
        }

        /// <summary>
        /// Set n bits to 1 starting at the bit number bitNumber and going to the left
        /// </summary>
        /// <param name="bitNumber"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ulong SetBitsFromToLeft(int bitNumber, int n)
        {
            ulong result = 0x1;
            ulong mask = 0x1;
            for (var i = 1; i < bitNumber; i++)
            {
                result <<= 1;
                if (i < n)
                {
                    result |= mask;
                }
            }
            return result;
        }/// <summary>
         /// Set n bits to 1 starting at the bit number bitNumber and going to the left
         /// </summary>
         /// <param name="bitNumber"></param>
         /// <param name="n"></param>
         /// <returns></returns>
        public static ulong SetBitsFromToRight(int bitNumber, int n)
        {
            ulong result = 0x1;
            // Find the bit number where to start the sequence
            for (var i = 1; i < bitNumber; i++)
            {
                result <<= 1;
            }
            ulong mask = result;
            for (var i = 1; i < n; i++)
            {
                result <<= 1;
                result |= mask;
            }

            return result;
        }

        /// <summary>
        /// Return the number of possible k combinations from a set of n elements
        /// Result = n! / (k!(n-k)!)
        /// </summary>
        /// <param name="n">The number of element in the set</param>
        /// <param name="k">The number of combinations</param>
        public static int GetNumberOfCombinations (ulong n, ulong k) {

            ulong numerator = 1;
            for (var i = n; i > n - k; i--)
            {
                numerator *= i; 
            }

            ulong denominator = 1;
            for (var i = k; i >= 1 ; i--)
            {
                denominator *= i;
            }

            return Convert.ToInt32(numerator / denominator);
        }

        /// <summary>
        /// i.e. 0101 1100 will become 0011 1010
        /// </summary>
        /// <param name="bitsToReverse"></param>
        /// <returns></returns>
        public static ulong ReverseBits (ulong bitsToReverse)
        {
            ulong reversed = 0x0;
            var original = bitsToReverse;
            const ulong msbMask = 0x8000000000000000;       // msb = MSB = Most Significant Bit                   
            for (var i = 1; i < 64; i++)
            {
                ulong lsbMask = 0x0;                        // lsb = LSB = Least Significant Bit
                if ((original & msbMask) > 0)               // MSB set to 1
                {
                    lsbMask = msbMask;
                }

                reversed = reversed | lsbMask;              // The MSB will become the LSB
                reversed >>= 1;
                original <<= 1;

            }
            return reversed;
        }

        public static long GetTheMostRightSetBit(long bits)
        {
            long mask = 0x1000;
            while (mask > 0)
            {
                if ((mask & bits) > 0)
                {
                    break;
                }
                mask >>= 1;
            }
            return mask;
        }

    }

    public class MaskBits
    {
        private ulong[] _mask;
        public ulong[] Mask
        {
            get
            {
                return _mask;
            }
        }
        private readonly int _maxBits;
        private readonly int _combinations;

        private int _actualIndex;

        public bool IsParsingComplete;

        public MaskBits (int maxBits, int combinations)
        {
            _mask = new ulong[64];
            _maxBits = maxBits;
            _combinations = combinations;
            Initialize();
        }

        private void Initialize()
        {
            Array.Resize(ref _mask, _combinations);
            int j = 0;
            for (int i = _combinations - 1 ; i >= 0; i--)
            {
                _mask[i] = Convert.ToUInt64(Math.Pow(Convert.ToDouble(2), (Convert.ToDouble(_maxBits - 1 - j++))));
            }
        }

        public void Reset()
        {
            Initialize();
        }

        public void Decrement()
        {
            if (_mask[_actualIndex] >> 1 < Convert.ToUInt64(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(_actualIndex))))
            {
                _actualIndex++;
                if (_actualIndex < _mask.Length)
                {
                    Decrement();
                    _mask[_actualIndex - 1] = _mask[_actualIndex] >> 1;
                } else
                {
                    IsParsingComplete = true;
                }
                _actualIndex--;
            } else
            {
                _mask[_actualIndex] >>= 1 ;
            }
        }

        public ulong ToUint64()
        {
            ulong ulMask = 0x0;
            foreach (var ul in _mask)
            {
                ulMask |= ul;
            }
            return ulMask;
        }
        public long ToInt64()
        {
            ulong ulMask = 0x0;
            foreach (var ul in _mask)
            {
                ulMask |= ul;
            }
            return Convert.ToInt64(ulMask);
        }

        public override string ToString()
        {
            return Convert.ToString(Convert.ToInt64(ToUint64()), 2).PadLeft(_maxBits, '0');
        }

        public override bool Equals(object obj)
        {
            ulong[] array = obj as ulong[];
            return ArraysEqual(Mask, array);
        }

        private static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            return ArraysEqualMechanism(a1, a2);

        }

        private static bool ArraysEqualMechanism<T>(T[] a1, T[] a2)
        {
            var comparer = EqualityComparer<T>.Default;
            for (var i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
