using Xunit;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.UnitTests.Cards
{

    public class CardUnitTests
    {
        [Trait("Category", "Card")]
        [Fact]
        public void Card_2c_Is_0x1()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0001
            Card card = new Card("2c");
            ulong result = 0x1;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(2, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Ac_Is_0x1000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0000 0000.0000
            Card card = new Card("Ac");
            ulong result = 0x1000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(14, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_2d_Is_0x2000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0000 0000.0000
            Card card = new Card("2d");
            ulong result = 0x2000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(2, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Ad_Is_0x2000000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/10 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ad");
            ulong result = 0x2000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(14, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_2s_Is_0x4000000()
        {
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.01/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2s");
            ulong result = 0x4000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(2, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_As_Is_0x4000000000()
        {
            // 00000000 0000//0000 0000.0000 0/100.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("As");
            ulong result = 0x4000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(14, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_2h_Is_0x8000000000()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("2h");
            ulong result = 0x8000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(2, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Ah_Is_0x8000000000000()
        {
            // 00000000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Ah");
            ulong result = 0x8000000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(14, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Kh_Is_0x4000000000000()
        {
            // 00000000 0000//0100 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Kh");
            ulong result = 0x4000000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(13, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Qh_Is_0x2000000000000()
        {
            // 00000000 0000//0010 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Qh");
            ulong result = 0x2000000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(12, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Jh_Is_0x1000000000000()
        {
            // 00000000 0000//0001 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Jh");
            ulong result = 0x1000000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(11, card.RelativeValue);

            card = new Card(11, Card.SuitName.Hearts);
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(11, card.RelativeValue);
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_Th_Is_0x800000000000()
        {
            // 00000000 0000//0000 1000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            Card card = new Card("Th");
            ulong result = 0x800000000000;
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(10, card.RelativeValue);

            card = new Card(10, Card.SuitName.Hearts);
            Assert.Equal(result, card.AbsoluteValue);
            Assert.Equal(10, card.RelativeValue);
        }



        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Th_Js()
        {
            Card card1 = new Card("Th");
            Card card2 = new Card("Js");
            Assert.Equal(-1, card1.CompareTo(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Js_Th()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Ts");
            Assert.Equal(1, card1.CompareTo(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Js_Jh()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Js");
            Assert.Equal(0, card2.CompareTo(card1));
        }

        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Th_Jh()
        {
            Card card1 = new Card("Th");
            Card card2 = new Card("Jh");
            Assert.Equal(-1, card1.CompareTo(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Jh_Th()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Th");
            Assert.Equal(1, card1.CompareTo(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Jh_Jh()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jh");
            Assert.Equal(0, card2.CompareTo(card1));
        }


        [Trait("Category", "Card")]
        [Fact]
        public void ToString_Kh()
        {
            Card card = new Card("kh");
            Assert.Equal("Kh", card.ToString());

        }


        [Trait("Category", "Card")]
        [Fact]
        public void ToString_Qs()
        {
            Card card = new Card("qs");
            Assert.Equal("Qs", card.ToString());
        }


        [Trait("Category", "Card")]
        [Fact]
        public void ToString_Jc()
        {
            Card card = new Card("jc");
            Assert.Equal("Jc", card.ToString());
        }


        [Trait("Category", "Card")]
        [Fact]
        public void ToString_Td()
        {
            Card card = new Card("td");
            Assert.Equal("Td", card.ToString());
        }
        [Trait("Category", "Card")]
        [Fact]
        public void ToString_As()
        {
            Card card = new Card("aS");
            Assert.Equal("As", card.ToString());
        }
        [Trait("Category", "Card")]
        [Fact]
        public void ToString_9h()
        {
            Card card = new Card("9h");
            Assert.Equal("9h", card.ToString());
        }

        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Jh_Equals_Jd_Returns_False()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jd");
            Assert.Equal(false, card1.Equals(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Jh_Equals_Jh_Returns_True()
        {
            Card card1 = new Card("Jh");
            Card card2 = new Card("Jh");
            Assert.Equal(true, card1.Equals(card2));
        }
        [Trait("Category", "Card")]
        [Fact]
        public void CompareCards_Jh_Equals_null_Returns_False()
        {
            Card card1 = new Card("Jh");
            Assert.Equal(false, card1.Equals(null));
        }


        [Trait("Category", "Card")]
        [Fact]
        public void Card_New_AbsoluteValue_Clubs()
        {
            long absValue = 0x1;
            for (var i = 2; i <= 14; i++)
            {
                var card1 = new Card(absValue);
                var card2 = new Card(i, Card.SuitName.Clubs);
                Assert.True(card1.Equals(card2), $"{card2} is expected");
                absValue <<= 1;
            }
            
        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_New_AbsoluteValue_Diamonds()
        {
            long absValue = 0x2000;
            for (var i = 2; i <= 14; i++)
            {
                var card1 = new Card(absValue);
                var card2 = new Card(i, Card.SuitName.Diamonds);
                Assert.True(card1.Equals(card2), $"{card2} is expected");
                absValue <<= 1;
            }

        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_New_AbsoluteValue_Spades()
        {
            long absValue = 0x4000000;
            for (var i = 2; i <= 14; i++)
            {
                var card1 = new Card(absValue);
                var card2 = new Card(i, Card.SuitName.Spades);
                Assert.True(card1.Equals(card2), $"{card2} is expected");
                absValue <<= 1;
            }

        }

        [Trait("Category", "Card")]
        [Fact]
        public void Card_New_AbsoluteValue_Hearts()
        {
            long absValue = 0x8000000000;
            for (var i = 2; i <= 14; i++)
            {
                var card1 = new Card(absValue);
                var card2 = new Card(i, Card.SuitName.Hearts);
                Assert.True(card1.Equals(card2), $"{card2} is expected");
                absValue <<= 1;
            }

        }

    }
}
