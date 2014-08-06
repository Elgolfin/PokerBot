using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Suits
{
    public abstract class AbstractSuit : ISuit
    {
        public long Cards { get; set; }

        private short _maxSuitCards;
        public short MaxSuitCards
        {
            get { return _maxSuitCards; }
            protected set { _maxSuitCards = value; }
        }
        
        private long _mask;
        public long Mask {
            get { return _mask; } 
            protected set { _mask = value; } 
        }

        private short _shift;
        public short Shift
        {
            get { return _shift; }
            protected set { _shift = value; }
        }

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

        static public string LongToBinaryString(long u, short maxSuitCards)
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
