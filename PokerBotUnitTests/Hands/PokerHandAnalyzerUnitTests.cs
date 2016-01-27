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
            var pha = new PokerHandAnalyzer();
            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.01/00 0000.0000 001/0.0000 0001.1111
            pha.AddPokerHand(0x400201FL);
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0x400201FL).Strength);

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0111.1111
            var ph = new PokerHand(new HoleCards(new Card("2c"), new Card("3c")),
                new CardsCollection() {new Card("4c"), new Card("5c"), new Card("6c"), new Card("7c"), new Card("8c")});
            pha.AddPokerHand(ph);
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0x7FL).Strength);

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0000.1111 111/0.0000 0000.0000
            Assert.AreEqual(PokerHandAnalyzer.Strength.StraightFlush, pha.GetPokerHand(0xFE000L).Strength);

            // 0000 0000 0000/0000 0000.0000 0/000.0000 0000.00/00 0100.0100 010/1.0001 0001.0001
            Assert.AreEqual(PokerHandAnalyzer.Strength.HighCard, pha.GetPokerHand(0x445111L).Strength);
        }

        [TestMethod]
        public void PokerHandAnalyzer_TwoPairs()
        {
            var pha = new PokerHandAnalyzer();
            var ph1 = new PokerHand(new HoleCards(new Card("Ah"), new Card("4s")),
                new CardsCollection() {new Card("As"), new Card("3c"), new Card("8h"), new Card("4h"), new Card("6s")});
            pha.AddPokerHand(ph1);
            var ph2 = new PokerHand(new HoleCards(new Card("Qs"), new Card("6c")),
                new CardsCollection() { new Card("As"), new Card("3c"), new Card("8h"), new Card("4h"), new Card("6s") });
            pha.AddPokerHand(ph2);
            Assert.AreEqual(PokerHandAnalyzer.Strength.TwoPairs, pha.GetPokerHand(ph1.ToLong()).Strength);
            Assert.AreEqual(PokerHandAnalyzer.Strength.OnePair, pha.GetPokerHand(ph2.ToLong()).Strength);
            // TODO test de kickers, kickers of TwoPairs are not properly sets
        }
    }
}
