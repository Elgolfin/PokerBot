namespace Nicomputer.PokerBot.Cards.Hands
{
    public class Straight : PokerHandType
    {

        public Straight()
        {
            Strength = PokerHandAnalyzer.Strength.Straight;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsStraight(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
            }
            return result;

        }

    }
}
