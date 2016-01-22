using System.Collections.Generic;
using System;

namespace Nicomputer.PokerBot.Cards
{
    public class HandAnalyzer : IComparable<HandAnalyzer>
    {
        public Hand Hand { get; }
        private readonly long _pokerHand;
        public List<Card> Board { get; set; }
        public Strength HandStrength;
        public List<Card> Kickers { get; private set; }

        public enum Strength
        {
            StraightFlush = 9,
            FourOfAKind = 8,
            FullHouse = 7,
            Flush = 6,
            Straight = 5,
            ThreeOfAKind = 4,
            TwoPairs = 3,
            OnePair = 2,
            HighCard = 1
        }

        public HandAnalyzer(Hand hand, List<Card> board)
        {
            Hand = hand;
            Board = board;
            _pokerHand = hand.ToLong();
            foreach (var card in Board)
            {
                _pokerHand |= Convert.ToInt64(card.AbsoluteValue);
            }
            GetBestPokerHand();
        }

        // TODO set the kickers
        private void GetBestPokerHand()
        {
            HandStrength = Strength.HighCard;
            if (CardsAnalyzer.IsStraightFlush(_pokerHand))
            {
                HandStrength = Strength.StraightFlush;
                // Kickers = 5 cards of the Straight Flush
            }
            if (CardsAnalyzer.IsFourOfAKind(_pokerHand))
            {
                HandStrength = Strength.FourOfAKind;
                // Kickers = best card remaining after the four of a kind
            }
            if (CardsAnalyzer.IsFullHouse(_pokerHand))
            {
                HandStrength = Strength.FullHouse;
                // Kickers = two cards (high pair, low pair)
            }
            if (CardsAnalyzer.IsFlush(_pokerHand))
            {
                HandStrength = Strength.Flush;
                // Kickers = 5 cards of the Flush
            }
            if (CardsAnalyzer.IsStraight(_pokerHand))
            {
                HandStrength = Strength.Straight;
                // Kickers = High card of the Straight
            }
            if (CardsAnalyzer.IsThreeOfAKind(_pokerHand))
            {
                HandStrength = Strength.ThreeOfAKind;
                // Kickers = Two highest remaining cards
            }
            if (CardsAnalyzer.IsTwoPairs(_pokerHand))
            {
                HandStrength = Strength.TwoPairs;
                // Kickers = three cards (high pair, low pair, remaining highest card)
            }
            if (CardsAnalyzer.IsAPair(_pokerHand))
            {
                HandStrength = Strength.OnePair;
                // Kickers = Three highest remaining cards
            }
        }

        public int CompareTo(HandAnalyzer other)
        {
            var result = HandStrength.CompareTo(other.HandStrength);
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

    }
}
