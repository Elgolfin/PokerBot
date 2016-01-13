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
    }
}
