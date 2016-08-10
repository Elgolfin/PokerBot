using Xunit;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    
    public class PlayerUnitTests
    {
        [Fact]
        public void Player_Constructor()
        {
            var player = new Player
            {
                Name = "John Doe",
                DisplayName = "Johnny",
                NickName = "Connor"
            };
            Assert.Equal("John Doe", player.Name);
            Assert.Equal("Johnny", player.DisplayName);
            Assert.Equal("Connor", player.NickName);
            Assert.Equal(player.Name, player.ToString());
        }
    }
}
