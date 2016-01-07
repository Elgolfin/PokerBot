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

        // TODO: now make it works for more than 1 combination :)
        //[TestCategory("BinaryOperations")]
        //[TestMethod]
        //public void GenerateAllCombinations_8bits_2combination()
        //{
        //    Assert.AreEqual(BinaryOperations.GetNumberOfCombinations(8, 2), BinaryOperations.GenerateAllCombinations(8, 2));
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
            ulong result = 28;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 2));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_1()
        {
            ulong result = 8;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 1));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_0()
        {
            ulong result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 0));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_8_8()
        {
            ulong result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(8, 8));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_52_7()
        {
            ulong result = 133784560;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(52, 7));
        }

        [TestCategory("Combinations")]
        [TestMethod]
        public void GetNumberOfCombinations_0_0()
        {
            ulong result = 1;
            Assert.AreEqual(result, BinaryOperations.GetNumberOfCombinations(0, 0));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_8_1()
        {
            ulong[] result = { 0x80 };
            MaskBits mask = new MaskBits(8, 1);
            Assert.AreEqual(true, mask.Equals(result));
        }

        [TestCategory("BinaryOperations")]
        [TestMethod]
        public void GetCombinationsMaskBits_8_2()
        {
            ulong[] result = { 0x40, 0x80 };
            MaskBits mask = new MaskBits(8, 2);
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

        static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }
    }
}
