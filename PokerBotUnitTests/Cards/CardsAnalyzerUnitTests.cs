using Xunit;
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    
    public class CardsAnalyzerUnitTests
    {

        [Trait("Category", "Count Cards")]
        [Fact]
        public void CountAllCardsInAHand()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.01/00 0000.0000 001/0.0000 0000.0001
            long hand = 0x0000008004002001;
            CardsAnalyzer.CountCards(hand);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Two]);
            // 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            hand = 0x000000000000331F;
            CardsAnalyzer.CountCards(hand);
            Assert.Equal(2, CardsAnalyzer.CardsCount[(long)Card.CardName.Two]);
            Assert.Equal(1, CardsAnalyzer.CardsCount[(long)Card.CardName.Three]);
            Assert.Equal(1, CardsAnalyzer.CardsCount[(long)Card.CardName.Four]);
            Assert.Equal(1, CardsAnalyzer.CardsCount[(long)Card.CardName.Five]);
            Assert.Equal(1, CardsAnalyzer.CardsCount[(long)Card.CardName.Six]);
            Assert.Equal(1, CardsAnalyzer.CardsCount[(long)Card.CardName.Jack]);

            hand = 0x000FFFFFFFFFFFFF;
            CardsAnalyzer.CountCards(hand);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Two]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Three]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Four]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Five]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Six]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Seven]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Eight]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Nine]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Ten]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Jack]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Queen]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.King]);
            Assert.Equal(4, CardsAnalyzer.CardsCount[(long)Card.CardName.Ace]);
        }

        [Trait("Category", "Miscelleneaous")]
        [Fact]
        public void TwoClubs()
        {
            // 00000000 000//0.0000 0000.0001 1/000.0000 0000.11/00 0000.0000 011/0.0000 0000.0011
            long hand = 0x000001800C006003;
            Club clubs = new Club(hand);
            Assert.Equal(0x0000000000000003, (clubs.Mask & hand));
            Assert.Equal("0000000000011", clubs.ToBinaryString());
        }


        [Trait("Category", "Miscelleneaous")]
        [Fact]
        public void TwoDiamonds()
        {
            long hand = 0x000001800C006003;
            Diamond diamonds = new Diamond(hand);
            Assert.Equal(0x0000000000006000, (diamonds.Mask & hand));
            Assert.Equal("0000000000011", diamonds.ToBinaryString());
        }

        [Trait("Category", "Miscelleneaous")]
        [Fact]
        public void TwoSpades()
        {

            long hand = 0x000001800C006003;
            Spade spades = new Spade(hand);
            Assert.Equal(0x000000000C000000, (spades.Mask & hand));
            Assert.Equal("0000000000011", spades.ToBinaryString());
        }

        [Trait("Category", "Miscelleneaous")]
        [Fact]
        public void TwoHearts()
        {
            long hand = 0x000001800C006003;
            Heart hearts = new Heart(hand);
            Assert.Equal(0x0000018000000000, (hearts.Mask & hand));
            Assert.Equal("0000000000011", hearts.ToBinaryString());
        }

        [Trait("Category", "Four of a kind")]
        [Fact]
        public void FourOfAKind()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.01/00 0000.0000 001/0.0000 0000.0001
            long fourOfAKind = 0x0000008004002001;
            Assert.True(CardsAnalyzer.IsFourOfAKind(fourOfAKind),"Hand got four of a kind only (all aces), four of a kind expected");
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.01/01 0000.0000 001/0.0000 0000.0111
            fourOfAKind = 0x0000008005002007;
            Assert.True(CardsAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind among other cards, four of a kind expected");
            // 00000000 0000//1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000
            fourOfAKind = 0x0000008005002007;
            Assert.True(CardsAnalyzer.IsFourOfAKind(fourOfAKind), "Hand got four of a kind (all kings), four of a kind expected");
        }

        [Trait("Category", "Four of a kind")]
        [Fact]
        public void NotFourOfAKind()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0001
            long notFourOfAKind = 0x0000008003002001;
            Assert.False(CardsAnalyzer.IsFourOfAKind(notFourOfAKind));
        }

        [Trait("Category", "Three of a kind")]
        [Fact]
        public void ThreeOfAKind()
        {
            // 00000000 00000000 00000000 00000000 00000100 00000000 00100000 00000001
            long threeOfAKind = 0x0000000004002001;
            Assert.True(CardsAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got three of a kind, three of a kind expected");
        }

        [Trait("Category", "Three of a kind")]
        [Fact]
        public void NotThreeOfAKind()
        {
            // 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long threeOfAKind = 0x0000008005002007;
            Assert.False(CardsAnalyzer.IsThreeOfAKind(threeOfAKind), "Hand got four of a kind, three of a kind not expected");
        }

        [Trait("Category", "Pair")]
        [Fact]
        public void OnePair()
        {
            // 00000000 00000000 00000000 00000000 00000000 00000000 00100000 00000001
            long aPair = 0x0000000000002001;
            Assert.True(CardsAnalyzer.IsAPair(aPair), "Hand got a pair, pair expected");
        }

        [Trait("Category", "Pair")]
        [Fact]
        public void NotOnePair()
        {
            // 00000000 00000000 00000000 10000000 00000101 00000000 00100000 00000111
            long aPair = 0x0000008005002007;
            Assert.False(CardsAnalyzer.IsAPair(aPair), "Hand got four of a kind, pair not expected");
        }

        [Trait("Category", "StraightFlush")]
        [Fact]
        public void StraightFlush()
        {
            // 00000000 00000000 00000000 00000000 00000000 01000000 00100000 00011111
            long straightFlushHand = 0x000000000040201F;
            Assert.True(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x00000000004020F8;
            Assert.True(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x00000F8000000000;
            Assert.True(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            straightFlushHand = 0x000F800000000000;
            Assert.True(CardsAnalyzer.IsStraightFlush(straightFlushHand));
            // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1111
            straightFlushHand = 0x000000000040300F;
            Assert.True(CardsAnalyzer.IsStraightFlush(straightFlushHand), "Hand got a `petite` straight flush i.e. 12345 ");
        }

        [Fact]
        [Trait("Category", "Count Bits")]
        public void HandHas6BitsSet()
        {
            // 00000000 0000//0000 00000000 0/0000000 000000/00 01000000 001/10000 00001110
            long hand = 0x000000000040201E;
            Assert.Equal(6, CardsAnalyzer.CountSetBits(hand));
            
        }

        [Fact]
        [Trait("Category", "Count Bits")]
        public void HandHas52BitsSet()
        {
            // 0000.0000 0000//.0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/1.0000 0000.1110
            long hand = 0x000FFFFFFFFFFFFF;
            Assert.Equal(52, CardsAnalyzer.CountSetBits(hand));
        }

        [Fact]
        [Trait("Category", "Flush")]
        public void HandIsAFlush()
        {
            // 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 001/0.0010 0001.1111
            long hand = 0x000000000000331F;
            Assert.True(CardsAnalyzer.IsFlush(hand), "Hand got a flush, flush expected");
        }

        [Fact]
        [Trait("Category", "Flush")]
        public void HandIsNotAFlush()
        {
            // 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.False(CardsAnalyzer.IsFlush(hand), "Hand did not got a flush, flush not expected");
        }

        [Trait("Category", "Straight")]
        [Fact]
        public void IsStraightAndSpecialStraight()
        {
            // 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.0001 0001.1111
            long hand = 0x000000000000111F;
            Assert.True(CardsAnalyzer.IsStraight(hand), "Hand got a straight, straight expected");
            // 00000000 000//0.0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/1.1001 0000.1111
            hand = 0x000000000000190F;
            Assert.True(CardsAnalyzer.IsStraight(hand), "Hand got a special straight (12345), straight expected");
        }

        [Trait("Category", "Straight")]
        [Fact]
        public void IsNotStraight()
        {
            // 00000000 000//0.0000 0000.0000 0/000.0000 0001.00/01 0001.0001 000/1.0001 0001.0001
            long hand = 0x0000000001111111;
            Assert.False(CardsAnalyzer.IsStraight(hand), "Hand did not got a straight, straight not expected");
        }

        [Trait("Category", "FullHouse")]
        [Fact]
        public void IsFullHouse()
        {
            // 00000000 0000//0000 0000.0000 1/000.0110 0000.00/10 0000.0000 001/1.0000 0000.0001
            long fullHouse = 0x0000008602003001;
            Assert.True(CardsAnalyzer.IsFullHouse(fullHouse), "Hand did got a full house, full house is expected");
        }

        [Trait("Category", "FullHouse")]
        [Fact]
        public void IsNotFullHouse()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0111
            long notFullHouse = 0x0000008003002007;
            Assert.False(CardsAnalyzer.IsFullHouse(notFullHouse), "Hand did not got a full house, full house is not expected");
            // 00000000 0000//1000 0000.0000 0/100.0000 0000.01/10 0000.0000 001/1.0000 0000.0001
            notFullHouse = 0x0008004006003001;
            Assert.False(CardsAnalyzer.IsFullHouse(notFullHouse), "Hand got four of a kind, full house is not expected");
        }

        [Trait("Category", "TwoPairs")]
        [Fact]
        public void IsTwoPairs()
        {
            // 00000000 0000//0000 0000.0000 0/000.0010 0000.00/10 0100.0000 001/1.0010 0000.0001
            long twoPairs = 0x0000000602003001;
            Assert.True(CardsAnalyzer.IsTwoPairs(twoPairs), "Hand did got two pairs, two pairs are expected");
        }

        [Trait("Category", "TwoPairs")]
        [Fact]
        public void IsNotTwoPairs()
        {
            // 00000000 0000//0000 0000.0000 1/000.0000 0000.00/11 0000.0000 001/0.0000 0000.0001
            long notTwoPairs = 0x0000008003002001;
            Assert.False(CardsAnalyzer.IsTwoPairs(notTwoPairs), "Hand did not got a full house, full house is not expected");
            // Four of a kind + three of a kind
            // 00000000 0000//1000 0000.0000 0/100.0000 0000.01/10 0000.0000 001/1.0000 0000.0001
            notTwoPairs = 0x0008004006003001;
            Assert.False(CardsAnalyzer.IsTwoPairs(notTwoPairs), "Hand did not got a full house, full house is not expected");
        }
    }
}
