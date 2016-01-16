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
        public void Dealer_Deals_Hands()
        {
            var table = new Table(9);
            table.Players.Add(new Player("John Doe"));
            table.Players.Add(new Player("Lori White"));
            table.Players.Add(new Player("Steve Bennett"));
            table.Players.Add(new Player("Dennis Rogers"));
            table.Players.Add(new Player("Billy King"));
            table.Players.Add(new Player("Jonathan Wood"));
            table.Players.Add(new Player("Harry Brooks"));
            table.Players.Add(new Player("Jesse Patterson"));
            table.Players.Add(new Player("Frank Evans"));
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
