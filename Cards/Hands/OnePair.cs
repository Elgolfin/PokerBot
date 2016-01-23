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
                // TODO Set the Kickers
                // 3 Kickers: Excluding the pair, 3x High Card to Low Card
            }
            return result;

        }

    }
}
