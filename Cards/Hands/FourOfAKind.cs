namespace Nicomputer.PokerBot.Cards.Hands
{
    public class FourOfAKind : PokerHandType
    {

        public FourOfAKind()
        {
            Strength = PokerHandAnalyzer.Strength.FourOfAKind;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsFourOfAKind(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[1]));
            }
            return result;

        }
    }
}
