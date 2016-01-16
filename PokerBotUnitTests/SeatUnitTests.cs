using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class SeatUnitTests
    {
        [TestMethod]
        public void Seat_Initialize()
        {
            var seat = new Seat(12, new Player("John Doe"));
            Assert.AreEqual("John Doe", seat.Player.Name);
            Assert.AreEqual(12, seat.Number);
            Assert.AreEqual(false, seat.IsEmpty);
        }

        [TestMethod]
        public void Seat_RemovePlayer_Seat_Is_Empty()
        {
            var seat = new Seat(12, new Player("John Doe"));
            Assert.AreEqual(false, seat.IsEmpty);
            seat.RemovePlayer();
            Assert.AreEqual(true, seat.IsEmpty);
        }
    }
}
