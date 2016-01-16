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
        public void OpenTable_Of_9_With_9_Players()
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
            var dealer = new Dealer(table, new Deck52Cards());
            table.Open(dealer);
            Assert.AreEqual(9, table.Capacity);
            Assert.AreEqual(9, table.Players.Count);
            Assert.AreEqual(9, table.OccupiedSeats);
            Assert.AreEqual(9, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer != null);
            Assert.AreEqual(true, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
        }

        [TestMethod]
        public void OpenTable_Of_9_With_7_Players()
        {
            var table = new Table(9);
            table.Players.Add(new Player("John Doe"));
            table.Players.Add(new Player("Lori White"));
            table.Players.Add(new Player("Steve Bennett"));
            table.Players.Add(new Player("Dennis Rogers"));
            table.Players.Add(new Player("Billy King"));
            table.Players.Add(new Player("Jonathan Wood"));
            table.Players.Add(new Player("Harry Brooks"));
            var dealer = new Dealer(table, new Deck52Cards());
            table.Open(dealer);
            Assert.AreEqual(9, table.Capacity);
            Assert.AreEqual(7, table.NumberOfPlayers);
            Assert.AreEqual(7, table.OccupiedSeats);
            Assert.AreEqual(9, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer != null);
            Assert.AreEqual(true, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
        }



        [TestMethod]
        public void OpenTable_Of_9_With_0_Players()
        {
            var table = new Table(9);
            var dealer = new Dealer(table, new Deck52Cards());
            table.Open(dealer);
            Assert.AreEqual(9, table.Capacity);
            Assert.AreEqual(0, table.NumberOfPlayers);
            Assert.AreEqual(0, table.OccupiedSeats);
            Assert.AreEqual(9, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer != null);
            Assert.AreEqual(true, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
        }

        [TestMethod]
        public void CloseTable_Of_9_Players()
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
            var dealer = new Dealer(table, new Deck52Cards());
            table.Open(dealer);
            table.Close();
            Assert.AreEqual(9, table.Capacity);
            Assert.AreEqual(0, table.Players.Count);
            Assert.AreEqual(0, table.OccupiedSeats);
            Assert.AreEqual(9, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer == null);
            Assert.AreEqual(false, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
        }
    }
}