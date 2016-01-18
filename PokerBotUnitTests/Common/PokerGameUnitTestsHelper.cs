using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Common
{
    public static class PokerGameUnitTestsHelper
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
                new Player {Name = "John Doe"} ,
                new Player {Name = "Lori White"},
                new Player {Name = "Steve Bennett"},
                new Player {Name = "Dennis Rogers"},
                new Player {Name = "Billy King"},
                new Player {Name = "Jonathan Wood"},
                new Player {Name = "Harry Brooks"},
                new Player {Name = "Jesse Patterson"},
                new Player {Name = "Frank Evans"}
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
