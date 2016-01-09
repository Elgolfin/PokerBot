using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class PokerHandsUnitTests
    {

        [TestCategory("Count Cards")]
        [TestMethod]
        public void CountAllCardsInAHand()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.01/00 0000.0000 001/0.0000 0000.0001
            long hand = 0x0000008004002001;
            CardsAnalyzer.CountCards(hand);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._2]);
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            hand = 0x000000000000331F;
            CardsAnalyzer.CountCards(hand);
            Assert.AreEqual(2, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._2]);
            Assert.AreEqual(1, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._3]);
            Assert.AreEqual(1, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._4]);
            Assert.AreEqual(1, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._5]);
            Assert.AreEqual(1, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._6]);
            Assert.AreEqual(1, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._Jack]);

            hand = 0x000FFFFFFFFFFFFF;
            CardsAnalyzer.CountCards(hand);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._2]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._3]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._4]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._5]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._6]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._7]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._8]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._9]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._10]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._Jack]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._Queen]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._King]);
            Assert.AreEqual(4, CardsAnalyzer.cardsCount[(long)CardsAnalyzer.CardName._Ace]);
        }

        [TestCategory("Miscelleneaous")]
        [TestMethod]
        public void TwoClubs()
        {
            /// 00000000 000//0.0000 0000.0001 1/000.0000 0000.11/00 0000.0000 011/0.0000 0000.0011
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
            Assert.IsTrue(CardsAnalyzer.IsFourOfAKind(fourOfAKind),"Hand got four of a kind only (all aces), four of a kind expected");
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.01/01 0000.0000 001/0.0000 0000.0111
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(CardsAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind among other cards, four of a kind expected");
            /// 00000000 0000//1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(CardsAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind (all kings), four of a kind expected");
        }

        [TestCategory("Four of a kind")]
        [TestMethod]
        public void NotFourOfAKind()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0001
            long notFourOfAKind = 0x0000008003002001;
            Assert.IsFalse(CardsAnalyzer.IsFourOfAKind(notFourOfAKind));
        }

        [TestCategory("Three of a kind")]
        [TestMethod]
        public void ThreeOfAKind()
        {
            /// 00000000 00000000 00000000 00000000 00000100 00000000 00100000 00000001
            long threeOfAKind = 0x0000000004002001;
            Assert.IsTrue(CardsAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got three of a kind, three of a kind expected");
        }

        [TestCategory("Three of a kind")]
        [TestMethod]
        public void NotThreeOfAKind()
        {
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long threeOfAKind = 0x0000008005002007;
            Assert.IsFalse(CardsAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got four of a kind, three of a kind not expected");
        }

        [TestCategory("Pair")]
        [TestMethod]
        public void OnePair()
        {
            /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
            long aPair = 0x0000000000002001;
            Assert.IsTrue(CardsAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        }

        [TestCategory("Pair")]
        [TestMethod]
        public void NotOnePair()
        {
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long aPair = 0x0000008005002007;
            Assert.IsFalse(CardsAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        }

        [TestCategory("StraightFlush")]
        [TestMethod]
        public void StraightFlush()
        {
            /// 00000000 00000000 00000000 00000000 00000000 01000000 00100000 00011111
            long straightFlushHand = 0x000000000040201F;
            Assert.IsTrue(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x00000000004020F8;
            Assert.IsTrue(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x00000F8000000000;
            Assert.IsTrue(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x000F800000000000;
            Assert.IsTrue(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            /// 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1111
            straightFlushHand = 0x000000000040300F;
            Assert.IsTrue(CardsAnalyzer.IsStraightFlush(straightFlushHand), "Hand got a `petite` straight flush i.e. 12345 ");
        }

        [TestMethod]
        [TestCategory("Count Bits")]
        public void HandHas6BitsSet()
        {
            /// 00000000 0000//0000 00000000 0/0000000 000000/00 01000000 001/10000 00001110
            long hand = 0x000000000040201E;
            Assert.AreEqual(6, CardsAnalyzer.CountSetBits(hand));
            
        }

        [TestMethod]
        [TestCategory("Count Bits")]
        public void HandHas52BitsSet()
        {
            /// 0000.0000 0000//.0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1110
            long hand = 0x000FFFFFFFFFFFFF;
            Assert.AreEqual(52, CardsAnalyzer.CountSetBits(hand));
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void HandIsAFlush()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            long hand = 0x000000000000331F;
            Assert.IsTrue(CardsAnalyzer.IsFlush(hand), "Hand got a flush, flush expected");
        }

        [TestMethod]
        [TestCategory("Flush")]
        public void HandIsNotAFlush()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.IsFalse(CardsAnalyzer.IsFlush(hand), "Hand did not got a flush, flush not expected");
        }

        [TestCategory("Straight")]
        [TestMethod]
        public void IsStraightAndSpecialStraight()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0001 0001.1111
            long hand = 0x000000000000111F;
            Assert.IsTrue(CardsAnalyzer.IsStraight(hand), "Hand got a straight, straight expected");
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.1001 0000.1111
            hand = 0x000000000000190F;
            Assert.IsTrue(CardsAnalyzer.IsStraight(hand), "Hand got a special straight (12345), straight expected");
        }

        [TestCategory("Straight")]
        [TestMethod]
        public void IsNotStraight()
        {
            /// 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.IsFalse(CardsAnalyzer.IsStraight(hand), "Hand did not got a straight, straight not expected");
        }

        [TestCategory("FullHouse")]
        [TestMethod]
        public void IsFullHouse()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0110 0000.00/10 0000.0000 001/1.0000 0000.0001
            long fullHouse = 0x0000008602003001;
            Assert.IsTrue(CardsAnalyzer.IsFullHouse(fullHouse), "Hand did got a full house, full house is expected");
        }

        [TestCategory("FullHouse")]
        [TestMethod]
        public void IsNotFullHouse()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0111
            long notFullHouse = 0x0000008003002007;
            Assert.IsFalse(CardsAnalyzer.IsFullHouse(notFullHouse), "Hand did not got a full house, full house is not expected");
            /// 00000000 0000//1000 0000.0000 0/100.0000 0000.01/10 0000.0000 001/1.0000 0000.0001
            notFullHouse = 0x0008004006003001;
            Assert.IsFalse(CardsAnalyzer.IsFullHouse(notFullHouse), "Hand got four of a kind, full house is not expected");
        }

        [TestCategory("TwoPairs")]
        [TestMethod]
        public void IsTwoPairs()
        {
            /// 00000000 0000//0000 0000.0000 0/000.0010 0000.00/10 0100.0000 001/1.0010 0000.0001
            long twoPairs = 0x0000000602003001;
            Assert.IsTrue(CardsAnalyzer.IsTwoPairs(twoPairs), "Hand did got two pairs, two pairs are expected");
        }

        [TestCategory("TwoPairs")]
        [TestMethod]
        public void IsNotTwoPairs()
        {
            /// 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0001
            long notTwoPairs = 0x0000008003002001;
            Assert.IsFalse(CardsAnalyzer.IsTwoPairs(notTwoPairs), "Hand did not got a full house, full house is not expected");
            /// Four of a kind + three of a kind
            /// 00000000 0000//1000 0000.0000 0/100.0000 0000.01/10 0000.0000 001/1.0000 0000.0001
            notTwoPairs = 0x0008004006003001;
            Assert.IsFalse(CardsAnalyzer.IsTwoPairs(notTwoPairs), "Hand did not got a full house, full house is not expected");
        }
    }
}
