﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    // TODO add more unit tests when dealing hands (by comparing the first deck card with the first card of the first player to have been dealed
    // Table of 2, Table of 3, Table of 6 with some empty seats, etc.
    [TestClass]
    public class DealerUnitTests
    {
        [TestMethod]
        public void Dealer_Deals_Hands_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.ShuffleDeck();
            var firstDealedCard = table.Dealer.Deck.GetCards()[0];
            var lastDealedCard = table.Dealer.Deck.GetCards()[17];
            table.Dealer.DealHands();
            Assert.AreEqual(52 - 9 * 2, table.Dealer.Deck.GetCards().Count);
            for (int i = 0; i < table.NumberOfPlayers; i++)
            {
                Assert.AreEqual(true, table.Seats[i].Hand.FirstCard != null);
                Assert.AreEqual(true, table.Seats[i].Hand.SecondCard != null);
            }
            Assert.AreEqual(table.Seats[table.FirstToPlay].Hand.FirstCard, firstDealedCard);
            Assert.AreEqual(table.Seats[table.BigBlindPosition].Hand.SecondCard, lastDealedCard);
        }

        [TestMethod]
        public void Dealer_Deals_Flop_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            Assert.AreEqual(52 - 9 * 2 - 4, table.Dealer.Deck.GetCards().Count);
        }

        [TestMethod]
        public void Dealer_Deals_Turn_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            table.Dealer.DealTurn();
            Assert.AreEqual(52 - 9 * 2 - 4 - 2, table.Dealer.Deck.GetCards().Count);
        }

        [TestMethod]
        public void Dealer_Deals_River_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            table.Dealer.DealTurn();
            table.Dealer.DealRiver();
            Assert.AreEqual(52 - 9 * 2 - 4 - 2 - 2, table.Dealer.Deck.GetCards().Count);
        }
    }
}
