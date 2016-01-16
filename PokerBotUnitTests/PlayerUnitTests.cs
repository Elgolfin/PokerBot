using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class PlayerUnitTests
    {
        [TestMethod]
        public void Player_Constructor()
        {
            var player = new Player("John Doe");
            player.DisplayName = "Johnny";
            player.NickName = "Connor";
            Assert.AreEqual("John Doe", player.Name);
            Assert.AreEqual("Johnny", player.DisplayName);
            Assert.AreEqual("Connor", player.NickName);
        }
    }
}
