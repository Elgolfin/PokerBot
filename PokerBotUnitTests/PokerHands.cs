using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class PokerHands
    {
        

        [TestMethod]
        public void TwoClubs()
        {
            long hand = 0x000001800C006003;
            Club clubs = new Club(hand);
            Assert.AreEqual(0x0000000000000003, (clubs.Mask & hand));
            Assert.AreEqual("0000000000011", clubs.ToBinaryString());
        }

        

        [TestMethod]
        public void TwoDiamonds()
        {
            long hand = 0x000001800C006003;
            Diamond diamonds = new Diamond(hand);
            Assert.AreEqual(0x0000000000006000, (diamonds.Mask & hand));
            Assert.AreEqual("0000000000011", diamonds.ToBinaryString());
        }

        [TestMethod]
        public void TwoSpades()
        {

            long hand = 0x000001800C006003;
            Spade spades = new Spade(hand);
            Assert.AreEqual(0x000000000C000000, (spades.Mask & hand));
            Assert.AreEqual("0000000000011", spades.ToBinaryString());
        }

        [TestMethod]
        public void TwoHearts()
        {

            long hand = 0x000001800C006003;
            Heart hearts = new Heart(hand);
            Assert.AreEqual(0x0000018000000000, (hearts.Mask & hand));
            Assert.AreEqual("0000000000011", hearts.ToBinaryString());
        }

        [TestMethod]
        public void FourOfAKind()
        {
            /// 00000000 00000000 00000000 10000000 00000100 00000000 00100000 00000001
            long fourOfAKind = 0x0000008004002001;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind),"Hand got four of a kind only (all aces), four of a kind expected");
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind among other cards, four of a kind expected");
            /// 00000000 00001000 00000000 01000000 00000010 00000000 00010000 00000000
            fourOfAKind = 0x0000008005002007;
            Assert.IsTrue(HandAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind (all kings), four of a kind expected");
        }

        [TestMethod]
        public void NotFourOfAKind()
        {
            /// 00000000 00000000 00000000 10000000 00000011 00000000 00100000 00000001
            long notFourOfAKind = 0x0000008003002001;
            Assert.IsFalse(HandAnalyzer.IsFourOfAKind(notFourOfAKind));
        }

        [TestMethod]
        public void ThreeOfAKind()
        {
            /// 00000000 00000000 00000000 00000000 00000100 00000000 00100000 00000001
            long threeOfAKind = 0x0000000004002001;
            Assert.IsTrue(HandAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got three of a kind, three of a kind expected");
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            threeOfAKind = 0x0000008005002007;
            Assert.IsFalse(HandAnalyzer.IsThreeOfAKind(threeOfAKind),"Hand got four of a kind, three of a kind not expected");
        }

        [TestMethod]
        public void OnePair()
        {
            /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
            long aPair = 0x0000000000002001;
            Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
            /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            aPair = 0x0000008005002007;
            Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        }



        [TestMethod]
        public void StraightFlush()
        {
            /// 00000000 00000000 00000000 00000000 00000000 01000000 00100000 00011111
            long straightFlushHand = 0x000000000040201F;
            Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand)); 
            straightFlushHand = 0x00000000004020F8;
            Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x00000F8000000000;
            Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x000F800000000000;
            Assert.IsTrue(HandAnalyzer.IsStraightFlush(straightFlushHand));
        }

        //[TestMethod]
        //public void Flush()
        //{
        //    /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
        //    long aPair = 0x0000000000002001;
        //    Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        //    /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
        //    aPair = 0x0000008005002007;
        //    Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        //}

        //[TestMethod]
        //public void Straight()
        //{
        //    /// 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
        //    long aPair = 0x0000000000002001;
        //    Assert.IsTrue(HandAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        //    /// 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
        //    aPair = 0x0000008005002007;
        //    Assert.IsFalse(HandAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        //}

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
