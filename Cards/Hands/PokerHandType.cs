namespace Nicomputer.PokerBot.Cards.Hands
{
    public abstract class PokerHandType
    {
        public PokerHandAnalyzer.Strength Strength;

        protected PokerHandType() {}

        public abstract bool Parse(PokerHand pokerHand);

    }
}
