﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class HighCardUnitTests
    {
        [TestMethod]
        public void HighCardUnitTests_1()
        {
            var highCardsHands = new Dictionary<long, string>()
            {
                //{0x0008004002001000, string.Empty},                                      // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
                {0x0000000004221111, string.Empty}                                         // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.01/00 0010.0010 000/1.0001 0001.0001
            };

            var pht = new HighCard();

            foreach (var hand in highCardsHands)
            {
                var ph = new PokerHand(hand.Key);
                Assert.IsTrue(pht.Parse(ph), hand.Value);
                Assert.AreEqual(PokerHandAnalyzer.Strength.HighCard, ph.Strength);
            }
        }
    }
}
