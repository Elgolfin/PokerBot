using Xunit;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    
    public class SeatUnitTests
    {
        [Fact]
        public void Seat_Initialize()
        {
            var seat = new Seat(12, new Player { Name = "John Doe" });
            Assert.Equal("John Doe", seat.Player.Name);
            Assert.Equal(12, seat.Number);
            Assert.Equal(false, seat.IsEmpty);
        }

        [Fact]
        public void Seat_RemovePlayer_Seat_Is_Empty()
        {
            var seat = new Seat(12, new Player { Name = "John Doe" });
            Assert.Equal(false, seat.IsEmpty);
            seat.RemovePlayer();
            Assert.Equal(true, seat.IsEmpty);
        }
    }
}
