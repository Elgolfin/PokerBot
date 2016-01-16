using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.PokerGame
{
    public class HandPlay
    {
        [Flags]
        public enum Round
        {
            PreFlop = 0x01,
            Flop = 0x02,
            Trun = 0x04,
            River = 0x08,
            Showdown = 0x10
        }
    }
}
