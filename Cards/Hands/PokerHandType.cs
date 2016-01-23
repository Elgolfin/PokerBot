namespace Nicomputer.PokerBot.Cards.Hands
{
    public abstract class PokerHandType
    {
        public PokerHandAnalyzer.Strength Strength;

        public abstract bool Parse(PokerHand pokerHand);

    }
}
