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
                // TODO Set the Kickers
                // 1 Kickers: Excluding the two pairs, High Card remaining
            }
            return result;

        }

    }
}
