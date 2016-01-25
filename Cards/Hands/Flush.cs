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
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[0]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[1]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[2]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[3]));
                pokerHand.Kickers.Add(new Card(CardsAnalyzer.Kickers[4]));
            }
            return result;

        }
    }
}
