using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    [TestClass]
    public class HoleCardsUnitTests
    {
        [TestMethod]
        [TestCategory("HoleCards")]
        public void Initialize_Hand_With_CardObjects()
        {
            var card1 = new Card("Th");
            var card2 = new Card("As");
            var hand = new HoleCards(card1, card2);
            Assert.AreEqual("Th", hand.FirstCard.ToString());
            Assert.AreEqual("As", hand.SecondCard.ToString());
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Initialize_Hand_With_CardShortnames()
        {
            var hand = new HoleCards("Ks", "Ah");
            Assert.AreEqual("Ks", hand.FirstCard.ToString());
            Assert.AreEqual("Ah", hand.SecondCard.ToString());

        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Initialize_Hand_With_Shortname()
        {
            var hand = new HoleCards("AK");
            Assert.AreEqual("Ac", hand.FirstCard.ToString());
            Assert.AreEqual("Kh", hand.SecondCard.ToString());
            Assert.AreEqual(false,hand.SameSuit);

        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Initialize_Hand_With_Shortname_Suited()
        {
            var hand = new HoleCards("AKs");
            Assert.AreEqual("Ah", hand.FirstCard.ToString());
            Assert.AreEqual("Kh", hand.SecondCard.ToString());
            Assert.AreEqual(true, hand.SameSuit);

        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_2h3h_Shortname_Is_32s()
        {
            var hand = new HoleCards("2h", "3h");
            Assert.AreEqual("32s", hand.ShortName);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_3hAd_Shortname_Is_A3()
        {
            var hand = new HoleCards("3h", "Ad");
            Assert.AreEqual("A3", hand.ShortName);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_JhAd_Shortname_Is_AdJh()
        {
            var hand = new HoleCards("Jh", "Ad");
            Assert.AreEqual("AdJh", hand.LongName);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_ThTc_Is_Pair()
        {
            var hand = new HoleCards("Th", "Tc");
            Assert.AreEqual(true, hand.Pair);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_5h2c_Is_NotPair()
        {
            var hand = new HoleCards("5h", "2c");
            Assert.AreEqual(false, hand.Pair);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void EmptyHand()
        {
            var hand = new HoleCards();
            Assert.AreEqual(null, hand.FirstCard);
            Assert.AreEqual(null, hand.SecondCard);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_7dKc_LowCard_Is_7d()
        {
            var hand = new HoleCards("7d","Kc");
            Assert.AreEqual("7d", hand.LowCard.ToString());
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_7d7c_LowCard_Is_7d()
        {
            var hand = new HoleCards("7d", "7c");
            Assert.AreEqual("7c", hand.LowCard.ToString());
        }



        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenValue_Pairs()
        {

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AA", 20);
            pairs.Add("KK", 16);
            pairs.Add("QQ", 14);
            pairs.Add("JJ", 12);
            pairs.Add("TT", 10);
            pairs.Add("99", 9);
            pairs.Add("88", 8);
            pairs.Add("77", 7);
            pairs.Add("66", 6);
            pairs.Add("55", 5);
            pairs.Add("44", 5);
            pairs.Add("33", 5);
            pairs.Add("22", 5);
            foreach (var kvp in pairs)
            {
                Assert.AreEqual(kvp.Value, new HoleCards(kvp.Key).BillChenValue);
            }
        }
        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenValue_Straight_1()
        {

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AK", 10);
            pairs.Add("KQ", 8);
            pairs.Add("QJ", 7);
            pairs.Add("JT", 7);
            pairs.Add("T9", 6);
            pairs.Add("98", 6);
            pairs.Add("87", 5);
            pairs.Add("76", 5);
            pairs.Add("65", 4);
            pairs.Add("54", 4);
            pairs.Add("43", 3);
            pairs.Add("32", 3);
            pairs.Add("2A", 5);
            pairs.Add("AKs", 12);
            pairs.Add("KQs", 10);
            pairs.Add("QJs", 9);
            pairs.Add("JTs", 9);
            pairs.Add("T9s", 8);
            pairs.Add("98s", 8);
            pairs.Add("87s", 7);
            pairs.Add("76s", 7);
            pairs.Add("65s", 6);
            pairs.Add("54s", 6);
            pairs.Add("43s", 5);
            pairs.Add("32s", 5);
            pairs.Add("2As", 7);
            foreach (var kvp in pairs)
            {
                Assert.AreEqual(kvp.Value, new HoleCards(kvp.Key).BillChenValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenValue_AA_Is_20()
        {
            var hand = new HoleCards(new Card(14, Card.SuitName.Hearts), new Card(14, Card.SuitName.Diamonds));
            Assert.AreEqual(20, hand.BillChenValue);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenValue_27_Is_Minus1()
        {
            var hand = new HoleCards("27");
            Assert.AreEqual(-1, hand.BillChenValue);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenValue_37_Is_0()
        {
            var hand = new HoleCards("37");
            Assert.AreEqual(0, hand.BillChenValue);
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_1()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AA", 20);
            pairs.Add("KK", 16);
            pairs.Add("QQ", 14);
            pairs.Add("JJ", 12);
            pairs.Add("AKs", 12);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(1, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_2()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AK", 10);
            pairs.Add("AQs", 11);
            pairs.Add("AJs", 10);
            pairs.Add("KQs", 10);
            pairs.Add("TT", 10);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(2, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_3()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AQ", 9);
            pairs.Add("ATs", 8);
            pairs.Add("KJs", 9);
            pairs.Add("QJs", 9);
            pairs.Add("JTs", 9);
            pairs.Add("99", 9);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(3, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_4()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AJ", 8);
            pairs.Add("KQ", 8);
            pairs.Add("KTs", 8);
            pairs.Add("QTs", 8);
            pairs.Add("J9s", 8);
            pairs.Add("T9s", 8);
            pairs.Add("98s", 8);
            pairs.Add("88", 8);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(4, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_5()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("A9s", 7);
            pairs.Add("A8s", 7);
            pairs.Add("A7s", 7);
            pairs.Add("A6s", 7);
            pairs.Add("A5s", 7);
            pairs.Add("A4s", 7);
            pairs.Add("A3s", 7);
            pairs.Add("A2s", 7);
            pairs.Add("KJ", 7);
            pairs.Add("QJ", 7);
            pairs.Add("JT", 7);
            pairs.Add("Q9s", 7);
            pairs.Add("T8s", 7);
            pairs.Add("97s", 7);
            pairs.Add("87s", 7);
            pairs.Add("77", 7);
            pairs.Add("76s", 7);
            pairs.Add("66", 6);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(5, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_6()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("AT", 6);
            pairs.Add("KT", 6);
            pairs.Add("QT", 6);
            pairs.Add("J8s", 6);
            pairs.Add("86s", 6);
            pairs.Add("75s", 6);
            pairs.Add("65s", 6);
            pairs.Add("55", 5);
            pairs.Add("54s", 6);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(6, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_7()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("K9s", 6);
            pairs.Add("K8s", 5);
            pairs.Add("K7s", 5);
            pairs.Add("K6s", 5);
            pairs.Add("K5s", 5);
            pairs.Add("K4s", 5);
            pairs.Add("K3s", 5);
            pairs.Add("K2s", 5);
            pairs.Add("J9", 6);
            pairs.Add("T9", 6);
            pairs.Add("98", 6);
            pairs.Add("64s", 5);
            pairs.Add("53s", 5);
            pairs.Add("44", 5);
            pairs.Add("43s", 5);
            pairs.Add("33", 5);
            pairs.Add("22", 5);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(7, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_8()
        {

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("A9", 5);
            pairs.Add("K9", 4);
            pairs.Add("Q9", 5);
            pairs.Add("J8", 4);
            pairs.Add("J7s", 4);
            pairs.Add("T8", 5);
            pairs.Add("96s", 5);
            pairs.Add("87", 5);
            pairs.Add("85s", 4);
            pairs.Add("76", 5);
            pairs.Add("74s", 4);
            pairs.Add("65", 4);
            pairs.Add("54", 4);
            pairs.Add("42s", 4);
            pairs.Add("32s", 5);

            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(8, hand.BillChenGroupValue);
            }
        }

        [TestMethod]
        [TestCategory("HoleCards")]
        public void BillChenGroupValue_9()
        {

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("72", -1);
            pairs.Add("72s", 1);
            pairs.Add("A8", 5);
            pairs.Add("A7", 5);
            pairs.Add("A6", 5);
            pairs.Add("A5", 5);
            pairs.Add("A4", 5);
            pairs.Add("A3", 5);
            pairs.Add("A2", 5);
            foreach (var kvp in pairs)
            {
                var hand = new HoleCards(kvp.Key);
                Assert.AreEqual(kvp.Value, hand.BillChenValue);
                Assert.AreEqual(9, hand.BillChenGroupValue);
            }
        }


        [TestMethod]
        [TestCategory("HoleCards")]
        public void Initialize_Hand_Two_Times()
        {
            var hand = new HoleCards("AA");
            Assert.AreEqual(20, hand.BillChenValue);
            hand.FirstCard = new Card(7, Card.SuitName.Clubs);
            hand.SecondCard = new Card(2, Card.SuitName.Diamonds);
            Assert.AreEqual(-1, hand.BillChenValue);
        }


        [TestMethod]
        [TestCategory("HoleCards")]
        public void Hand_ToString_Is_LongName()
        {
            var hand = new HoleCards("Ah", "Ad");
            Assert.AreEqual("AhAd", hand.ToString());
        }

    }
}