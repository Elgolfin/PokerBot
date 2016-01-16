using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.Cards.Helper;
using System.Collections.Generic;
using System.Collections;

namespace Nicomputer.PokerBot.CardsUnitTests
{
    [TestClass]
    public class BinaryOperationsUnitTests
    {
        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GenerateAllCombinations_8bits_1combination()
        {
            Assert.AreEqual(8, BinaryOperations.GenerateAllCombinations(8, 1));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GenerateAllCombinations_8bits_2combinations()
        {
            Assert.AreEqual(BinaryOperations.GetNumberOfCombinations(8, 2), BinaryOperations.GenerateAllCombinations(8, 2));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GenerateAllCombinations_8bits_3combinations()
        {
            Assert.AreEqual(BinaryOperations.GetNumberOfCombinations(8, 3), BinaryOperations.GenerateAllCombinations(8, 3));
        }

        //[TestCategory("BinaryOperations")]
        //[TestMethod]
        //public void GenerateAllCombinations_52bits_7combinations()
        //{
        //    Assert.AreEqual(BinaryOperations.GetNumberOfCombinations(52, 7), BinaryOperations.GenerateAllCombinations(52, 7));
        //}

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_8_1()
        {
            ulong result = 0x80;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(8, 1));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_8_0()
        {
            ulong result = 0x80;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(8, 0));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_8_2()
        {
            ulong result = 0xC0;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(8, 2));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_8_8()
        {
            ulong result = 0xFF;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(8, 8));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_52_1()
        {
            /// 00000000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0x8000000000000;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(52, 1));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToLeft_52_7()
        {
            /// 00000000 0000//1111 1110.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0xFE00000000000;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToLeft(52, 7));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_8_1()
        {
            ulong result = 0x80;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(8, 1));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_1_8()
        {
            ulong result = 0xFF;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(1, 8));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_8_2()
        {
            ulong result = 0x180;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(8, 2));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_8_0()
        {
            ulong result = 0x80;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(8, 0));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_53_12()
        {
            /// 1111 1111 1111//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong result = 0xFFF0000000000000;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(53, 12));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void SetBitsFromToRight_1_7()
        {
            /// 0000 0000 0000//0000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0111.1111
            ulong result = 0x000000000000007F;
            Assert.AreEqual(result, BinaryOperations.SetBitsFromToRight(1, 7));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_2()
        {
            int result = 28;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 2));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_1()
        {
            int result = 8;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 1));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_0()
        {
            int result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 0));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_8()
        {
            int result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 8));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_52_7()
        {
            int result = 133784560;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(52, 7));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_0_0()
        {
            int result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(0, 0));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_8_1()
        {
            ulong[] result = { 0x80 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 1);
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_8_2()
        {
            ulong[] result = { 0x40, 0x80 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_8_2_Decrement_1_Reset()
        {
            ulong[] result = { 0x40, 0x80 };
            Cards.Helper.MaskBits mask = new Cards.Helper.MaskBits(8, 2);
            mask.Decrement();
            mask.Reset();
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_52_7()
        {
            /// 0000 0000 0000//1000 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0100 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0010 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0001 0000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0000 1000.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0000 0100.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            /// 0000 0000 0000//0000 0010.0000 0/000.0000 0000.00/00 0000.0000 000/0.0000 0000.0000
            ulong[] result = { 0x200000000000,
                               0x400000000000,
                               0x800000000000,
                               0x1000000000000,
                               0x2000000000000,
                               0x4000000000000,
                               0x8000000000000 };
            MaskBits mask = new MaskBits(52, 7);
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void ReverseBits_0x8000000000000000_Is_0x1()
        {
            ulong input = 0x8000000000000000;
            ulong result = 0x01;
            Assert.AreEqual(result, BinaryOperations.ReverseBits(input));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void MaskBits_8_2_ToString_Is_11000000()
        {
            var mask = new MaskBits(8, 2);
            Assert.AreEqual("11000000", mask.ToString());

        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void CompareArrays_SameReferences_True()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = mask1.Mask;
            Assert.AreEqual(true, mask1.Equals(mask2));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void CompareArrays_Null_False()
        {
            var mask1 = new MaskBits(8, 2);
            MaskBits mask2 = null;
            Assert.AreEqual(false, mask1.Equals(mask2));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void CompareArrays_DifferentLength_False()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = new MaskBits(8, 3);
            Assert.AreEqual(false, mask1.Equals(mask2.Mask));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void CompareArrays_DifferentMask_False()
        {
            var mask1 = new MaskBits(8, 2);
            var mask2 = new MaskBits(9, 2);
            Assert.AreEqual(false, mask1.Equals(mask2.Mask));
        }
    }
}
