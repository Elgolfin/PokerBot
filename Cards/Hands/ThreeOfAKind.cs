namespace Nicomputer.PokerBot.Cards.Hands
{
    public class ThreeOfAKind : PokerHandType
    {

        public ThreeOfAKind()
        {
            Strength = PokerHandAnalyzer.Strength.ThreeOfAKind;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsThreeOfAKind(pokerHand.ToLong()))
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
