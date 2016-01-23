using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class FourOfAKindUnitTests
    {
        [TestMethod]
        public void FourOfAKindUnitTests_1()
        {
            var fourOfAKindHands = new Dictionary<long, string>()
            {
                {0x0008004002001000, string.Empty},                                        // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0008004002001007, string.Empty}                                         // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0111
            };

            var pht = new FourOfAKind();

            foreach (var hand in fourOfAKindHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.FourOfAKind, ph.Strength);
            }
        }
    }
}
