using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class PokerHandAnalyzerUnitTests
    {
        [TestMethod]
        public void PokerHandAnalyzerUnitTest_1()
        {
            var cpt = 0;
            var pha = new PokerHandAnalyzer();
            Assert.AreEqual(cpt++, pha.Count());
            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.01/00 0000.0000 001/0.0000 0001.1111
            pha.AddPokerHand(0x400201FL);
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0x400201FL).Strength);
            Assert.AreEqual(cpt++, pha.Count());

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0111.1111
            var ph = new PokerHand(new HoleCards(new Card("2c"), new Card("3c")), new List<Card>() { new Card("4c"), new Card("5c"), new Card("6c"), new Card("7c"), new Card("8c") });
            pha.AddPokerHand(ph);
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0x7FL).Strength);
            Assert.AreEqual(cpt++, pha.Count());

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0000.1111 111/0.0000 0000.0000
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0xFE000L).Strength);
            Assert.AreEqual(cpt++, pha.Count());

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0100.0100 010/1.0001 0001.0001
            Assert.AreEqual(PokerHandAnalyzer.Strength.HighCard, pha.GetPokerHand(0x445111L).Strength);
            Assert.AreEqual(cpt, pha.Count());                                        


        }
    }
}
