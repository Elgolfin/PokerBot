using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    [TestClass]
    public class CardUnitTests
    {
        [TestCategory("Card")]
        [TestMethod]
        public void Card_2c_Is_0x1()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0001
            Card card = new Card("2c");
            ulong result = 0x1;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ac_Is_0x1000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0000 0000.0000
            Card card = new Card("Ac");
            ulong result = 0x1000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2d_Is_0x2000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0000 0000.0000
            Card card = new Card("2d");
            ulong result = 0x2000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ad_Is_0x2000000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/10 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ad");
            ulong result = 0x2000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2s_Is_0x4000000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.01/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2s");
            ulong result = 0x4000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_As_Is_0x4000000000()
        {
            // 00000000 0000//0000 0000.0000 0/100.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("As");
            ulong result = 0x4000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_2h_Is_0x8000000000()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2h");
            ulong result = 0x8000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(2, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Ah_Is_0x8000000000000()
        {
            // 00000000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ah");
            ulong result = 0x8000000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(14, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Kh_Is_0x4000000000000()
        {
            // 00000000 0000//0100 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Kh");
            ulong result = 0x4000000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(13, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Qh_Is_0x2000000000000()
        {
            // 00000000 0000//0010 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Qh");
            ulong result = 0x2000000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(12, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Jh_Is_0x1000000000000()
        {
            // 00000000 0000//0001 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Jh");
            ulong result = 0x1000000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(11, card.RelativeValue);

            card = new Card(11, Card.SuitName.Hearts);
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(11, card.RelativeValue);
        }

        [TestCategory("Card")]
        [TestMethod]
        public void Card_Th_Is_0x800000000000()
        {
            // 00000000 0000//0000 1000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Th");
            ulong result = 0x800000000000;
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(10, card.RelativeValue);

            card = new Card(10, Card.SuitName.Hearts);
            Assert.AreEqual(result, card.AbsoluteValue);
            Assert.AreEqual(10, card.RelativeValue);
        }



        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Th_Js()
        {
            Card card1 = new Card("Th");
            Card card2 = new Card("Js");
            Assert.AreEqual(-1, card1.CompareTo(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Js_Th()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Ts");
            Assert.AreEqual(1, card1.CompareTo(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Js_Jh()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Js");
            Assert.AreEqual(0, card2.CompareTo(card1));
        }

        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Th_Jh()
        {
            Card card1 = new Card("Th");
            Card card2 = new Card("Jh");
            Assert.AreEqual(-1, card1.CompareTo(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Jh_Th()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Th");
            Assert.AreEqual(1, card1.CompareTo(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Jh_Jh()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jh");
            Assert.AreEqual(0, card2.CompareTo(card1));
        }


        [TestCategory("Card")]
        [TestMethod]
        public void ToString_Kh()
        {
            Card card = new Card("kh");
            Assert.AreEqual("Kh", card.ToString());

        }


        [TestCategory("Card")]
        [TestMethod]
        public void ToString_Qs()
        {
            Card card = new Card("qs");
            Assert.AreEqual("Qs", card.ToString());
        }


        [TestCategory("Card")]
        [TestMethod]
        public void ToString_Jc()
        {
            Card card = new Card("jc");
            Assert.AreEqual("Jc", card.ToString());
        }


        [TestCategory("Card")]
        [TestMethod]
        public void ToString_Td()
        {
            Card card = new Card("td");
            Assert.AreEqual("Td", card.ToString());
        }
        [TestCategory("Card")]
        [TestMethod]
        public void ToString_As()
        {
            Card card = new Card("aS");
            Assert.AreEqual("As", card.ToString());
        }
        [TestCategory("Card")]
        [TestMethod]
        public void ToString_9h()
        {
            Card card = new Card("9h");
            Assert.AreEqual("9h", card.ToString());
        }

        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Jh_Equals_Jd_Returns_False()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jd");
            Assert.AreEqual(false, card1.Equals(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Jh_Equals_Jh_Returns_True()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jh");
            Assert.AreEqual(true, card1.Equals(card2));
        }
        [TestCategory("Card")]
        [TestMethod]
        public void CompareCards_Jh_Equals_null_Returns_False()
        {
            Card card1 = new Card("Jh");
            Assert.AreEqual(false, card1.Equals(null));
        }

    }
}
