using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards.Suits;

namespace Nicomputer.PokerBot.Cards
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
    public class Deck52cards : AbstractSuit
    {
        public Deck52cards(long cards)
            : base(52, 0x000FFFFFFFFFFFFF, 0)
        {
            Cards = cards;
        }
        public enum CardName : ulong
        {
            _2 = 0x0001,        // 0 0000 0000 0001
            _3 = 0x0002,        // 0 0000 0000 0010 
            _4 = 0x0004,        // 0 0000 0000 0100
            _5 = 0x0008,        // 0 0000 0000 1000
            _6 = 0x0010,        // 0 0000 0001 0000
            _7 = 0x0020,        // 0 0000 0010 0000
            _8 = 0x0040,        // 0 0000 0100 0000
            _9 = 0x0080,        // 0 0000 1000 0000
            _10 = 0x0100,       // 0 0001 0000 0000
            _Jack = 0x0200,     // 0 0010 0000 0000
            _Queen = 0x0400,    // 0 0100 0000 0000
            _King = 0x0800,     // 0 1000 0000 0000
            _Ace = 0x1000       // 1 0000 0000 0000
        };
        public enum SuitName : int
        {
            Clubs = 0,   
            Diamonds = 13,
            Spades = 26,
            Hearts = 39
        };

        //TODO Return the 13 cards of a same suit
        public List<Card> GetSuitCards(SuitName suit)
        {
            return new List<Card>();
        }

    }

    
}
