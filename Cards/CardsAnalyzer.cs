using Nicomputer.PokerBot.Cards.Suits;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nicomputer.PokerBot.Cards
{
    public static class CardsAnalyzer
    {
        private static Club _clubs;
        private static Diamond _diamonds;
        private static Spade _spades;
        private static Heart _hearts;

        public static readonly Dictionary<long, int> CardsCount = new Dictionary<long, int>();

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
            var isStraight = false;
            long straightMask = 0x1F00; // 1 1111 0000 0000
            long exceptionStraightMask = 0x100F; // 1 0000 0000 1111

            var clubs = new Club(hand);

            for (var i = 0; i < (clubs.MaxSuitCards - 4); i++)
            {
                var total = hand & straightMask;
                Debug.WriteLine(AbstractSuit.LongToBinaryString(hand, 13));
                Debug.WriteLine(AbstractSuit.LongToBinaryString(straightMask, 13));
                Debug.WriteLine(AbstractSuit.LongToBinaryString(total, 13));
                if (straightMask == total)
                {
                    isStraight = true;
                    break;
                }
                straightMask >>= 1;
            }

            // Special Straight (ace is the bit of the highest weight and could match a straight with the four lowest bits
            Debug.WriteLine(AbstractSuit.LongToBinaryString(hand, 13));
            Debug.WriteLine(AbstractSuit.LongToBinaryString(exceptionStraightMask, 13));
            Debug.WriteLine(AbstractSuit.LongToBinaryString(hand & exceptionStraightMask, 13));
            if (!isStraight && exceptionStraightMask == (hand & exceptionStraightMask))
            {
                isStraight = true;
            }

            return isStraight;
        }

        public static bool IsFlush(long hand)
        {
            const int numberOfCardsToMakeAFlush = 5;

            CreateSuitsFromHand(hand);

            var numberOfClubs = CountSetBits(_clubs.ToLong());
            var numberOfDiamonds = CountSetBits(_diamonds.ToLong());
            var numberOfSpades = CountSetBits(_spades.ToLong());
            var numberOfHearts = CountSetBits(_hearts.ToLong());

            var isFlush = (numberOfClubs >= numberOfCardsToMakeAFlush)
                      || (numberOfDiamonds >= numberOfCardsToMakeAFlush)
                      || (numberOfSpades >= numberOfCardsToMakeAFlush)
                      || (numberOfHearts >= numberOfCardsToMakeAFlush);

            return isFlush;
        }

        public static int CountSetBits(long hand)
        {
            var tmpHand = hand;
            var cpt = 0;
            while (tmpHand > 0)
            {
                Debug.WriteLine(AbstractSuit.LongToBinaryString(tmpHand, 13));
                if ((tmpHand & 0x1) == 1)
                {
                    cpt++;
                }
                Debug.WriteLine(cpt);
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
            CountCards(hand);
            return (from count in CardsCount where count.Value == numCards select count).Any();
        }

        public static bool IsFullHouse(long hand)
        {
            return AreTwoSetsNofAKind(hand, 3, 2);
        }

        public static bool IsTwoPairs(long hand)
        {
            return AreTwoSetsNofAKind(hand, 2, 2);
        }

        private static bool AreTwoSetsNofAKind(long hand, int numCardsSet1, int numCardsSet2)
        {
            CountCards(hand);
            long set1 = 0;
            long set2 = 0;

            foreach (var entry in CardsCount)
            {
                if (set1 == 0 && entry.Value == numCardsSet1)
                {
                    set1 = entry.Key;
                }
                if (set2 == 0 && entry.Value == numCardsSet2)
                {
                    set2 = entry.Key;
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