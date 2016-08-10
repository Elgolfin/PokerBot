using System.Collections.Generic;
using Xunit;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    
    public class OnePairUnitTests
    {
        [Fact]
        public void OnePairUnitTests_1()
        {
            var onePairHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0000000002221111, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/10 0010.0010 000/1.0001 0001.0001
            };

            var pht = new OnePair();

            foreach (var hand in onePairHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.True(pht.Parse(ph), hand.Value);
                Assert.Equal(PokerHandAnalyzer.Strength.OnePair, ph.Strength);
            }
        }
    }
}
