using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class StraightUnitTests
    {
        [TestMethod]
        public void Straight_1()
        {
            var straightHands = new Dictionary<long, string>()
            {
                //{0x000000000040201F, string.Empty},                                         // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/0.0000 0001.1111
                {0x000000000007000F, string.Empty}     // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0111 000/0.0000 0000.1111  
            };

            var pht = new Straight();

            foreach (var hand in straightHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.Straight, ph.Strength);
            }
        }
    }
}
