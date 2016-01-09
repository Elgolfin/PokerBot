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
    public class Program
    {
        public static void Main(string[] args)
        {
            GenerateAllHandsInAFile(2); 
            //FindAllStraightFlush();
            Console.ReadKey();
        }

        private static void GenerateAllHandsInAFile(int combinations)
        {
            int num = GenerateAllCombinations(52, combinations);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Format("Done. {0} combinations have been generated.", num));
        }

        private static void FindAllStraightFlush()
        {
            int num = 0;
            using (StreamReader sr = new StreamReader(@"poker-all-7-hands.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    long hand = Convert.ToInt64(sr.ReadLine());
                    if (CardsAnalyzer.IsStraightFlush(hand))
                    {
                        num++;
                    }
                }
            }
            Console.WriteLine(String.Format("Done. {0} straight flush have been found.", num));
        }

        public static int GenerateAllCombinations(int numCards, int combinations)
        {
            MaskBits mask = new MaskBits(numCards, combinations);
            int totalCombinations = BinaryOperations.GetNumberOfCombinations(52ul, 7ul);
            int numCombinations = 0;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"poker-all-"+combinations+"-hands.txt"))
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
