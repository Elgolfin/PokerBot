using System;
using System.Collections.Generic;
using Xunit;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    
    public class FullHouseUnitTests
    {
        [Fact]
        public void FullHouseUnitTests_1()
        {
            var fullHouseHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/0000 0000.0000 0/100.0000 0000.00/10 0000.0000 001/1.0001 0001.0001
                {0x0000004002003111, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/100.0000 0000.00/10 0000.0000 001/1.0001 0001.0001
            };

            var pht = new FullHouse();

            foreach (var hand in fullHouseHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.True(pht.Parse(ph), hand.Value);
                Assert.Equal(PokerHandAnalyzer.Strength.FullHouse, ph.Strength);
            }
        }
    }
}
