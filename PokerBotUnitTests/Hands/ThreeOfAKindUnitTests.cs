using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class ThreeOfAKindUnitTests
    {
        [TestMethod]
        public void ThreeOfAKindUnitTests_1()
        {
            var threeOfAKindHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/0000 0000.0000 0/100.0000 0000.00/10 0000.0000 001/1.0001 0001.0001
                {0x0000000004002117, string.Empty},                                        // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.01/00 0000.0000 001/0.0001 0001.0111
                {0x000000000C007003, string.Empty},                                        // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.11/00 0000.0000 011/1.0000 0000.0011
                {0x0004000008007003, string.Empty}                                         // 0000 0000 0000/0100 0000.0000 0/000.0000 0000.01/00 0000.0000 011/1.0000 0000.0011
            };

            var pht = new ThreeOfAKind();

            foreach (var hand in threeOfAKindHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.ThreeOfAKind, ph.Strength);
            }
        }
    }
}
