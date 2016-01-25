namespace Nicomputer.PokerBot.Cards.Hands
{
    public class FullHouse : PokerHandType
    {

        public FullHouse()
        {
            Strength = PokerHandAnalyzer.Strength.FullHouse;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsFullHouse(pokerHand.ToLong()))
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
