using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class TableUnitTests
    {
        [TestMethod]
        [TestCategory("Table")][Ignore]
        public void NewTable_Of_9()
        {
            int numberOfSeats = 9;
            Table table = new Table(numberOfSeats);
            Dealer dealer = new Dealer(table, new Deck52Cards());
            Assert.AreEqual(numberOfSeats, table.Seats.Count);
        }
    }
}
