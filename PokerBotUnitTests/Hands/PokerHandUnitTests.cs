using System.Collections.Generic;
using Xunit;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    
    public class PokerHandUnitTests
    {
        [Fact]
        public void PokerHand_New()
        {
            // 0000 0000 0000/1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0111.1111
            var ph = new PokerHand(new HoleCards(new Card("2c"), new Card("3c")), new CardsCollection() { new Card("4c"), new Card("5c"), new Card("6c"), new Card("7c"), new Card("8c") });
            Assert.Equal(0x7FL, ph.ToLong());
        }
    }
}
