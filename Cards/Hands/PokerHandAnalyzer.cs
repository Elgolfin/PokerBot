﻿using System.Collections.Generic;
using System.Collections;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class PokerHandAnalyzer
    {
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
            
        }

        //private static void Initialize()
        //{
        //    var mask = new MaskBits(52, 7);
        //    while (!mask.IsParsingComplete)
        //    {
        //        var ph = new PokerHand(mask.ToInt64());
        //        AnalyzePokerHand(ph);
        //        AllHands.Add(mask.ToUint64(), ph);
        //        mask.Decrement();
        //    }

        //}

        public void AddPokerHand(PokerHand ph)
        {
            if (!AllHands.ContainsKey(ph.ToLong()))
            {
                AnalyzePokerHand(ph);
                AllHands.Add(ph.ToLong(), ph);
            }
        }
        public void AddPokerHand(long hand)
        {
            if (!AllHands.ContainsKey(hand))
            {
                var ph = new PokerHand(hand);
                AnalyzePokerHand(ph);
                AllHands.Add(ph.ToLong(), ph);
            }
        }

        public PokerHand GetPokerHand(long hand)
        {
            if (!AllHands.ContainsKey(hand))
            {
                AddPokerHand(hand);
            }
            return AllHands[hand] as PokerHand;
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

        public int Count()
        {
            return AllHands.Count;
        }
    }
}
