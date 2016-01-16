using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class DealerUnitTests
    {
        [TestMethod]
        public void Dealer_Deals_Hands_Table_Full()
        {
            var table = new Table(9);
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
            for (int i = 0; i < 9; i++)
            {
                table.AddPlayer(players[i]);
            }
            var deck = new Deck52Cards();
            var dealer = new Dealer(table, deck);
            table.Open(dealer);
            dealer.DealHands();
            Assert.AreEqual(52 - 9 * 2, deck.GetCards().Count);
            for (int i = 0; i < table.NumberOfPlayers; i++)
            {
                Assert.AreEqual(true, table.Seats[i].Hand.FirstCard != null);
                Assert.AreEqual(true, table.Seats[i].Hand.SecondCard != null);
            }
        }
    }
}
