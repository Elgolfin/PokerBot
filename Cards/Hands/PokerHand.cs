using System;
using System.Collections.Generic;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class PokerHand : IComparable<PokerHand>
    {
        protected readonly HoleCards HoleCards;
        private readonly long _pokerHand;
        public List<Card> Board { get; set; }
        public PokerHandAnalyzer.Strength Strength;
        public List<Card> Kickers { get; private set; }

        public PokerHand(long hand)
        {
            _pokerHand = hand;
            Kickers = new List<Card>();
        }

        public PokerHand(HoleCards holeCards, List<Card> board)
        {
            HoleCards = holeCards;
            Board = board;
            _pokerHand = holeCards.ToLong();
            foreach (var card in Board)
            {
                _pokerHand |= Convert.ToInt64(card.AbsoluteValue);
            }
            Kickers = new List<Card>();
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

        public long ToLong()
        {
            return _pokerHand;
        }

    }
}
