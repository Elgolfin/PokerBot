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
            CardsAnalyzer.SetHighCardsKickers(pokerHand.ToLong());
            pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
            pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[1]));
            pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[2]));
            pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[3]));
            pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[4]));
            return true;
        }

    }
}
