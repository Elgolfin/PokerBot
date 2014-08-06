using Cards.Suits;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class HandAnalyzer
    {
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

        public static bool IsStraightFlush(long hand)
        {
            bool isStraightFlush = false;
            long lowerBitStraightFlushMask = 0x1F;

            Club clubs = new Club(hand);
            Diamond diamonds = new Diamond(hand);
            Spade spades = new Spade(hand);
            Heart hearts = new Heart(hand);

            long combinedHand = clubs.ToLong() | diamonds.ToLong() | spades.ToLong() | hearts.ToLong();

            for (int i = 0; i < (clubs.MaxSuitCards - 4); i++)
            {
                Debug.WriteLine(AbstractSuit.LongToBinaryString(combinedHand, 13));
                long total = combinedHand & lowerBitStraightFlushMask;
                if (lowerBitStraightFlushMask == total)
                {
                    isStraightFlush = true;
                    break;
                }
                combinedHand >>= 1;
            }

            return isStraightFlush;
        }

        private static bool IsNOfAKind(long hand, short nCards)
        {
            bool isNOfAKind = false;
            long lowerBitMask = 0x1;

            Club clubs = new Club(hand);
            Diamond diamonds = new Diamond(hand);
            Spade spades = new Spade(hand);
            Heart hearts = new Heart(hand);

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
