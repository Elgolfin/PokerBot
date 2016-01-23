using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class StraightFlushUnitTests
    {
        [TestMethod]
        public void StraightFlush_1()
        {
            var straightFlushHands = new Dictionary<long, string>()
            {
                {0x000000000040201F, string.Empty},                                         // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/0.0000 0001.1111
                {0x00000000004020F8, string.Empty},
                {0x00000F8000000000, string.Empty},
                {0x000F800000000000, string.Empty},
                {0x000000000040300F, "Hand got a `petite` straight flush i.e. 12345 "},     // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1111  
            };

            var pht = new StraightFlush();

            foreach (var hand in straightFlushHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, ph.Strength);
            }

        }
    }
}
