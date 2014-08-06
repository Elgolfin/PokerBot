using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Suits
{
    /// <summary>
    /// 00000000 00000000 00000000 00000000 00000000 00000000 00011111 11111111 (0x0000000000001FFF) clubs mask
    /// </summary>
    /// <remarks>
    /// 00000000 00000000 00000000 00000000 00000011 11111111 11100000 00000000 (0x0000000003FFE000) diamonds mask 
    /// 00000000 00000000 00000000 01111111 11111100 00000000 00000000 00000000 (0x0000007FFC000000) spades mask
    /// 00000000 00001111 11111111 10000000 00000000 00000000 00000000 00000000 (0x000FFF8000000000) hearts mask
    /// 00000000 00001111 11111111 11111111 11111111 11111111 11111111 11111111 (0x000FFFFFFFFFFFFF) 52 cards mask 
    /// </remarks>
    public class Spade : AbstractSuit
    {
        public Spade(long cards)
            : base(13, 0x0000007FFC000000, 26)
        {
            Cards = cards;
        }
    }
}
