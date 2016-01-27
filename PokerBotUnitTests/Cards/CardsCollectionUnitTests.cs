using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    [TestClass]
    public class CardsCollectionUnitTests
    {
        [TestMethod]
        public void CardsCollection_ToString()
        {
            var cards = new CardsCollection()
            {
                new Card("Ah"),
                new Card("2s"),
                new Card("7d"),
                new Card("Ts"),
                new Card("Jc")
            };
            Assert.AreEqual("Ah 2s 7d Ts Jc", cards.ToString());
            cards.Add(new Card("Ac"));
            Assert.AreEqual("Ah 2s 7d Ts Jc Ac", cards.ToString());
        }


        [TestMethod]
        public void CardsCollection_Sort()
        {
            var cards = new CardsCollection()
            {
                new Card("Qd"),
                new Card("Ah"),
                new Card("2s"),
                new Card("7d"),
                new Card("Ts"),
                new Card("Jc")
            };
            cards.Sort();
            Assert.AreEqual("Ah Qd Jc Ts 7d 2s", cards.ToString());
        }

        [TestMethod]
        public void Initialize_With_String()
        {
            var cards = new CardsCollection("Ah 2s 7d Ts Jc");
            Assert.AreEqual(5, cards.Count);
            Assert.AreEqual("Ah 2s 7d Ts Jc", cards.ToString());
        }

        [TestMethod]
        public void Initialize_With_Capacity()
        {
            var cards = new CardsCollection(5);
            Assert.AreEqual(0, cards.Count);
        }

        [TestMethod]
        public void Iterate_CardsCollection()
        {
            var cards = new CardsCollection()
            {
                new Card("Qd"),
                new Card("Ah"),
                new Card("2s"),
                new Card("7d"),
                new Card("Ts"),
                new Card("Jc")
            };
            cards.Sort();
            var cpt = 0;
            foreach (var card in cards)
            {
                cpt++;
            }
            Assert.AreEqual(cpt, cards.Count);
        }
    }
}
