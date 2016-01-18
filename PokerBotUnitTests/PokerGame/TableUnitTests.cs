using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    [TestClass]
    public class TableUnitTests
    {
        [TestMethod][TestCategory("Table - Open")]
        public void OpenTable_Of_9_With_9_Players()
        {
            var table =  PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            AssertTableHasProperlyBeenOpened(table, 9, 9);
        }

        [TestMethod]
        [TestCategory("Table - Open")]
        public void OpenTable_Of_9_With_7_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 7);
            AssertTableHasProperlyBeenOpened(table, 9, 7);
        }

        [TestMethod]
        [TestCategory("Table - Open")]
        public void OpenTable_Of_9_With_0_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 0);
            AssertTableHasProperlyBeenOpened(table, 9, 0);
        }

        [TestMethod]
        [TestCategory("Table - Close")]
        public void CloseTable_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Close();
            Assert.AreEqual(9, table.Capacity);
            Assert.AreEqual(0, table.NumberOfPlayers);
            Assert.AreEqual(0, table.OccupiedSeats);
            Assert.AreEqual(9, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer == null);
            Assert.AreEqual(false, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
        }

        [TestMethod]
        [TestCategory("Table - Positions")]
        public void InitialPositions_Table_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            Assert.AreEqual(0, table.ButtonPosition);
            Assert.AreEqual(1, table.SmallBlindPosition);
            Assert.AreEqual(2, table.BigBlindPosition);
        }

        [TestMethod]
        [TestCategory("Table - Positions")]
        public void InitialPositions_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.AreEqual(0, table.ButtonPosition);
            Assert.AreEqual(0, table.SmallBlindPosition);
            Assert.AreEqual(1, table.BigBlindPosition);
        }

        [TestMethod]
        [TestCategory("Table - Positions")]
        public void UpdatePositions_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.AreEqual(0, table.ButtonPosition);
            Assert.AreEqual(0, table.SmallBlindPosition);
            Assert.AreEqual(1, table.BigBlindPosition);
            table.UpdatePositions();
            Assert.AreEqual(1, table.ButtonPosition);
            Assert.AreEqual(1, table.SmallBlindPosition);
            Assert.AreEqual(0, table.BigBlindPosition);
        }



        [TestMethod]
        [TestCategory("Table - Get Empty Seat")]
        public void Table_WithEmptySeat_AddPlayer_Is_Ok()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.AreEqual(2, table.OccupiedSeats);
            Assert.AreEqual(2, table.NumberOfPlayers);
            table.AddPlayer(new Player { Name = "Miles Starck" });
            Assert.AreEqual(3, table.OccupiedSeats);
            Assert.AreEqual(3, table.NumberOfPlayers);
        }
        [TestMethod]
        [TestCategory("Table - Get Empty Seat")]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Table_Full_AddPlayer_Is_Not_Ok()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            Assert.AreEqual(9, table.OccupiedSeats);
            Assert.AreEqual(9, table.NumberOfPlayers);
            table.AddPlayer(new Player { Name = "Miles Starck" });
        }

        

        private void AssertTableHasProperlyBeenOpened(Table table, int capacity, int numOfPlayers)
        {
            Assert.AreEqual(capacity, table.Capacity);
            Assert.AreEqual(numOfPlayers, table.NumberOfPlayers);
            Assert.AreEqual(numOfPlayers, table.OccupiedSeats);
            Assert.AreEqual(capacity, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer != null);
            Assert.AreEqual(true, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
            Assert.AreEqual(1, table.Turn);
        }
    }
}