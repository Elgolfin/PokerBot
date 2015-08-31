using Nicomputer.PokerBot.Cards.Suits;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards
{
    public class HandAnalyzer
    {
        static Club clubs;
        static Diamond diamonds;
        static Spade spades;
        static Heart hearts;

        public static Dictionary<long, int> cardsCount = new Dictionary<long, int>();

        public enum CardName : long
        {
            Card_2 =        0x0001, // 0 0000 0000 0001
            Card_3 =        0x0002, // 0 0000 0000 0010 
            Card_4 =        0x0004, // 0 0000 0000 0100
            Card_5 =        0x0008, // 0 0000 0000 1000
            Card_6 =        0x0010, // 0 0000 0001 0000
            Card_7 =        0x0020, // 0 0000 0010 0000
            Card_8 =        0x0040, // 0 0000 0100 0000
            Card_9 =        0x0080, // 0 0000 1000 0000
            Card_10 =       0x0100, // 0 0001 0000 0000
            Card_Jack =     0x0200, // 0 0010 0000 0000
            Card_Queen =    0x0400, // 0 0100 0000 0000
            Card_King =     0x0800, // 0 1000 0000 0000
            Card_Ace =      0x1000  // 1 0000 0000 0000
        };

        public static bool IsFourOfAKind(long hand)
        {
            return IsNOfAKind(hand, 4);
        }

        public static bool IsThreeOfAKind(long hand)
        {
            return IsNOfAKind(hand, 3);
        }

        public static bool IsAPair(long hand)
        {
            return IsNOfAKind(hand, 2);
        }

        /// <summary>
        /// This method is working. However there is not yet a possiblity to know what the straight is
        /// TODO We should not shift throughout the combinedHand but shift throughout the straightMask instead
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool IsStraight(long hand)
        {
            bool isStraight = false;
            long lowerBitStraightMask = 0x1F;
            long exceptionStraightMask = 0x100F; // 1 0000 0000 1111

            CreateSuitsFromHand(hand);

            long combinedHand = clubs.ToLong() | diamonds.ToLong() | spades.ToLong() | hearts.ToLong();

            // Special Straight (ace is the bit of the highest weight and could match a straight with the four lowest bits
            if (exceptionStraightMask == (combinedHand & exceptionStraightMask))
            {
                isStraight = true;
            }

            for (int i = 0; i < (clubs.MaxSuitCards - 4); i++)
            {
                Debug.WriteLine(AbstractSuit.LongToBinaryString(combinedHand, 13));
                long total = combinedHand & lowerBitStraightMask;
                if (lowerBitStraightMask == total)
                {
                    isStraight = true;
                    break;
                }
                combinedHand >>= 1;
            }

            return isStraight;
        }

        public static bool IsFlush(long hand)
        {
            bool isFlush = false;
            int numberOfCardsToMakeAFlush = 5;

            CreateSuitsFromHand(hand);

            int numberOfClubs = CountSetBits(clubs.ToLong());
            int numberOfDiamonds = CountSetBits(diamonds.ToLong());
            int numberOfSpades = CountSetBits(spades.ToLong());
            int numberOfHearts = CountSetBits(hearts.ToLong());

            isFlush =  (numberOfClubs >= numberOfCardsToMakeAFlush)
                    || (numberOfDiamonds >= numberOfCardsToMakeAFlush)
                    || (numberOfSpades >= numberOfCardsToMakeAFlush)
                    || (numberOfHearts >= numberOfCardsToMakeAFlush);

            return isFlush;
        }

        public static int CountSetBits(long hand)
        {
            int cpt = 0;
            while (hand > 0) {
                Debug.WriteLine(AbstractSuit.LongToBinaryString(hand, 13));
                if ((hand & 0x1) == 1) { cpt++; }
                Debug.WriteLine(cpt);
                hand >>= 1;
            }
            return cpt;
        }

        private static void CreateSuitsFromHand(long hand)
        {
            clubs = new Club(hand);
            diamonds = new Diamond(hand);
            spades = new Spade(hand);
            hearts = new Heart(hand);
        }

        private static bool IsNOfAKind(long hand, short nCards)
        {
            CountCards(hand);

            foreach (KeyValuePair<long, int> entry in cardsCount)
            {
                if(entry.Value == nCards)
                {
                    return true;
                }
            }

            return false;
        }

        //public bool IsFullHouse

        public static void CountCards(long hand)
        {
            long cardsMask = 0x1000;

            CreateSuitsFromHand(hand);

            long cl = clubs.ToLong();
            long di = diamonds.ToLong();
            long sp = spades.ToLong();
            long he = hearts.ToLong();

            for (int i = 0; i < clubs.MaxSuitCards; i++)
            {
                cardsCount[cardsMask] = 0;
                cardsCount[cardsMask] += CountSetBits(cl & cardsMask);
                cardsCount[cardsMask] += CountSetBits(di & cardsMask);
                cardsCount[cardsMask] += CountSetBits(sp & cardsMask);
                cardsCount[cardsMask] += CountSetBits(he & cardsMask);

                cardsMask >>= 1;
            }
        }
    }
}
