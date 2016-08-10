using Xunit;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    
    public class MaskBitsUnitTests
    {
        [Fact]
        [Trait("Category", "MaskBits")]
        // Bit 8 and 7 to one, if decrements bit 8 and 6 to one, bit 7 to 0
        public void Decrement_8_7_Is_8_6()
        {
            ulong[] result = { 0x20, 0x80 };
            MaskBits mask = new MaskBits(8, 2);
            mask.Decrement();
            Assert.Equal(true, mask.Equals(result));
        }

        [Fact]
        [Trait("Category", "MaskBits")]
        public void Decrement_8_1_Is_7_6()
        {
            ulong[] result = { 0x20, 0x40 };
            MaskBits mask = new MaskBits(8, 2);
            Decrement(mask, 7);
            Assert.Equal(true, mask.Equals(result));
        }

        [Fact]
        [Trait("Category", "MaskBits")]
        public void Decrement_7_6_Is_7_5()
        {
            ulong[] result = { 0x10, 0x40 };
            MaskBits mask = new MaskBits(8, 2);
            Decrement(mask, 7);
            mask.Decrement();
            Assert.Equal(true, mask.Equals(result));
        }

        [Fact]
        [Trait("Category", "MaskBits")]
        public void Decrement_2_1_Is_2_1()
        {
            ulong[] result = { 0x1, 0x2 };
            MaskBits mask = new MaskBits(8, 2);
            Decrement(mask, 7);
            Decrement(mask, 6);
            Decrement(mask, 5);
            Decrement(mask, 4);
            Decrement(mask, 3);
            Decrement(mask, 2);
            mask.Decrement();
            Assert.Equal(true, mask.Equals(result));
            Assert.Equal(true, mask.IsParsingComplete);
        }

        private void Decrement(MaskBits mask, int j)
        {
            for (int i = 0; i < j; i++)
            {
                mask.Decrement();
            }
        }
    }
}
