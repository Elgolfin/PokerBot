using System;
using System.CodeDom;
using Xunit;
using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    
    public class TableUnitTests
    {
        [Fact][Trait("Category", "Table - Open")]
        public void OpenTable_Of_9_With_9_Players()
        {
            var table =  PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            AssertTableHasProperlyBeenOpened(table, 9, 9);
        }

        [Fact]
        [Trait("Category", "Table - Open")]
        public void OpenTable_Of_9_With_7_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 7);
            AssertTableHasProperlyBeenOpened(table, 9, 7);
        }

        [Fact]
        [Trait("Category", "Table - Open")]
        public void OpenTable_Of_9_With_0_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 0);
            AssertTableHasProperlyBeenOpened(table, 9, 0);
        }

        [Fact]
        [Trait("Category", "Table - Close")]
        public void CloseTable_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Close();
            Assert.Equal(9, table.Capacity);
            Assert.Equal(0, table.NumberOfPlayers);
            Assert.Equal(0, table.NumberOfOccupiedSeats);
            Assert.Equal(9, table.Seats.Count);
            Assert.Equal(true, table.Dealer == null);
            Assert.Equal(false, table.IsOpened);
            Assert.Equal(0, table.Board.Count);
        }

        [Fact]
        [Trait("Category", "Table - Positions")]
        public void InitialPositions_Table_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            Assert.Equal(0, table.ButtonPosition);
            Assert.Equal(1, table.SmallBlindPosition);
            Assert.Equal(2, table.BigBlindPosition);
        }

        [Fact]
        [Trait("Category", "Table - Positions")]
        public void InitialPositions_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.Equal(0, table.ButtonPosition);
            Assert.Equal(0, table.SmallBlindPosition);
            Assert.Equal(1, table.BigBlindPosition);
        }

        [Fact]
        [Trait("Category", "Table - Positions")]
        public void UpdatePositions_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.Equal(0, table.ButtonPosition);
            Assert.Equal(0, table.SmallBlindPosition);
            Assert.Equal(1, table.BigBlindPosition);
            table.UpdatePositions();
            Assert.Equal(1, table.ButtonPosition);
            Assert.Equal(1, table.SmallBlindPosition);
            Assert.Equal(0, table.BigBlindPosition);
        }



        [Fact]
        [Trait("Category", "Table - Get Empty Seat")]
        public void Table_WithEmptySeat_AddPlayer_Is_Ok()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            Assert.Equal(2, table.NumberOfOccupiedSeats);
            Assert.Equal(2, table.NumberOfPlayers);
            table.AddPlayer(new Player { Name = "Miles Starck" });
            Assert.Equal(3, table.NumberOfOccupiedSeats);
            Assert.Equal(3, table.NumberOfPlayers);
        }
        [Fact]
        [Trait("Category", "Table - Get Empty Seat")]
        public void Table_Full_AddPlayer_Is_Not_Ok()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            Assert.Equal(9, table.NumberOfOccupiedSeats);
            Assert.Equal(9, table.NumberOfPlayers);
            Assert.Throws<InvalidOperationException>(() => table.AddPlayer(new Player { Name = "Miles Starck" }));
        }

        

        private void AssertTableHasProperlyBeenOpened(Table table, int capacity, int numOfPlayers)
        {
            Assert.Equal(capacity, table.Capacity);
            Assert.Equal(numOfPlayers, table.NumberOfPlayers);
            Assert.Equal(numOfPlayers, table.NumberOfOccupiedSeats);
            Assert.Equal(capacity, table.Seats.Count);
            Assert.Equal(true, table.Dealer != null);
            Assert.Equal(true, table.IsOpened);
            Assert.Equal(0, table.Board.Count);
            Assert.Equal(1, table.Turn);
        }


        [Fact]
        [Trait("Category", "Table - Positions")]
        public void OccupiedSeats_Table_Of_9_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            var occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            Assert.Equal(9, occupiedSeats.Count);
            var firstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var firstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.Equal(firstToPlayPreFlop, occupiedSeats[0].Player);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            Assert.Equal(firstToPlayPostFlop, occupiedSeats[0].Player);
            table.UpdatePositions();
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var nextFirstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var nextFirstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.Equal(nextFirstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.NotEqual(firstToPlayPreFlop, nextFirstToPlayPreFlop);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            Assert.Equal(nextFirstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.NotEqual(firstToPlayPostFlop, nextFirstToPlayPostFlop);
        }


        [Fact]
        [Trait("Category", "Table - Positions")]
        public void OccupiedSeats_Table_Of_2_Players()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);

            var occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var queue = table.GetQueueOfSeatsOrderByPlayPreFlop();
            Assert.Equal(2, occupiedSeats.Count);
            var firstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var firstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.Equal(firstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.Equal(firstToPlayPreFlop, queue.Dequeue().Player);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            queue = table.GetQueueOfSeatsOrderByPlayPostFlop();
            Assert.Equal(firstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.Equal(firstToPlayPostFlop, queue.Dequeue().Player);

            table.UpdatePositions();

            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPreFlop();
            var nextFirstToPlayPreFlop = table.Seats[table.FirstToPlayPreFlopPosition].Player;
            var nextFirstToPlayPostFlop = table.Seats[table.FirstToPlayPostFlopPosition].Player;
            Assert.Equal(nextFirstToPlayPreFlop, occupiedSeats[0].Player);
            Assert.Equal(firstToPlayPreFlop, queue.Dequeue().Player);
            Assert.NotEqual(firstToPlayPreFlop, nextFirstToPlayPreFlop);
            occupiedSeats = table.GetOccupiedSeatsOrderByPlayPostFlop();
            queue = table.GetQueueOfSeatsOrderByPlayPostFlop();
            Assert.Equal(nextFirstToPlayPostFlop, occupiedSeats[0].Player);
            Assert.Equal(nextFirstToPlayPostFlop, queue.Dequeue().Player);
            Assert.NotEqual(firstToPlayPostFlop, nextFirstToPlayPostFlop);
        }
    }
}