using Nicomputer.PokerBot.Cards.Suits;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot.Cards
{
    public static class CardsAnalyzer
    {
        private static Club _clubs;
        private static Diamond _diamonds;
        private static Spade _spades;
        private static Heart _hearts;

        public static Dictionary<long, int> CardsCount = new Dictionary<long, int>();
        public static long[] Kickers = new long[5];

        public static bool IsFourOfAKind(long hand)
        {
            return IsNofAKind(hand, 4);
        }

        public static bool IsThreeOfAKind(long hand)
        {
            return IsNofAKind(hand, 3);
        }

        public static bool IsAPair(long hand)
        {
            return IsNofAKind(hand, 2);
        }

        public static bool IsStraight(long hand)
        {
            CreateSuitsFromHand(hand);
            var combinedHand = _clubs.ToLong() | _diamonds.ToLong() | _spades.ToLong() | _hearts.ToLong();
            return IsStraightFoundation(combinedHand);
        }

        public static bool IsStraightFlush(long hand)
        {
            CreateSuitsFromHand(hand);

            return IsStraightFoundation(_clubs.ToLong())
                   || IsStraightFoundation(_diamonds.ToLong())
                   || IsStraightFoundation(_spades.ToLong())
                   || IsStraightFoundation(_hearts.ToLong());
        }

        private static bool IsStraightFoundation(long hand)
        {
            CardsCount = new Dictionary<long, int>();
            var isStraight = false;
            long straightMask = 0x1F00; // 1 1111 0000 0000
            const long exceptionStraightMask = 0x100F; // 1 0000 0000 1111

            Kickers = new long[1];
            var clubs = new Club(hand);

            for (var i = 0; i < (clubs.MaxSuitCards - 4); i++)
            {
                var total = hand & straightMask;
                if (straightMask == total)
                {
                    isStraight = true;
                    Kickers[0] = BinaryOperations.GetTheMostRightSetBit(straightMask);    // Set the highest card of the straight as the kicker
                    break;
                }
                straightMask >>= 1;
            }

            // Special Straight (ace is the bit of the highest weight and could match a straight with the four lowest bits
            if (!isStraight && exceptionStraightMask == (hand & exceptionStraightMask))
            {
                isStraight = true;
                Kickers[0] = 0x1;
            }

            return isStraight;
        }

        public static bool IsFlush(long hand)
        {
            const int numberOfCardsToMakeAFlush = 5;
            CardsCount = new Dictionary<long, int>();
            Kickers = new long[numberOfCardsToMakeAFlush];
            var isFlush = false;

            CreateSuitsFromHand(hand);

            isFlush = SetFlushKickers(_clubs);
            if (!isFlush)
            {
                isFlush = SetFlushKickers(_diamonds);
            }
            if (!isFlush)
            {
                isFlush = SetFlushKickers(_spades);
            }
            if (!isFlush)
            {
                isFlush = SetFlushKickers(_hearts);
            }

            return isFlush;
        }

        private static bool SetFlushKickers(AbstractSuit suit)
        {
            var isFlush = false;
            const int numberOfCardsToMakeAFlush = 5;
            Kickers = new long[numberOfCardsToMakeAFlush];

            var numberOfSuitedCards = CountSetBits(suit.ToLong());
            if (numberOfSuitedCards >= numberOfCardsToMakeAFlush)
            {
                CountCards(suit.ToLong());
                var cpt = 0;
                foreach (var entry in CardsCount)
                {
                    if (entry.Value > 0 && cpt < numberOfCardsToMakeAFlush)
                    {
                        Kickers[cpt] = entry.Key;
                        Kickers[cpt] <<= suit.Shift;
                        cpt++;
                    }
                }
                isFlush = true;
            }
            return isFlush;
        }
        public static void SetHighCardsKickers(long hand)
        {
            Kickers = new long[5];
            CardsCount = new Dictionary<long, int>();
            CountCards(hand);
            var cpt = 0;
            foreach (var entry in CardsCount)
            {
                if (entry.Value > 0 && cpt < 5)
                {
                    Kickers[cpt++] = entry.Key;
                }
            }
        }

        public static int CountSetBits(long hand)
        {
            var tmpHand = hand;
            var cpt = 0;
            while (tmpHand > 0)
            {
                if ((tmpHand & 0x1) == 1)
                {
                    cpt++;
                }
                tmpHand >>= 1;
            }
            return cpt;
        }

        private static void CreateSuitsFromHand(long hand)
        {
            _clubs = new Club(hand);
            _diamonds = new Diamond(hand);
            _spades = new Spade(hand);
            _hearts = new Heart(hand);
        }

        private static bool IsNofAKind(long hand, short numCards)
        {
            CardsCount = new Dictionary<long, int>();
            CountCards(hand);
            var result = from count in CardsCount where count.Value == numCards select count.Key;
            if (!result.Any())
            {
                return false;
            }
            var remainingKickers = 5 - numCards;
            Kickers = new long[1 + remainingKickers];
            Kickers[0] = result.First();
            var i = 1;
            foreach (var entry in CardsCount)
            {
                if (entry.Value > 0 && entry.Key != Kickers[0] && remainingKickers > 0)
                {
                    Kickers[i] = entry.Key;
                    i++;
                    remainingKickers--;
                }
            }
            return true;
        }

        public static bool IsFullHouse(long hand)
        {
            return AreTwoSetsNofAKind(hand, 3, 2);
        }

        public static bool IsTwoPairs(long hand)
        {
            return AreTwoSetsNofAKind(hand, 2, 2);
        }

        /// <summary>
        /// numCardsSet1 must be greater or equal to numCardsSet2
        /// Works only for (numCardsSet1 = 2 and numCardsSet2 = 2) = 2 or (numCardsSet1 = 3 and numCardsSet2 = 2)
        /// Kickers are always from the Clubs suit
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="numCardsSet1"></param>
        /// <param name="numCardsSet2"></param>
        /// <returns></returns>
        private static bool AreTwoSetsNofAKind(long hand, int numCardsSet1, int numCardsSet2)
        {
            CardsCount = new Dictionary<long, int>();
            var remainingKickers = 5 - numCardsSet1 - numCardsSet2;
            Kickers = new long[2 + remainingKickers];
            CountCards(hand);
            long set1 = 0;
            long set2 = 0;
            var remainingKickerHasNotBeenSet = true;

            if (numCardsSet1 >= numCardsSet2)
            {
                foreach (var entry in CardsCount)
                {
                    if (set1 == 0 && entry.Value == numCardsSet1)
                    {
                        set1 = entry.Key;
                        Kickers[0] = set1;
                        continue;
                    }
                    if (set2 == 0 && entry.Value == numCardsSet2)
                    {
                        set2 = entry.Key;
                        Kickers[1] = set2;
                        continue;
                    }

                    if (entry.Value > 0 && remainingKickers > 0 && remainingKickerHasNotBeenSet)
                    {
                        Kickers[2] = entry.Key;
                        remainingKickerHasNotBeenSet = false;
                    }

                }
            }

            return set1 > 0 && set2 > 0;
        }

        public static void CountCards(long hand)
        {
            long cardsMask = 0x1000;

            CreateSuitsFromHand(hand);

            var cl = _clubs.ToLong();
            var di = _diamonds.ToLong();
            var sp = _spades.ToLong();
            var he = _hearts.ToLong();

            for (var i = 0; i < _clubs.MaxSuitCards; i++)
            {
                CardsCount[cardsMask] = 0;
                CardsCount[cardsMask] += CountSetBits(cl & cardsMask);
                CardsCount[cardsMask] += CountSetBits(di & cardsMask);
                CardsCount[cardsMask] += CountSetBits(sp & cardsMask);
                CardsCount[cardsMask] += CountSetBits(he & cardsMask);

                cardsMask >>= 1;
            }
        }
    }
}