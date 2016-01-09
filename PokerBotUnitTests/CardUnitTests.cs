using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class CardUnitTests
    {
        [TestCategory("Card")]
        [TestMethod]
        public void Card_2c_Is_0x1()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0001
            Card card = new Card("2c");
            ulong result = 0x1;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ac_Is_0x1000()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0000 0000.0000
            Card card = new Card("Ac");
            ulong result = 0x1000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2d_Is_0x2000()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0000 0000.0000
            Card card = new Card("2d");
            ulong result = 0x2000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ad_Is_0x2000000()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/10 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ad");
            ulong result = 0x2000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2s_Is_0x4000000()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.01/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2s");
            ulong result = 0x4000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_As_Is_0x4000000000()
        {
            /// 00000000 0000//0000 0000.0000 0/100.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("As");
            ulong result = 0x4000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2h_Is_0x8000000000()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2h");
            ulong result = 0x8000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ah_Is_0x8000000000000()
        {
            /// 00000000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ah");
            ulong result = 0x8000000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }
    }
}
