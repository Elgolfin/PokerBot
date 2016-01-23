using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class PokerHand : IComparable<PokerHand>
    {
        protected readonly HoleCards Hand;
        private readonly long _pokerHand;
        public List<Card> Board { get; set; }
        public PokerHandAnalyzer.Strength Strength;
        public List<Card> Kickers { get; private set; }

        public PokerHand(long hand)
        {
            _pokerHand = hand;
            Kickers = new List<Card>();
        }

        public PokerHand(HoleCards hand, List<Card> board)
        {
            Hand = hand;
            Board = board;
            _pokerHand = hand.ToLong();
            foreach (var card in Board)
            {
                _pokerHand |= Convert.ToInt64(card.AbsoluteValue);
            }
            Kickers = new List<Card>();
        }

        public int CompareTo(PokerHand other)
        {
            var result = Strength.CompareTo(other.Strength);
            if (result != 0)
            {
                return result;
            }
            for (var i = 0; i < Kickers.Count; i++)
            {
                result = Kickers[i].CompareTo(other.Kickers[i]);
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
