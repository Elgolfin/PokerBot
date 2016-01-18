using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    [TestClass]
    public class PlayerUnitTests
    {
        [TestMethod]
        public void Player_Constructor()
        {
            var player = new Player
            {
                Name = "John Doe",
                DisplayName = "Johnny",
                NickName = "Connor"
            };
            Assert.AreEqual("John Doe", player.Name);
            Assert.AreEqual("Johnny", player.DisplayName);
            Assert.AreEqual("Connor", player.NickName);
        }
    }
}
