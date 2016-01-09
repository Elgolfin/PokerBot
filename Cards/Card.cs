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
    public class Card : IComparable, IComparable<Card>
    {

        #region Properties

        // Represent the value of the bit in the 52 cards bits sequence (see CardUnitTests for example)
        public ulong AbsoluteValue { get; set; }
        // 2 = 2, 3= 3, ..., T = 10, J = 11, Q = 12, K = 13, A = 14
        public int RelativeValue { get; set; }
        public Deck52cards.SuitName Suit { get; set; }

        /// <summary>
        /// Return the short name of the card
        /// <example>Method will return the string "As" for the As of spade</example>
        /// </summary>
        public override string ToString()
        {
            string _shortName = String.Empty;
            switch (AbsoluteValue)
            {
                case 10:
                    _shortName = "T";
                    break;
                case 11:
                    _shortName = "J";
                    break;
                case 12:
                    _shortName = "Q";
                    break;
                case 13:
                    _shortName = "K";
                    break;
                case 14:
                    _shortName = "A";
                    break;
                default:
                    _shortName = AbsoluteValue.ToString();
                    break;
            }

            switch (Suit)
            {
                case Deck52cards.SuitName.Clubs:
                    _shortName += "c";
                    break;
                case Deck52cards.SuitName.Diamonds:
                    _shortName += "d";
                    break;
                case Deck52cards.SuitName.Hearts:
                    _shortName += "h";
                    break;
                case Deck52cards.SuitName.Spades:
                    _shortName += "s";
                    break;
            }

            return _shortName;

        }

        #endregion

        #region Constructors
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Format: Value(ulong) = Card(string)
        /// 0=2, 1=3, 2=4, 3=5, 4=6, 5=7, 6=8, 7=9, 8=T, 9=J, 10=Q, 11=K, 12=A
        /// </summary>
        /// <param name="value"></param>
        private void SetValue(string value)
        {
            switch (value.ToUpper())
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
                    double cardValue = Convert.ToDouble(value) - 2;
                    if (cardValue < 8 && cardValue >= 0)
                    {
                        AbsoluteValue = Convert.ToUInt64(Math.Pow(2, cardValue));
                        RelativeValue = Convert.ToInt32(value);
                    }
                    else
                    {
                        throw new Exception(String.Format("Unknown Card Value [{0}]", value.ToUpper()));
                    }
                    break;
            }
        }

        private void SetFamily(string familyAbbr)
        {
            switch (familyAbbr.ToUpper())
            {
                case "C":
                    Suit = Deck52cards.SuitName.Clubs;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "D":
                    Suit = Deck52cards.SuitName.Diamonds;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "H":
                    Suit = Deck52cards.SuitName.Hearts;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "S":
                    Suit = Deck52cards.SuitName.Spades;
                    AbsoluteValue <<= (int)Suit;
                    break;
                default:
                    throw new Exception(String.Format("Unknown Card Family [{0}]", familyAbbr.ToLower()));
            }
        }

        #endregion

        #region IComparable Members

        int IComparable.CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card otherCard = (Card)obj;
                return AbsoluteValue.CompareTo(otherCard.AbsoluteValue);
            }
            else
            {
                throw new ArgumentException("Object is not a Card");
            }
        }

        #endregion

        #region IComparable<Card> Members

        int IComparable<Card>.CompareTo(Card other)
        {
            return AbsoluteValue.CompareTo(other.AbsoluteValue);
        }

        #endregion
    }
}
