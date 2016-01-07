using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class MaskBitsUnitTests
    {
        [TestMethod]
        [TestCategory("MaskBits")]
        // Bit 8 and 7 to one, if decrements bit 8 and 6 to one, bit 7 to 0
        public void Decrement_8_7_Is_8_6()
        {
            ulong[] result = { 0x20, 0x80 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            mask.Decrement();
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestMethod]
        [TestCategory("MaskBits")]
        public void Decrement_8_1_Is_7_6()
        {
            ulong[] result = { 0x20, 0x40 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            Decrement(mask, 7);
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestMethod]
        [TestCategory("MaskBits")]
        public void Decrement_7_6_Is_7_5()
        {
            ulong[] result = { 0x10, 0x40 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            Decrement(mask, 7);
            mask.Decrement();
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestMethod]
        [TestCategory("MaskBits")]
        public void Decrement_2_1_Is_2_1()
        {
            ulong[] result = { 0x1, 0x2 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            Decrement(mask, 7);
            Decrement(mask, 6);
            Decrement(mask, 5);
            Decrement(mask, 4);
            Decrement(mask, 3);
            Decrement(mask, 2);
            mask.Decrement();
            Assert.AreEqual(true, mask.Equals(result));
            Assert.AreEqual(true, mask.IsParsingComplete);
        }

        private void Decrement(Cards.Helper.MaskBits mask, int j)
        {
            for (int i = 0; i < j; i++)
            {
                mask.Decrement();
            }
        }
    }
}
