using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Hands;

namespace Nicomputer.PokerBot.UnitTests.Hands
{
    [TestClass]
    public class PokerHandComparaisonUnitTests
    {
        [TestMethod]
        public void StraightFlush_Is_Better_Than_FourOfAKind()
        {
            var straightFlushHand = 0x000000000040201F;   // 00000000 0000//0000 0000.0000 0/000.0000 0000.00/00 0100.0000 001/0.0000 0001.1111
            var fourOfAKindHand = 0x0008004002001000;     // 0000 0000 0000/1000 0000.0000 0/100.0000 0000.00/10 0000.0000 000/1.0000 0000.0000

            var pht1 = new StraightFlush();
            var pht2 = new FourOfAKind();

            var ph1 = new PokerHand(straightFlushHand);
            pht1.Parse(ph1);
            var ph2 = new PokerHand(fourOfAKindHand);
            pht2.Parse(ph2);

            Assert.AreEqual(-1, ph1.CompareTo(ph2));
            Assert.AreEqual(1, ph2.CompareTo(ph1));
            ph2 = new PokerHand(straightFlushHand);
            pht1.Parse(ph2);
            Assert.AreEqual(0, ph1.CompareTo(ph2));
        }
    }
}
