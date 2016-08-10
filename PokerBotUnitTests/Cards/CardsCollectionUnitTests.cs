using Xunit;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    
    public class CardsCollectionUnitTests
    {
        [Fact]
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
            Assert.Equal("Ah 2s 7d Ts Jc", cards.ToString());
            cards.Add(new Card("Ac"));
            Assert.Equal("Ah 2s 7d Ts Jc Ac", cards.ToString());
        }


        [Fact]
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
            Assert.Equal("Ah Qd Jc Ts 7d 2s", cards.ToString());
        }

        [Fact]
        public void Initialize_With_String()
        {
            var cards = new CardsCollection("Ah 2s 7d Ts Jc");
            Assert.Equal(5, cards.Count);
            Assert.Equal("Ah 2s 7d Ts Jc", cards.ToString());
        }

        [Fact]
        public void Initialize_With_Capacity()
        {
            var cards = new CardsCollection(5);
            Assert.Equal(0, cards.Count);
        }

        [Fact]
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
            Assert.Equal(cpt, cards.Count);
        }
    }
}
