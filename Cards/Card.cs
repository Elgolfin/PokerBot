using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nicomputer.PokerBot.Cards
{
    /// <summary>
    /// The Card Object
    /// </summary>
    public class Card : IComparable<Card>
    {

        

        // Represent the value of the bit in the 52 cards bits sequence (see CardUnitTests for example)
        public ulong AbsoluteValue { get; set; }
        // 2 = 2, 3= 3, ..., T = 10, J = 11, Q = 12, K = 13, A = 14
        public int RelativeValue { get; set; }
        public Deck52Cards.SuitName Suit { get; set; }

        /// <summary>
        /// Return the short name of the card
        /// <example>Method will return the string "As" for the As of spade</example>
        /// </summary>
        public override string ToString()
        {
            string shortName;
            switch (RelativeValue)
            {
                case 10:
                    shortName = "T";
                    break;
                case 11:
                    shortName = "J";
                    break;
                case 12:
                    shortName = "Q";
                    break;
                case 13:
                    shortName = "K";
                    break;
                case 14:
                    shortName = "A";
                    break;
                default:
                    shortName = RelativeValue.ToString();
                    break;
            }

            switch (Suit)
            {
                case Deck52Cards.SuitName.Clubs:
                    shortName += "c";
                    break;
                case Deck52Cards.SuitName.Diamonds:
                    shortName += "d";
                    break;
                case Deck52Cards.SuitName.Hearts:
                    shortName += "h";
                    break;
                case Deck52Cards.SuitName.Spades:
                    shortName += "s";
                    break;
            }

            return shortName;

        }
        /// <summary>
        /// Instanciate a Card object from its abbreviated form (the abbreviated form is case insensitive)
        /// i.e. Qs, QS, qS or qs for the Queen of Spades
        /// </summary>
        /// <param name="abbr"></param>
        public Card(string abbr)
        {
            abbr = abbr.ToUpper().Trim();
            Regex regex = new Regex("^[2-9TJQKA][CDHS]$");

            if (regex.IsMatch(abbr))
            {
                SetValue(abbr.Substring(0, 1));
                SetFamily(abbr.Substring(1, 1));
            }
        }

        public Card(int relativeValue, Deck52Cards.SuitName suit)
        {
            RelativeValue = relativeValue;
            AbsoluteValue = Convert.ToUInt64(Math.Pow(2, relativeValue - 2));
            Suit = suit;
            AbsoluteValue <<= (int)Suit;
        }

        /// <summary>
        /// Format: Value(ulong) = Card(string)
        /// 0=2, 1=3, 2=4, 3=5, 4=6, 5=7, 6=8, 7=9, 8=T, 9=J, 10=Q, 11=K, 12=A
        /// </summary>
        /// <param name="relativeValue"></param>
        private void SetValue(string relativeValue)
        {
            switch (relativeValue.ToUpper())
            {
                case "T":
                    AbsoluteValue = Convert.ToUInt64(Math.Pow(2,8));
                    RelativeValue = 10;
                    break;
                case "J":
                    AbsoluteValue = Convert.ToUInt64(Math.Pow(2, 9));
                    RelativeValue = 11;
                    break;
                case "Q":
                    AbsoluteValue = Convert.ToUInt64(Math.Pow(2, 10));
                    RelativeValue = 12;
                    break;
                case "K":
                    AbsoluteValue = Convert.ToUInt64(Math.Pow(2, 11));
                    RelativeValue = 13;
                    break;
                case "A":
                    AbsoluteValue = Convert.ToUInt64(Math.Pow(2, 12));
                    RelativeValue = 14;
                    break;
                default:
                    double cardValue = Convert.ToDouble(relativeValue) - 2;
                    if (cardValue <10  && cardValue >= 0)
                    {
                        AbsoluteValue = Convert.ToUInt64(Math.Pow(2, cardValue));
                        RelativeValue = Convert.ToInt32(relativeValue);
                    }
                    break;
            }
        }

        private void SetFamily(string familyAbbr)
        {
            switch (familyAbbr.ToUpper())
            {
                case "C":
                    Suit = Deck52Cards.SuitName.Clubs;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "D":
                    Suit = Deck52Cards.SuitName.Diamonds;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "H":
                    Suit = Deck52Cards.SuitName.Hearts;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "S":
                    Suit = Deck52Cards.SuitName.Spades;
                    AbsoluteValue <<= (int)Suit;
                    break;
            }
        }

       public int CompareTo(Card other)
        {
            return RelativeValue.CompareTo(other.RelativeValue);
        }

        public override bool Equals(Object o)
        {
            var c = o as Card;
            if (c == null)
            {
                return false;
            }
            if (c.RelativeValue == RelativeValue && c.Suit == Suit)
            {
                return true;
            }
            return false;
        }

    }
}
