using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class TwoPairsUnitTests
    {
        [TestMethod]
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
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            }
        }

        [TestMethod]
        public void TwoPairs_With_Kickers_1()
        {
            var pha = new PokerHandAnalyzer();
            var ph = pha.GetPokerHand(new PokerHand(new HoleCards("As", "Ac"), new CardsCollection("Kh Ks 7d 2d Th")));
            Assert.AreEqual(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            Assert.AreEqual(3, ph.Kickers.Count);
            Assert.AreEqual("Ac", ph.Kickers[0].ToString());
            Assert.AreEqual("Kc", ph.Kickers[1].ToString());
            Assert.AreEqual("Tc", ph.Kickers[2].ToString());
        }

        //
        [TestMethod]
        public void TwoPairs_With_Kickers_2()
        {
            var pha = new PokerHandAnalyzer();
            var ph = pha.GetPokerHand(new PokerHand(new HoleCards("Qs", "Qc"), new CardsCollection("Kh Ks 7d Ad Th")));
            Assert.AreEqual(PokerHandAnalyzer.Strength.TwoPairs, ph.Strength);
            Assert.AreEqual(3, ph.Kickers.Count);
            Assert.AreEqual("Kc", ph.Kickers[0].ToString());
            Assert.AreEqual("Qc", ph.Kickers[1].ToString());
            Assert.AreEqual("Ac", ph.Kickers[2].ToString());
        }
    }
}
