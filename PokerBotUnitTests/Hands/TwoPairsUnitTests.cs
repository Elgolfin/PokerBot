using System.Collections.Generic;
using Xunit;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    
    public class TwoPairsUnitTests
    {
        [Fact]
        public void TwoPairsUnitTests_1()
        {
            var twoPairsHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0000000002221121, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/10 0010.0010 000/1.0001 0010.0001
            };

            var pht = new TwoPairs();

            foreach (var hand in twoPairsHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.True(pht.Parse(ph), hand.Value);
                Assert.Equal(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            }
        }

        [Fact]
        public void TwoPairs_With_Kickers_1()
        {
            var pha = new PokerHandAnalyzer();
            var ph = pha.GetPokerHand(new PokerHand(new HoleCards("As", "Ac"), new CardsCollection("Kh Ks 7d 2d Th")));
            Assert.Equal(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            Assert.Equal(3, ph.Kickers.Count);
            Assert.Equal("Ac", ph.Kickers[0].ToString());
            Assert.Equal("Kc", ph.Kickers[1].ToString());
            Assert.Equal("Tc", ph.Kickers[2].ToString());
        }

        //
        [Fact]
        public void TwoPairs_With_Kickers_2()
        {
            var pha = new PokerHandAnalyzer();
            var ph = pha.GetPokerHand(new PokerHand(new HoleCards("Qs", "Qc"), new CardsCollection("Kh Ks 7d Ad Th")));
            Assert.Equal(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            Assert.Equal(3, ph.Kickers.Count);
            Assert.Equal("Kc", ph.Kickers[0].ToString());
            Assert.Equal("Qc", ph.Kickers[1].ToString());
            Assert.Equal("Ac", ph.Kickers[2].ToString());
        }
    }
}
