using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicomputer.PokerBot.Cards
{
    // TODO add unit tests for Hand
    public class Hand
    {
        public Card FirstCard;
        public Card SecondCard;

        private int _billChenValue = 0;
        private int _billChenGroupValue = 0;

        private List<Card> _cards = null;
        public List<Card> Cards
        {
            get
            {
                _cards = new List<Card>(2);
                _cards.Add(FirstCard);
                _cards.Add(SecondCard);
                return _cards;
            }
            set { }
        }

        private string _shortName = String.Empty;
        public string ShortName
        {
            get
            {
                if (String.IsNullOrEmpty(_shortName))
                {
                    _shortName = $"{(HighCard.ToString().Substring(0, 1))}{(LowCard.ToString().Substring(0, 1))}";
                    if (SameSuit)
                    {
                        _shortName += "s";
                    }
                }
                return _shortName;
            }
        }

        private string _longName = String.Empty;
        public string LongName
        {
            get
            {
                if (String.IsNullOrEmpty(_longName))
                {
                    _longName = $"{(HighCard.ToString())}{(LowCard.ToString())}";
                }
                return _longName;
            }
        }

        private Card _highCard = null;
        private Card _lowCard = null;
        public Card HighCard
        {
            get
            {
                if (_highCard == null)
                {
                    GetHighNLowCard();
                }
                return _highCard;
            }
        }

        public Card LowCard
        {
            get
            {
                if (_lowCard == null)
                {
                    GetHighNLowCard();
                }
                return _lowCard;
            }
        }

        /// <summary>
        /// Check for the both high and low cards of the current hand
        /// </summary>
        private void GetHighNLowCard()
        {
            if (FirstCard.AbsoluteValue == 1 || (SecondCard.AbsoluteValue > 1 && FirstCard.AbsoluteValue >= SecondCard.AbsoluteValue))
            {
                _highCard = FirstCard;
                _lowCard = SecondCard;
            }
            else
            {
                _highCard = SecondCard;
                _lowCard = FirstCard;
            }
        }

        public bool SameSuit
        {
            get
            {
                return (FirstCard.Suit == SecondCard.Suit);
            }
        }

        public bool Pair
        {
            get
            {
                return (FirstCard.AbsoluteValue == SecondCard.AbsoluteValue);
            }
        }

        /// <summary>
        /// Calculate the Bill Chen value of the hand (hand value are classified in 5 tiers)
        /// </summary>
        /// <returns></returns>
        public int BillChenGroupValue
        {
            get
            {
                if (_billChenGroupValue == 0)
                {
                    _billChenGroupValue = 9;
                    if (_billChenValue == 5)
                    {
                        _billChenGroupValue = 7;
                    }

                    if (_billChenValue >= 6)
                    {
                        _billChenGroupValue = 5;
                    }

                    if (_billChenValue == 8)
                    {
                        _billChenGroupValue = 4;
                    }

                    if (_billChenValue == 9)
                    {
                        _billChenGroupValue = 3;
                    }

                    if (_billChenValue >= 10)
                    {
                        _billChenGroupValue = 2;
                    }

                    if (_billChenValue >= 12)
                    {
                        _billChenGroupValue = 1;
                    }

                    // Exceptions
                    string[] addOne = { "J8s", "96s", "86s", "75s", "65s", "54s", "32s", "AT", "A9", "KT", "QT", "Q9", "T8", "87", "76" };
                    string[] substractOne = { "ATs", "J7s", "85s", "74s", "42s", "65", "55", "54" };
                    string[] setTo7 = { "K9s", "J9", "T9", "98" };
                    string[] setTo8 = { "K9", "J8" };
                    string[] setTo9 = { "A8", "A7", "A6", "A5", "A4", "A3", "A2", "97" };
                    if (addOne.Contains<string>(ShortName))
                    {
                        _billChenGroupValue++;
                    }
                    if (substractOne.Contains<string>(ShortName))
                    {
                        _billChenGroupValue--;
                    }
                    if (setTo7.Contains<string>(ShortName))
                    {
                        _billChenGroupValue = 7;
                    }
                    if (setTo8.Contains<string>(ShortName))
                    {
                        _billChenGroupValue = 8;
                    }
                    if (setTo9.Contains<string>(ShortName))
                    {
                        _billChenGroupValue = 9;
                    }

                }
                return _billChenGroupValue;
            }
        }

        public int BillChenValue
        {
            get
            {
                if (_billChenValue == 0)
                {

                    int gapPenalty = 0;
                    _billChenValue = ScoresHighCard();
                    if (Pair)
                    {
                        _billChenValue *= 2;
                    }
                    else
                    {
                        // Calculate the gap penalty
                        gapPenalty = HighCard.RelativeValue - LowCard.RelativeValue - 1;
                        if (HighCard.AbsoluteValue == 1)
                        {
                            gapPenalty = 14 - LowCard.RelativeValue + 1;
                        }
                        if (gapPenalty > 3)
                        {
                            gapPenalty = 4;
                            if (gapPenalty >= 4)
                            {
                                gapPenalty = 5;
                            }
                        }
                        _billChenValue -= gapPenalty;

                        // Gap Bonus for straight (Hich Card is Jack or lower and gapPenalty equals 0 or 1)
                        if (HighCard.AbsoluteValue <= 11 && gapPenalty <= 1)
                        {
                            _billChenValue += 1;
                        }

                        // Flush Bonus
                        if (SameSuit)
                        {
                            _billChenValue += 2;
                        }
                    }
                }
                return _billChenValue;
            }
        }

        public Hand()
        {

        }

        public Hand(Card firstCard, Card secondCard)
        {
            this.FirstCard = firstCard;
            this.SecondCard = secondCard;
        }

        public Hand(string firstCard, string secondCard)
        {
            this.FirstCard = new Card(firstCard);
            this.SecondCard = new Card(secondCard);
        }

        public Hand(string shortName)
        {
            string s = "h";
            if (shortName.ToUpper().Length < 3)
            {
                s = "c";
            }
            this.FirstCard = new Card(shortName.Substring(0, 1) + s);
            this.SecondCard = new Card(shortName.Substring(1, 1) + "h");
        }

        /// <summary>
        /// Set the score for the high card of the hand
        /// </summary>
        /// <returns></returns>
        private int ScoresHighCard()
        {
            int score = 0;
            // As is worth 10
            if (HighCard.AbsoluteValue == 14)
            {
                score = 10;
            }
            else {
                // King, Queen and Jack are respectively worth 8, 7, 6
                score = HighCard.RelativeValue - 5;
                // 10 and lower cards are worth to half their current score (round up)
                if (HighCard.AbsoluteValue < 10)
                {
                    score = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(HighCard.AbsoluteValue / 2)));
                }
            }
            return score;
        }

    }
}
