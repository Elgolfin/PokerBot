using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Helper
{
    public static class BinaryOperations
    {

        public static int GenerateAllCombinations (int maxBits, int combinations)
        {
            
            ulong from = SetBitsFromToLeft(maxBits, combinations);
            ulong to = SetBitsFromToRight(1, combinations);
            ulong leftMask = SetBitsFromToRight(maxBits + 1, 64 - maxBits + 1);
            ulong currentFromMask = leftMask & 0x0;
            ulong[] origShiftingMaskBits = GetCombinationsMaskBits(8, 2); // We will use this array to handle the shifting of the bits
            ulong[] actualShiftingMaskBits;

            //int actualBitShifting;
            // shifting logic : lower bit done shifting, then shift one parent of lower bit and reset lower bit shifting (minus 1)
            // higher bit done shifting = end;
            int numCombinations = 1;
            while (from != to)
            {
                from >>= 1;
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
            for (int i = 1; i < bitNumber; i++)
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
            ulong mask;
            // Find the bit number where to start the sequence
            for (int i = 1; i < bitNumber; i++)
            {
                result <<= 1;
            }
            mask = result;
            for (int i = 1; i < n; i++)
            {
                result <<= 1;
                result |= mask;
            }

            return result;
        }

        /// <summary>
        /// Gets the complement of the starting binary sequence
        /// </summary>
        /// <param name="getFrom"></param>
        /// <returns></returns>
        public static ulong GetMask(ulong getFrom)
        {
            return ~getFrom;
        }

        /// <summary>
        /// Return the number of possible k combinations from a set of n elements
        /// Result = n! / (k!(n-k)!)
        /// </summary>
        /// <param name="n">The number of element in the set</param>
        /// <param name="k">The number of combinations</param>
        public static ulong GetNumberOfCombinations (ulong n, ulong k) {

            ulong numerator = 1;
            for (ulong i = n; i > n - k; i--)
            {
                numerator *= i; 
            }

            ulong denominator = 1;
            for (ulong i = k; i >= 1 ; i--)
            {
                denominator *= i;
            }

            return numerator / denominator;
        }


        public static ulong[] GetCombinationsMaskBits(int maxBits, int combinations)
        {
            ulong[] maskBits = new ulong[64];
            Array.Resize(ref maskBits, combinations);
            for (int i = 0; i < combinations; i++)
            {
                maskBits[i] = Convert.ToUInt64(Math.Pow(Convert.ToDouble(2), (Convert.ToDouble(maxBits) - Convert.ToDouble(i) - Convert.ToDouble(1))));
            }
            return maskBits.Reverse().ToArray();
        }

        public static void ResetMaskBits (ref ulong[] maskBits)
        {
            int index = 0;
            while (index < maskBits.Length)
            {
                //maskBits[index] = 
            }
        }

    }

    public class MaskBits
    {
        private ulong[] _mask;
        public ulong[] Mask
        {
            get
            {
                return _mask.Reverse().ToArray();
            }
            protected set { }
        }
        private int _maxBits = 52;
        private int _combinations = 7;

        private int _actuaIndex = 0;

        public MaskBits (int maxBits, int combinations)
        {
            _mask = new ulong[64];
            _maxBits = maxBits;
            _combinations = combinations;
            Array.Resize(ref _mask, combinations);
            for (int i = 0; i < combinations; i++)
            {
                _mask[i] = Convert.ToUInt64(Math.Pow(Convert.ToDouble(2), (Convert.ToDouble(maxBits) - Convert.ToDouble(i) - Convert.ToDouble(1))));
            }
        }

        // TODO Unit test decrement
        public void Decrement()
        {
            if (_mask[_actuaIndex] - 1 == Convert.ToUInt64(_actuaIndex))
            {
                _actuaIndex++;
                Decrement();
            } else
            {
                _mask[_actuaIndex]--;
                _mask[_actuaIndex - 1] = _mask[_actuaIndex] - 1;
            }
        }

        public override bool Equals(object obj)
        {
            ulong[] array = obj as ulong[];
            if (array == null) { return false; }
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

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }
    }
}
