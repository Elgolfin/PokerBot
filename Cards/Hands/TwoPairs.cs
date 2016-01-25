namespace Nicomputer.PokerBot.Cards.Hands
{
    public class TwoPairs : PokerHandType
    {

        public TwoPairs()
        {
            Strength = PokerHandAnalyzer.Strength.TwoPairs;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsTwoPairs(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[1]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[2]));
            }
            return result;

        }

    }
}
