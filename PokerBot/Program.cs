using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryOperations.GenerateAllCombinations(8,2);
            Console.ReadKey();
        }
    }
}
