using System;
using System.Collections.Generic;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class PokerHand : IComparable<PokerHand>
    {
        protected readonly HoleCards HoleCards;
        private readonly long _pokerHand;
        public CardsCollection Board { get; set; }
        public PokerHandAnalyzer.Strength Strength;
        public CardsCollection Kickers { get; private set; }

        public PokerHand(long hand)
        {
            _pokerHand = hand;
            Kickers = new CardsCollection();
        }

        public PokerHand(HoleCards holeCards, CardsCollection board)
        {
            HoleCards = holeCards;
            Board = board;
            _pokerHand = holeCards.ToLong();
            foreach (var card in Board)
            {
                _pokerHand |= Convert.ToInt64(card.AbsoluteValue);
            }
            Kickers = new CardsCollection();
        }

        /// <summary>
        /// Better hand (current instance) returns -1, same returns 0, othersie -1
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PokerHand other)
        {
            var result = Strength.CompareTo(other.Strength);
            if (result != 0)
            {
                return result;
            }
            for (var i = 0; i < Kickers.Count; i++)
            {
                result = Kickers[i].CompareTo(other.Kickers[i]) * -1;
                if (result != 0)
                {
                    break;
                }

            }
            return result;
        }

        public override bool Equals(object o)
        {
            var ph = o as PokerHand;
            return ph?.CompareTo(this) == 0;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(_pokerHand);
        }

        public long ToLong()
        {
            return _pokerHand;
        }

        public override string ToString()
        {
            return $"Hole Cards[{HoleCards}] and Board[{Board}]. Best Poker Hand is {Strength}.";
        }

    }
}
