using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Dealer
    {
        public Deck52Cards Deck;
        public Table Table;

        public Dealer(Table t, Deck52Cards deck)
        {
            Deck = deck;
            Table = t;
        }

        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DealHands()
        {
            // Dealer... deals
            // ... First Card
            DealHandCard(true);
            // ... Second Card
            DealHandCard(false);
        }

        private void DealHandCard(bool isFirstCard)
        {
            var occupiedSeats = Table.GetOccupiedSeatsOrderByToBeDealt();
            foreach (var seat in occupiedSeats)
            {
                if (isFirstCard)
                {
                    seat.Hand = new Hand();
                    seat.Hand.FirstCard = Deck.Deal();
                }
                else
                {
                    seat.Hand.SecondCard = Deck.Deal();
                }
            }
        }

        private void DealBoardCards(int numCards)
        {
            Deck.Burn();
            for (var i = 0; i < numCards; i++)
            {
                Table.Board.Add(Deck.Deal());
            }
        }

        public void DealFlop()
        {
            DealBoardCards(3);
        }

        public void DealTurn()
        {
            DealBoardCards(1);
        }

        public void DealRiver()
        {
            DealBoardCards(1);
        }
    }
}
