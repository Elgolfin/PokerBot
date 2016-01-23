using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Hands
{
    public class HighCard : PokerHandType
    {

        public HighCard()
        {
            Strength = PokerHandAnalyzer.Strength.HighCard;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            pokerHand.Strength = Strength;
            // TODO Set the Kickers
            // 5 Kickers: High Card to Low Card
            return true;
        }

    }
}
