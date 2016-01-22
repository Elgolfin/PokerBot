using System;
using System.CodeDom;
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
            Assert.AreEqual(0, table.NumberOfOccupiedSeats);
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
            Assert.AreEqual(2, table.NumberOfOccupiedSeats);
            Assert.AreEqual(2, table.NumberOfPlayers);
            table.AddPlayer(new Player { Name = "Miles Starck" });
            Assert.AreEqual(3, table.NumberOfOccupiedSeats);
            Assert.AreEqual(3, table.NumberOfPlayers);
        }
        [TestMethod]
        [TestCategory("Table - Get Empty Seat")]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Table_Full_AddPlayer_Is_Not_Ok()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            Assert.AreEqual(9, table.NumberOfOccupiedSeats);
            Assert.AreEqual(9, table.NumberOfPlayers);
            table.AddPlayer(new Player { Name = "Miles Starck" });
        }

        

        private void AssertTableHasProperlyBeenOpened(Table table, int capacity, int numOfPlayers)
        {
            Assert.AreEqual(capacity, table.Capacity);
            Assert.AreEqual(numOfPlayers, table.NumberOfPlayers);
            Assert.AreEqual(numOfPlayers, table.NumberOfOccupiedSeats);
            Assert.AreEqual(capacity, table.Seats.Count);
            Assert.AreEqual(true, table.Dealer != null);
            Assert.AreEqual(true, table.IsOpened);
            Assert.AreEqual(0, table.Board.Count);
            Assert.AreEqual(1, table.Turn);
        }


        [TestMethod]
        [TestCategory("Table - Positions")]
        public void OccupiedSeats_Table_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            var occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            Assert.AreEqual(9, occupiedSeats.Count);
            var firstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var firstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.AreEqual(firstToPlayPreFlop, occupiedSeats[0].Player);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            Assert.AreEqual(firstToPlayPostFlop, occupiedSeats[0].Player);
            table.UpdatePositions();
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var nextFirstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var nextFirstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.AreEqual(nextFirstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.AreNotEqual(firstToPlayPreFlop, nextFirstToPlayPreFlop);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            Assert.AreEqual(nextFirstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.AreNotEqual(firstToPlayPostFlop, nextFirstToPlayPostFlop);
        }


        [TestMethod]
        [TestCategory("Table - Positions")]
        public void OccupiedSeats_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);

            var occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var queue = table.GetQueueOfSeatsOrderByPlayPreFlop();
            Assert.AreEqual(2, occupiedSeats.Count);
            var firstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var firstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.AreEqual(firstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.AreEqual(firstToPlayPreFlop, queue.Dequeue().Player);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            queue = table.GetQueueOfSeatsOrderByPlayPostFlop();
            Assert.AreEqual(firstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.AreEqual(firstToPlayPostFlop, queue.Dequeue().Player);

            table.UpdatePositions();

            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var nextFirstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var nextFirstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.AreEqual(nextFirstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.AreEqual(firstToPlayPreFlop, queue.Dequeue().Player);
            Assert.AreNotEqual(firstToPlayPreFlop, nextFirstToPlayPreFlop);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            queue = table.GetQueueOfSeatsOrderByPlayPostFlop();
            Assert.AreEqual(nextFirstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.AreEqual(nextFirstToPlayPostFlop, queue.Dequeue().Player);
            Assert.AreNotEqual(firstToPlayPostFlop, nextFirstToPlayPostFlop);
        }
    }
}