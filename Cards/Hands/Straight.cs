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
                // TODO Set the Kickers
                // 1 Kicker: High Card
            }
            return result;

        }

    }
}
