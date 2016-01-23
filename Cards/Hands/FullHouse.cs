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
                // TODO Set the Kickers
                // 2 Kickers: Card of Three of a kind, Card of Pair
            }
            return result;

        }

    }
}
