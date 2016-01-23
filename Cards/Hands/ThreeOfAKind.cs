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
                // TODO Set the Kickers
                // 2 Kickers: 2x Highest Card remaining
            }
            return result;

        }

    }
}
