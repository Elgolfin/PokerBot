namespace Nicomputer.PokerBot.Cards.Hands
{
    public class OnePair : PokerHandType
    {

        public OnePair()
        {
            Strength = PokerHandAnalyzer.Strength.OnePair;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsAPair(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[1]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[2]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[3]));
            }
            return result;

        }

    }
}
