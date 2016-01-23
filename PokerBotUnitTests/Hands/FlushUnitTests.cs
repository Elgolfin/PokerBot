using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class FlushUnitTests
    {
        [TestMethod]
        public void FlushUnitTests_1()
        {
            var flushHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0008004001001117, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/01 0000.0000 000/1.0001 0001.0111
            };

            var pht = new Flush();

            foreach (var hand in flushHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.Flush, ph.Strength);
            }
        }
    }
}
