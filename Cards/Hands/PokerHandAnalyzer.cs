using System;
using System.Collections.Generic;
using System.Collections;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class PokerHandAnalyzer
    {
        public Strength HandStrength;
        private static readonly List<PokerHandType> PokerHandsTypes = new List<PokerHandType>()
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new ThreeOfAKind(),
            new TwoPairs(),
            new OnePair(),
            new HighCard()
        };
        private static readonly Hashtable AllHands = new Hashtable();

        public enum Strength
        {
            StraightFlush = 1,
            FourOfAKind = 2,
            FullHouse = 3,
            Flush = 4,
            Straight = 5,
            ThreeOfAKind = 6,
            TwoPairs = 7,
            OnePair = 8,
            HighCard = 9
        }
        public PokerHandAnalyzer()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var mask = new MaskBits(52, 7);
            while (!mask.IsParsingComplete)
            {
                var ph = new PokerHand(mask.ToInt64());
                AnalyzePokerHand(ph);
                AllHands.Add(mask.ToUint64(), ph);
                mask.Decrement();
            }

        }

        // TODO Set Kickers in each PokerHandType class
        private static void AnalyzePokerHand(PokerHand ph)
        {
            foreach (var pht in PokerHandsTypes)
            {
                if (pht.Parse(ph))
                {
                    break;
                }
            }
        }
    }
}
