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
            //ulong mask = SetBitsFromToRight(maxBits + 1, combinations);

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
        

    }
}
