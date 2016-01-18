using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nicomputer.PokerBot.Cards
{
    /// <summary>
    /// The Card Object
    /// </summary>
    public class Card : IComparable<Card>
    {
        /// <summary>
        /// Represent the value of the bit in the 52 cards bits sequence (see CardUnitTests for example)
        /// </summary>
        public ulong AbsoluteValue { get; set; }
         
        /// <summary>
        /// 2 = 2, 3= 3, ..., T = 10, J = 11, Q = 12, K = 13, A = 14
        /// </summary>
        public int RelativeValue { get; set; }
        public SuitName Suit { get; set; }
        public enum CardName : long
        {
            Two = 0x0001, // 0 0000 0000 0001
            Three = 0x0002, // 0 0000 0000 0010 
            Four = 0x0004, // 0 0000 0000 0100
            Five = 0x0008, // 0 0000 0000 1000
            Six = 0x0010, // 0 0000 0001 0000
            Seven = 0x0020, // 0 0000 0010 0000
            Eight = 0x0040, // 0 0000 0100 0000
            Nine = 0x0080, // 0 0000 1000 0000
            Ten = 0x0100, // 0 0001 0000 0000
            Jack = 0x0200, // 0 0010 0000 0000
            Queen = 0x0400, // 0 0100 0000 0000
            King = 0x0800, // 0 1000 0000 0000
            Ace = 0x1000  // 1 0000 0000 0000
        };
        public enum SuitName
        {
            Clubs = 0,
            Diamonds = 13,
            Spades = 26,
            Hearts = 39
        };

        /// <summary>
        /// Return the short name of the card
        /// <example>Method will return the string "As" for the As of spade</example>
        /// </summary>
        public override string ToString()
        {
            var shortName = GetValueShortName();
            shortName += GetSuitShortName();
            return shortName;
        }

        private string GetSuitShortName()
        {
            var shortName = String.Empty;
            switch (Suit)
            {
                case SuitName.Clubs:
                    shortName = "c";
                    break;
                case SuitName.Diamonds:
                    shortName = "d";
                    break;
                case SuitName.Hearts:
                    shortName = "h";
                    break;
                case SuitName.Spades:
                    shortName = "s";
                    break;
            }
            return shortName;
        }

        private string GetValueShortName()
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
            return shortName;
        }

        /// <summary>
        /// Instanciate a Card object from its abbreviated form (the abbreviated form is case insensitive)
        /// i.e. Qs, QS, qS or qs for the Queen of Spades
        /// </summary>
        /// <param name="abbr"></param>
        public Card(string abbr)
        {
            var abbreviation = abbr.ToUpper(CultureInfo.InvariantCulture).Trim();
            var regex = new Regex("^[2-9TJQKA][CDHS]$");

            if (regex.IsMatch(abbreviation))
            {
                SetValue(abbr.Substring(0, 1));
                SetFamily(abbr.Substring(1, 1));
            }
        }

        public Card(int relativeValue, SuitName suit)
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
            switch (relativeValue.ToUpper(CultureInfo.InvariantCulture))
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
            switch (familyAbbr.ToUpper(CultureInfo.InvariantCulture))
            {
                case "C":
                    Suit = SuitName.Clubs;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "D":
                    Suit = SuitName.Diamonds;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "H":
                    Suit = SuitName.Hearts;
                    AbsoluteValue <<= (int)Suit;
                    break;
                case "S":
                    Suit = SuitName.Spades;
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
            return (c?.RelativeValue == RelativeValue && c?.Suit == Suit);
        }
    }
}
