using Xunit;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    
    public class Deck52CardsUnitTests
    {
        [Fact]
        [Trait("Category", "Deck")]
        public void TestDeck52Cards()
        {
            Deck52Cards deck = new Deck52Cards();
            Assert.Equal(52, deck.GetCards().Count);
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void TestDeck52Cards_Deal_1()
        {
            Deck52Cards deck = new Deck52Cards();
            deck.Deal();
            Assert.Equal(51, deck.GetCards().Count);
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void TestDeck52Cards_Burn_1()
        {
            Deck52Cards deck = new Deck52Cards();
            deck.Burn();
            Assert.Equal(51, deck.GetCards().Count);
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void CompareDecks_Same_Returns_True()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            Assert.Equal(true, deck1.Equals(deck2));
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void CompareDecks_DifferentAfterSHuffling_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            deck1.Shuffle();
            deck2.Shuffle();
            Assert.Equal(false, deck1.Equals(deck2));
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void CompareDecks_DifferentSize_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Deck52Cards deck2 = new Deck52Cards();
            deck1.Burn();
            Assert.Equal(false, deck1.Equals(deck2));
        }

        [Fact]
        [Trait("Category", "Deck")]
        public void CompareDecks_Null_Returns_False()
        {
            Deck52Cards deck1 = new Deck52Cards();
            Assert.Equal(false, deck1.Equals(null));
        }
    }
}
