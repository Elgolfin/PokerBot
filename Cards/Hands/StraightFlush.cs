namespace Nicomputer.PokerBot.Cards.Hands
{
    public class StraightFlush : PokerHandType
    {

        public StraightFlush ()
        {
            Strength = PokerHandAnalyzer.Strength.StraightFlush;
        }

        public override bool Parse(PokerHand pokerHand)
        {
            var result = false;
            if (CardsAnalyzer.IsStraightFlush(pokerHand.ToLong()))
            {
                result = true;
                pokerHand.Strength = Strength;
                // TODO Set the Kickers
            }
            return result;
        }

    }
}
