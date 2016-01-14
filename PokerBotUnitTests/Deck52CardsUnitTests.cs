using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class Deck52CardsUnitTests
    {
        [TestMethod]
        [TestCategory("Deck")]
        public void TestDeck52Cards()
        {
            Deck52Cards deck = new Deck52Cards();
            Assert.AreEqual(52, deck.GetCards().Count);
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void TestDeck52Cards_Deal_1()
        {
            Deck52Cards deck = new Deck52Cards();
            Card card = deck.Deal();
            Assert.AreEqual(51, deck.GetCards().Count);
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void TestDeck52Cards_Burn_1()
        {
            Deck52Cards deck = new Deck52Cards();
            deck.Burn();
            Assert.AreEqual(51, deck.GetCards().Count);
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void CompareDecks_Same_Returns_True()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            Assert.AreEqual(true, deck1.Equals(deck2));
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void CompareDecks_DifferentAfterSHuffling_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            deck1.Shuffle();
            deck2.Shuffle();
            Assert.AreEqual(false, deck1.Equals(deck2));
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void CompareDecks_DifferentSize_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            deck1.Burn();
            Assert.AreEqual(false, deck1.Equals(deck2));
        }

        [TestMethod]
        [TestCategory("Deck")]
        public void CompareDecks_Null_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Assert.AreEqual(false, deck1.Equals(null));
        }
    }
}
