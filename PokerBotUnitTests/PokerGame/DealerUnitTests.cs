using Xunit;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    
    public class DealerUnitTests
    {
        [Fact]
        public void Dealer_Deals_Hands_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.ShuffleDeck();
            var firstDealedCard = table.Dealer.Deck.GetCards()[0];
            var lastDealedCard = table.Dealer.Deck.GetCards()[17];
            table.Dealer.DealHands();
            Assert.Equal(52 - 9 * 2, table.Dealer.Deck.GetCards().Count);
            for (int i = 0; i < table.NumberOfPlayers; i++)
            {
                Assert.Equal(true, table.Seats[i].Hand.FirstCard != null);
                Assert.Equal(true, table.Seats[i].Hand.SecondCard != null);
            }
            Assert.Equal(table.Seats[table.SmallBlindPosition].Hand.FirstCard, firstDealedCard);
            Assert.Equal(table.Seats[table.ButtonPosition].Hand.SecondCard, lastDealedCard);
        }

        [Fact]
        public void Dealer_Deals_Hands_Table_6()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 6);
            table.Dealer.ShuffleDeck();
            var firstDealedCard = table.Dealer.Deck.GetCards()[0];
            var lastDealedCard = table.Dealer.Deck.GetCards()[11];
            table.Dealer.DealHands();
            Assert.Equal(52 - 6 * 2, table.Dealer.Deck.GetCards().Count);
            for (int i = 0; i < table.NumberOfPlayers; i++)
            {
                Assert.Equal(true, table.Seats[i].Hand.FirstCard != null);
                Assert.Equal(true, table.Seats[i].Hand.SecondCard != null);
            }
            Assert.Equal(table.Seats[table.SmallBlindPosition].Hand.FirstCard, firstDealedCard);
            Assert.Equal(table.Seats[table.ButtonPosition].Hand.SecondCard, lastDealedCard);
        }

        [Fact]
        public void Dealer_Deals_Hands_Table_2()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 2);
            table.Dealer.ShuffleDeck();
            var firstDealedCard = table.Dealer.Deck.GetCards()[0];
            var lastDealedCard = table.Dealer.Deck.GetCards()[3];
            table.Dealer.DealHands();
            Assert.Equal(52 - 2 * 2, table.Dealer.Deck.GetCards().Count);
            for (int i = 0; i < table.NumberOfPlayers; i++)
            {
                Assert.Equal(true, table.Seats[i].Hand.FirstCard != null);
                Assert.Equal(true, table.Seats[i].Hand.SecondCard != null);
            }
            Assert.Equal(table.Seats[table.BigBlindPosition].Hand.FirstCard, firstDealedCard);
            Assert.Equal(table.Seats[table.ButtonPosition].Hand.SecondCard, lastDealedCard);
        }

        [Fact]
        public void Dealer_Deals_Flop_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            Assert.Equal(52 - 9 * 2 - 4, table.Dealer.Deck.GetCards().Count);
        }

        [Fact]
        public void Dealer_Deals_Turn_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            table.Dealer.DealTurn();
            Assert.Equal(52 - 9 * 2 - 4 - 2, table.Dealer.Deck.GetCards().Count);
        }

        [Fact]
        public void Dealer_Deals_River_Table_Full()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            table.Dealer.DealHands();
            table.Dealer.DealFlop();
            table.Dealer.DealTurn();
            table.Dealer.DealRiver();
            Assert.Equal(52 - 9 * 2 - 4 - 2 - 2, table.Dealer.Deck.GetCards().Count);
        }
    }
}
