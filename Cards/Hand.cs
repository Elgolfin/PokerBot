using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicomputer.PokerBot.Cards
{
    // TODO add unit tests for Hand
    public class Hand
    {
        public Card FirstCard { get; set; }
        public Card SecondCard { get; set; }

        private int _billChenValue = 0;
        private int _billChenGroupValue = 0;

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
            if (FirstCard.CompareTo(SecondCard) >= 0)
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
                return (FirstCard.RelativeValue == SecondCard.RelativeValue);
            }
        }

        /// <summary>
        /// Calculate the Bill Chen value of the hand (hand value are classified in 5 tiers)
        /// Group 	Hands
        /// 1 	    AA, AKs, KK, QQ, JJ
        /// 2 	    AK, AQs, AJs, KQs, TT
        /// 3 	    AQ, ATs, KJs, QJs, JTs, 99
        /// 4 	    AJ, KQ, KTs, QTs, J9s, T9s, 98s, 88
        /// 5 	    A9s - A2s, KJ, QJ, JT, Q9s, T8s, 97s, 87s, 77, 76s, 66
        /// 6 	    AT, KT, QT, J8s, 86s, 75s, 65s, 55, 54s
        /// 7 	    K9s - K2s, J9, T9, 98, 64s, 53s, 44, 43s, 33, 22
        /// 8 	    A9, K9, Q9, J8, J7s, T8, 96s, 87, 85s, 76, 74s, 65, 54, 42s, 32s
        /// 9 	    All other hands not required above.
        /// </summary>
        /// <returns></returns>
        public int BillChenGroupValue
        {
            get
            {
                if (_billChenGroupValue == 0)
                {
                    _billChenGroupValue = 9;
                    if (BillChenValue == 5)
                    {
                        _billChenGroupValue = 7;
                    }

                    if (BillChenValue >= 6)
                    {
                        _billChenGroupValue = 5;
                    }

                    if (BillChenValue == 8)
                    {
                        _billChenGroupValue = 4;
                    }

                    if (BillChenValue == 9)
                    {
                        _billChenGroupValue = 3;
                    }

                    if (BillChenValue >= 10)
                    {
                        _billChenGroupValue = 2;
                    }

                    if (BillChenValue >= 12)
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

        /// <summary>
        /// 
        /// 1. Score your highest card only.Do not add any points for your lower card.
        ///     A = 10 points.
        ///     K = 8 points.
        ///     Q = 7 points.
        ///     J = 6 points.
        ///     10 to 2 = 1/2 of card value. (e.g.a 6 would be worth 3 points)
        /// 
        /// 2. Multiply pairs by 2 of one card’s value.However, minimum score for a pair is 5.
        /// (e.g.KK = 16 points, 77 = 7 points, 22 = 5 points)
        /// 
        /// 3. Add 2 points if cards are suited.
        /// 
        /// 4. Subtract points if their is a gap between the two cards.
        ///     No gap = -0 points.
        ///     1 card gap = -1 points.
        ///     2 card gap = -2 points.
        ///     3 card gap = -4 points.
        ///     4 card gap or more = -5 points. (Aces are high this step, so hands like A2, A3 etc. have a 4+ gap.)
        /// 
        /// 5. Add 1 point if there is a 0 or 1 card gap and both cards are lower than a Q. (e.g.JT, 75, 32 etc, this bonus point does not apply to pocket pairs)
        /// 
        /// 6. Round half point scores up. (e.g. 7.5 rounds up to 8)
        ///
        /// </summary>
        public int BillChenValue
        {
            get
            {
                double billChenValue = 0;
                if (_billChenValue == 0)
                {

                    // 1. Score Highest Card
                    billChenValue = ScoresHighCard();
                    
                    // 2. Pair
                    if (Pair)
                    {
                        billChenValue *= 2;
                        if (billChenValue < 5)
                        {
                            billChenValue = 5;
                        }
                    }
                    else
                    {

                        // 3. Suited Bonus
                        if (SameSuit)
                        {
                            billChenValue += 2;
                        }

                        // 4. Calculate the gap penalty
                        var gapPenalty = HighCard.RelativeValue - LowCard.RelativeValue - 1;
                        if (gapPenalty >= 4)
                        {
                            gapPenalty = 5;
                        }
                        if (gapPenalty == 3)
                        {
                            gapPenalty = 4;
                        }
                        billChenValue -= gapPenalty;

                        // 5. Straight Bonus (under Queen, not a pair)
                        if (HighCard.RelativeValue <= 11 &&
                            gapPenalty <= 1)
                        {
                            billChenValue += 1;
                        }
                    }

                    // 6. Round up
                    _billChenValue = (int) Math.Ceiling(billChenValue);
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
        private double ScoresHighCard()
        {
            double score = 0;
            // As is worth 10
            if (HighCard.RelativeValue == 14)
            {
                score = 10;
            }
            else {
                // King, Queen and Jack are respectively worth 8, 7, 6
                score = HighCard.RelativeValue - 5;
                // 10 and lower cards are worth to half their current score (round up)
                if (HighCard.RelativeValue < 10)
                {
                    score = (double)HighCard.RelativeValue / 2;
                }
            }
            return score;
        }

    }
}
