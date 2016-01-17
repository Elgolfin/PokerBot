using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Common
{
    public class PokerGameUnitTestsHelper
    {
        /// <summary>
        /// Create a table of capacity with numOfPlayers actual players
        /// Open the table with a dealer
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="numOfPlayers"></param>
        /// <returns></returns>
        public static Table CreateAndOpenTable(int capacity, int numOfPlayers)
        {
            var table = new Table(capacity);
            Player[] players =
            {
                new Player("John Doe") ,
                new Player("Lori White"),
                new Player("Steve Bennett"),
                new Player("Dennis Rogers"),
                new Player("Billy King"),
                new Player("Jonathan Wood"),
                new Player("Harry Brooks"),
                new Player("Jesse Patterson"),
                new Player("Frank Evans")
            };
            for (int i = 0; i < numOfPlayers; i++)
            {
                table.AddPlayer(players[i]);
            }
            var dealer = new Dealer(table, new Deck52Cards());
            table.Open(dealer);

            return table;
        }
    }
}
