using System;
using Xunit;
using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    
    public class HandPlayEngineUnitTests
    {
        [Fact]
        [Trait("Category", "Hand Play Engine")]
        public void Table_Is_Not_Opened()
        {
            var table = new Table(9);
            Assert.Throws<InvalidOperationException>(() => new HandPlayEngine(table));
        }

        [Fact]
        [Trait("Category", "Hand Play Engine")]
        public void Table_Is_Opened()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            var hpEngine = new HandPlayEngine(table);
            Assert.Equal(1, table.Turn);
            hpEngine.Run();
            Assert.Equal(2, table.Turn);
            Assert.Equal(0, table.ButtonPosition);
            Assert.Equal(1, table.SmallBlindPosition);
            Assert.Equal(2, table.BigBlindPosition);
            AssertWinners(hpEngine);
            hpEngine.Run();
            Assert.Equal(3, table.Turn);
            Assert.Equal(1, table.ButtonPosition);
            Assert.Equal(2, table.SmallBlindPosition);
            Assert.Equal(3, table.BigBlindPosition);
            AssertWinners(hpEngine);
        }

        private void AssertWinners(HandPlayEngine hpEngine)
        {
            var previousStrength = 0;
            foreach (var ph in hpEngine.LastHandResults.Values)
            {
                if (previousStrength == 0)
                {
                    previousStrength = (int)ph.Strength;
                    continue;
                }
                var currentStrength = (int) ph.Strength;
                Assert.True(currentStrength >= previousStrength);
            }
        }
    }
}
