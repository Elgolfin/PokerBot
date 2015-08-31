using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class PokerHands
    {

        [TestCategory("Count Cards")]
        [TestMethod]
        public void CountAllCardsInAHand()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.01/00 0000.0000 001/0.0000 0000.0001
            long hand = 0x0000008004002001;
            HandAnalyzer.CountCards(hand);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_2]);
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            hand = 0x000000000000331F;
            HandAnalyzer.CountCards(hand);
            Assert.AreEqual(2, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_2]);
            Assert.AreEqual(1, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_3]);
            Assert.AreEqual(1, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_4]);
            Assert.AreEqual(1, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_5]);
            Assert.AreEqual(1, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_6]);
            Assert.AreEqual(1, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_Jack]);

            hand = 0x000FFFFFFFFFFFFF;
            HandAnalyzer.CountCards(hand);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_2]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_3]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_4]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_5]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_6]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_7]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_8]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_9]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_10]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_Jack]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_Queen]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_King]);
            Assert.AreEqual(4, HandAnalyzer.cardsCount[(long)HandAnalyzer.CardName.Card_Ace]);
        }

        [TestCategory("Miscelleneaous")]
        [TestMethod]
        public void TwoClubs()
        {
            long hand = 0x000001800C006003;
            Club clubs = new Club(hand);
            Assert.AreEqual(0x0000000000000003, (clubs.Mask & hand));
            Assert.AreEqual("0000000000011", clubs.ToBinaryString());
        }


        [TestCategory("Miscelleneaous")]
        [TestMethod]
        public void TwoDiamonds()
        {
            long hand = 0x000001800C006003;
            Diamond diamonds = new Diamond(hand);
            Assert.AreEqual(0x0000000000006000, (diamonds.Mask & hand));
            Assert.AreEqual("0000000000011", diamonds.ToBinaryString());
        }

        [TestCategory("Miscelleneaous")]
        [TestMethod]
        public void TwoSpades()
        {

            long hand = 0x000001800C006003;
            Spade spades = new Spade(hand);
            Assert.AreEqual(0x000000000C000000, (spades.Mask & hand));
            Assert.AreEqual("0000000000011", spades.ToBinaryString());
        }

        [TestCategory("Miscelleneaous")]
        [TestMethod]
        public void TwoHearts()
        {
            long hand = 0x000001800C006003;
            Heart hearts = new Heart(hand);
            Assert.AreEqual(0x0000018000000000, (hearts.Mask & hand));
            Assert.AreEqual("0000000000011", hearts.ToBinaryString());
        }

        [TestCategory("Four of a kind")]
        [TestMethod]
        public void FourOfAKind()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.01/00 0000.0000 001/0.0000 0000.0001
            long fourOfAKind = 0x0000008004002001;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind),"Hand got four of a kind only (all aces), four of a kind expected");
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.01/01 0000.0000 001/0.0000 0000.0111
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind among other cards, four of a kind expected");
            /// 00000000 0000//1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind (all kings), four of a kind expected");
        }

        [TestCategory("Four of a kind")]
        [TestMethod]
        public void NotFourOfAKind()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0001
            long notFourOfAKind = 0x0000008003002001;
            Assert.IsFalse(HandAnalyzer.IsFourOfAKind(notFourOfAKind));
        }

        [TestCategory("Three of a kind")]
        [TestMethod]
        public void ThreeOfAKind()
        {
            /// 00000000 00000000 00000000 00000000 00000100 00000000 00100000 00000001
            long threeOfAKind = 0x0000000004002001;
            Assert.IsTrue(HandAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got three of a kind, three of a kind expected");
        }

        [TestCategory("Three of a kind")]
        [TestMethod]
        public void NotThreeOfAKind()
        {
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long threeOfAKind = 0x0000008005002007;
            Assert.IsFalse(HandAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got four of a kind, three of a kind not expected");
        }

        [TestCategory("Pair")]
        [TestMethod]
        public void OnePair()
        {
            /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
            long aPair = 0x0000000000002001;
            Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        }

        [TestCategory("Pair")]
        [TestMethod]
        public void NotOnePair()
        {
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long aPair = 0x0000008005002007;
            Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        }

        //[TestMethod]
        //public void StraightFlush()
        //{
        //    /// 00000000 00000000 00000000 00000000 00000000 01000000 00100000 00011111
        //    long straightFlushHand = 0x000000000040201F;
        //    Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand)); 
        //    straightFlushHand = 0x00000000004020F8;
        //    Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
        //    straightFlushHand = 0x00000F8000000000;
        //    Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
        //    straightFlushHand = 0x000F800000000000;
        //    Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
        //    /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1111
        //    straightFlushHand = 0x000000000040300F;
        //    Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand), "Hand got a `petite` straight flush i.e. 12345 ");
        //}

        [TestMethod]
        [TestCategory("Count Bits")]
        public void HandHas6BitsSet()
        {
            /// 00000000 0000//0000 00000000 0/0000000 000000/00 01000000 001/10000 00001110
            long hand = 0x000000000040201E;
            Assert.AreEqual(6, HandAnalyzer.CountSetBits(hand));
            
        }

        [TestMethod]
        [TestCategory("Count Bits")]
        public void HandHas52BitsSet()
        {
            /// 0000.0000 0000//.0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1110
            long hand = 0x000FFFFFFFFFFFFF;
            Assert.AreEqual(52, HandAnalyzer.CountSetBits(hand));
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void HandIsAFlush()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            long hand = 0x000000000000331F;
            Assert.IsTrue(HandAnalyzer.IsFlush(hand), "Hand got a flush, flush expected");
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void HandIsNotAFlush()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.IsFalse(HandAnalyzer.IsFlush(hand), "Hand did not got a flush, flush not expected");
        }

        [TestCategory("Straight")]
        [TestMethod]
        public void IsStraight()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0001 0001.1111
            long hand = 0x000000000000111F;
            Assert.IsTrue(HandAnalyzer.IsStraight(hand), "Hand got a straight, straight expected");
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.1001 0000.1111
            hand = 0x000000000000190F;
            Assert.IsTrue(HandAnalyzer.IsStraight(hand), "Hand got a special straight (12345), straight expected");
        }

        [TestCategory("Straight")]
        [TestMethod]
        public void IsNotStraight()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.IsFalse(HandAnalyzer.IsStraight(hand), "Hand did not got a straight, straight not expected");
        }

        //[TestMethod]
        //public void FullHouse()
        //{
        //    /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
        //    long aPair = 0x0000000000002001;
        //    Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        //    /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
        //    aPair = 0x0000008005002007;
        //    Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        //}

        //[TestMethod]
        //public void TwoPair()
        //{
        //    /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
        //    long aPair = 0x0000000000002001;
        //    Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        //    /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
        //    aPair = 0x0000008005002007;
        //    Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        //}
    }
}
