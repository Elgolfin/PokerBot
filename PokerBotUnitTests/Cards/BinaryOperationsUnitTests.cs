
using Xunit;
using Nicomputer.PokerBot.Cards.Helper;

namespace Nicomputer.PokerBot.UnitTests.Cards
{
    
    public class BinaryOperationsUnitTests
    {
        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GenerateAllCombinations_8bits_1combination()
        {
            Assert.Equal(8, BinaryOperations.GenerateAllCombinations(8, 1));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GenerateAllCombinations_8bits_2combinations()
        {
            Assert.Equal(BinaryOperations.GetNumberOfCombinations(8, 2), BinaryOperations.GenerateAllCombinations(8, 2));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GenerateAllCombinations_8bits_3combinations()
        {
            Assert.Equal(BinaryOperations.GetNumberOfCombinations(8, 3), BinaryOperations.GenerateAllCombinations(8, 3));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact(Skip = "Please Execute Manually")]
        public void GenerateAllCombinations_52bits_7combinations()
        {
            Assert.Equal(BinaryOperations.GetNumberOfCombinations(52, 7), BinaryOperations.GenerateAllCombinations(52, 7));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_8_1()
        {
            ulong result = 0x80;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(8, 1));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_8_0()
        {
            ulong result = 0x80;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(8, 0));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_8_2()
        {
            ulong result = 0xC0;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(8, 2));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_8_8()
        {
            ulong result = 0xFF;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(8, 8));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_52_1()
        {
            // 00000000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0x8000000000000;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(52, 1));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToLeft_52_7()
        {
            // 00000000 0000//1111 1110.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0xFE00000000000;
            Assert.Equal(result, BinaryOperations.SetBitsFromToLeft(52, 7));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_8_1()
        {
            ulong result = 0x80;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(8, 1));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_1_8()
        {
            ulong result = 0xFF;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(1, 8));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_8_2()
        {
            ulong result = 0x180;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(8, 2));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_8_0()
        {
            ulong result = 0x80;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(8, 0));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_53_12()
        {
            // 1111 1111 1111//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0xFFF0000000000000;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(53, 12));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void SetBitsFromToRight_1_7()
        {
            // 0000 0000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0111.1111
            ulong result = 0x000000000000007F;
            Assert.Equal(result, BinaryOperations.SetBitsFromToRight(1, 7));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_8_2()
        {
            int result = 28;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(8, 2));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_8_1()
        {
            int result = 8;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(8, 1));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_8_0()
        {
            int result = 1;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(8, 0));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_8_8()
        {
            int result = 1;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(8, 8));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_52_7()
        {
            int result = 133784560;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(52, 7));
        }

        [Trait("Category", "Combinations")]
        [Fact]
        public void GetNumberOfCombinations_0_0()
        {
            int result = 1;
            Assert.Equal(result, BinaryOperations.GetNumberOfCombinations(0, 0));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GetCombinationsMaskBits_8_1()
        {
            ulong[] result = { 0x80 };
            MaskBits mask = new MaskBits(8, 1);
            Assert.Equal(true, mask.Equals(result));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GetCombinationsMaskBits_8_2()
        {
            ulong[] result = { 0x40, 0x80 };
            MaskBits mask = new MaskBits(8, 2);
            Assert.Equal(true, mask.Equals(result));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GetCombinationsMaskBits_8_2_Decrement_1_Reset()
        {
            ulong[] result = { 0x40, 0x80 };
            MaskBits mask = new MaskBits(8, 2);
            mask.Decrement();
            mask.Reset();
            Assert.Equal(true, mask.Equals(result));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void GetCombinationsMaskBits_52_7()
        {
            // 0000 0000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0100 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0010 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0001 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0000 1000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0000 0100.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            // 0000 0000 0000//0000 0010.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong[] result = { 0x200000000000,
                               0x400000000000,
                               0x800000000000,
                               0x1000000000000,
                               0x2000000000000,
                               0x4000000000000,
                               0x8000000000000 };
            MaskBits mask = new MaskBits(52, 7);
            Assert.Equal(true, mask.Equals(result));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void ReverseBits_0x8000000000000000_Is_0x1()
        {
            ulong input = 0x8000000000000000;
            ulong result = 0x01;
            Assert.Equal(result, BinaryOperations.ReverseBits(input));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void MaskBits_8_2_ToString_Is_11000000()
        {
            var mask = new MaskBits(8, 2);
            Assert.Equal("11000000", mask.ToString());

        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void CompareArrays_SameReferences_True()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = mask1.Mask;
            Assert.Equal(true, mask1.Equals(mask2));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void CompareArrays_Null_False()
        {
            var mask1 = new MaskBits(8, 2);
            Assert.Equal(false, mask1.Equals(null));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void CompareArrays_DifferentLength_False()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = new MaskBits(8, 3);
            Assert.Equal(false, mask1.Equals(mask2.Mask));
        }

        [Trait("Category", "BinaryOperations")]
        [Fact]
        public void CompareArrays_DifferentMask_False()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = new MaskBits(9, 2);
            Assert.Equal(false, mask1.Equals(mask2.Mask));
        }
    }
}
