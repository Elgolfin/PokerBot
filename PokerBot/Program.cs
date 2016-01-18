using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards.Helper;
using Nicomputer.PokerBot.Cards;
using System.IO;

namespace Nicomputer.PokerBot
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //GenerateAllHandsInAFile(2);
            var totalCombinations = BinaryOperations.GetNumberOfCombinations(13UL, 2UL);
            Console.WriteLine(String.Format("Done. {0} combinations have been generated.", totalCombinations));
            //FindAllStraightFlush();
            Console.ReadKey();
        }

        private static void GenerateAllHandsInAFile(int combinations)
        {
            int num = GenerateAllCombinations(52, combinations);
            Console.WriteLine(String.Empty);
            Console.WriteLine($"Done. {num} combinations have been generated.");
        }

        private static void FindAllStraightFlush()
        {
            var num = 0;
            using (var sr = new StreamReader(@"poker-all-7-hands.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    var hand = Convert.ToInt64(sr.ReadLine());
                    if (CardsAnalyzer.IsStraightFlush(hand))
                    {
                        num++;
                    }
                }
            }
            Console.WriteLine($"Done. {num} straight flush have been found.");
        }

        public static int GenerateAllCombinations(int numCards, int combinations)
        {
            var mask = new MaskBits(numCards, combinations);
            var totalCombinations = BinaryOperations.GetNumberOfCombinations(52ul, 7ul);
            var numCombinations = 0;
            using (var file = new StreamWriter(@"poker-all-"+combinations+"-hands.txt"))
            {
                while (!mask.IsParsingComplete)
                {
                    file.WriteLine(mask.ToUint64());
                    mask.Decrement();
                    numCombinations++;
                    ConsoleHelper.DrawProgressBar(numCombinations, totalCombinations);
                }
            }
            return numCombinations;
        }

    }
}
