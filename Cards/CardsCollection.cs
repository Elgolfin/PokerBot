using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicomputer.PokerBot.Cards
{

    public class CardsCollection : IEnumerable<Card>
    {
        private readonly List<Card> _cards;
        public int Count
        {
            get { return _cards.Count; }
        }
        public CardsCollection()
        {
            _cards = new List<Card>();
        }

        public CardsCollection(int capacity)
        {
            _cards = new List<Card>(capacity);
        }

        public CardsCollection(string myCards)
        {
            var cards = myCards.Split(' ');
            _cards = new List<Card>();
            foreach (var card in cards)
            {
                _cards.Add(new Card(card));
            }

        }



        public Card this[int index]
        {
            get
            {
                return this.Skip(index).FirstOrDefault();
            }
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Sort()
        {
            _cards.Sort();
            _cards.Reverse();
        }

        /// <summary>
        /// Sort the cards from the highest to the lowest
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in _cards)
            {
                sb.Append($"{card} ");
            }
            return sb.ToString().Trim();
        }
    }
}
