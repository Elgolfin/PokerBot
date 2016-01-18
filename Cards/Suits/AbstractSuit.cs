using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Suits
{
    public abstract class AbstractSuit : ISuit
    {
        public long Cards { get; set; }

        public short MaxSuitCards { get; protected set; }
        
        public long Mask { get; protected set; }

        public short Shift { get; protected set; }

        protected AbstractSuit(short totalCards, long mask, short shift)
        {
            Mask = mask;
            Shift = shift;
            MaxSuitCards = totalCards;
        }

        public string LongToBinaryString(long u)
        {
            return Convert.ToString(u, 2).PadLeft(MaxSuitCards, '0'); 
        }

        public static string LongToBinaryString(long u, short maxSuitCards)
        {
            return Convert.ToString(u, 2).PadLeft(maxSuitCards, '0');
        }

        public string ToBinaryString()
        {
            return LongToBinaryString(ToLong());
        }

        public long ToLong()
        {
            long result = Cards & Mask;
            result = result >> Shift;
            return result;
        }

    }
}
