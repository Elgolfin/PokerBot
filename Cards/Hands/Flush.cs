namespace Nicomputer.PokerBot.Cards.Hands
{
    public class Flush : PokerHandType
    {

        public Flush()
        {
            Strength = PokerHandAnalyzer.Strength.Flush;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsFlush(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                // TODO Set the Kickers
            }
            return result;

        }
    }
}
