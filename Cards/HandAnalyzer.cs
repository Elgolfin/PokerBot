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
            bool isNOfAKind = false;
            long lowerBitMask = 0x1;

            CreateSuitsFromHand(hand);

            long cl = clubs.ToLong();
            long di = diamonds.ToLong();
            long sp = spades.ToLong();
            long he = hearts.ToLong();

            for (int i = 0; i < clubs.MaxSuitCards; i++)
            {
                long total = (cl & lowerBitMask) + (di & lowerBitMask) + (sp & lowerBitMask) + (he & lowerBitMask);
                if (nCards == total)
                {
                    isNOfAKind = true;
                    break;
                }
                cl >>= 1;
                di >>= 1;
                sp >>= 1;
                he >>= 1;
            }

            return isNOfAKind;
        }
    }
}
