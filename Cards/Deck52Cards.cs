using System;
using System.Collections.Generic;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.Cards
{
    /// <summary>
    /// 00000000 00000000 00000000 00000000 00000000 00000000 00011111 11111111 (0x0000000000001FFF) clubs mask
    /// </summary>
    /// <remarks>
    /// 00000000 00000000 00000000 00000000 00000011 11111111 11100000 00000000 (0x0000000003FFE000) diamonds mask 
    /// 00000000 00000000 00000000 01111111 11111100 00000000 00000000 00000000 (0x0000007FFC000000) spades mask
    /// 00000000 00001111 11111111 10000000 00000000 00000000 00000000 00000000 (0x000FFF8000000000) hearts mask
    /// 00000000 00001111 11111111 11111111 11111111 11111111 11111111 11111111 (0x000FFFFFFFFFFFFF) 52 cards mask 
    /// </remarks>
    public class Deck52Cards : AbstractSuit
    {
        private List<Card> _cards = new List<Card>(52);

        public Deck52Cards()
            : base(52, 0x000FFFFFFFFFFFFF, 0)
        {
            Cards = 0x000FFFFFFFFFFFFF;
            InitDeck();
        }

        public List<Card> GetCards()
        {
            return _cards;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly Random Rand = new Random();
        /// <summary>
        /// Shuffle the deck
        /// Based on Fisher-Yates Shuffle
        /// http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        public void Shuffle()
        {
            InitDeck();
            for (int n = _cards.Count - 1; n > 0; --n)
            {
                int k = Rand.Next(n + 1);
                Card temp = _cards[n];
                _cards[n] = _cards[k];
                _cards[k] = temp;
            }
        }

        /// <summary>
        /// Deal next card in the deck (and remove it from the deck)
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        {
            Card ret = _cards[0];
            _cards.RemoveAt(0);
            return ret;
        }

        /// <summary>
        /// Burn next card in the deck (actually, this method is an alias for the Deal method)
        /// </summary>
        /// <returns></returns>

        public void Burn()
        {
            Deal();
        }

        /// <summary>
        /// Reset the deck
        /// </summary>
        private void InitDeck()
        {
            _cards = new List<Card>(52);
            InitFamilyCards(Card.SuitName.Clubs);
            InitFamilyCards(Card.SuitName.Diamonds);
            InitFamilyCards(Card.SuitName.Hearts);
            InitFamilyCards(Card.SuitName.Spades);
        }

        private void InitFamilyCards(Card.SuitName family)
        {
            for (int i = 2; i <= 14; i++)
            {
                _cards.Add(new Card(i, family));
            }
        }

        public override bool Equals(Object o)
        {
            var deck = o as Deck52Cards;
            if (deck == null)
            {
                return false;
            }

            if (deck._cards.Count != _cards.Count)
            {
                return false;
            }

            for (var i = 0; i < _cards.Count; i++)
            {
                if (!deck._cards[i].Equals(_cards[i]))
                {
                    return false;
                }
            }
            return true;

        }

    }

    
}
