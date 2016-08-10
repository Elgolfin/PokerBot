using System;
using System.Collections.Generic;
using Xunit;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    
    public class HighCardUnitTests
    {
        [Fact]
        public void HighCardUnitTests_1()
        {
            var highCardsHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0000000000445111L, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0100.0100 010/1.0001 0001.0001
            };

            var pht = new HighCard();

            foreach (var hand in highCardsHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.True(pht.Parse(ph), hand.Value);
                Assert.Equal(PokerHandAnalyzer.Strength.HighCard, ph.Strength);
            }
        }
    }
}
