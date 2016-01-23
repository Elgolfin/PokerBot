using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
