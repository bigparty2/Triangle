using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Triangle.Triangle
{
    [TestClass]
    public class TriangleTypeStaticTest
    {
        [TestMethod]
        public void TestInvalidArgumentInConstructorWithArray1()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                    var test = new TriangleType(new int[] { 0, 1 });
            });  
        }

        [TestMethod]
        public void TestInvalidArgumentInConstructorWithArray2()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                var test = new TriangleType(new int[] { 0, 1, 2, 3 });
            });
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 0, 4, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecondValueZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 0, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 4, 0 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueNonZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 1, 0, 0 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecondValueNonZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 0, 1, 0 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueNonZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 0, 0, 1 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleAllValueZero()
        {
            Assert.IsFalse(new TriangleType(new int[] { 0, 0, 0 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { -3, 4, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecondValueNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, -4, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 4, -5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueNonNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, -4, -5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecondValueNonNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { -3, 4, -5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueNonNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { -3, -4, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleAllValueNegative()
        {
            Assert.IsFalse(new TriangleType(new int[] { -3, -4, -5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { int.MinValue, 4, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecoundValueNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, int.MinValue, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 4, int.MinValue }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleFirstValueNonNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, int.MinValue, int.MinValue }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleSecoundValueNonNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { int.MinValue, 4, int.MinValue }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleThirdValueNonNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { int.MinValue, int.MinValue, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestInvalidTriangleAllValueNegativeLimit()
        {
            Assert.IsFalse(new TriangleType(new int[] { int.MinValue, int.MinValue, int.MinValue }).IsTriangle());
        }

        [TestMethod]
        public void TestScalenoRightTriangle()
        {
            var test = new TriangleType(3, 4, 5);

            Assert.IsTrue(test.IsScalenoTriangle());

            Assert.IsTrue(test.IsRightTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.RIGHT_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestScalenoObtuseTriangle()
        {
            var test = new TriangleType(2, 3, 4);

            Assert.IsTrue(test.IsScalenoTriangle());

            Assert.IsTrue(test.IsObtuseTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.OBTUSE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestScalenoAcuteTriangle()
        {
            var test = new TriangleType(5, 6, 7);

            Assert.IsTrue(test.IsScalenoTriangle());

            Assert.IsTrue(test.IsAcuteTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.SCALENE_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestIsocelesAcuteTriangle()
        {
            var test = new TriangleType(5, 5, 6);

            Assert.IsTrue(test.IsIsocelesTriangle());

            Assert.IsTrue(test.IsAcuteTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestIsocelesObtuseTriangle()
        {
            var test = new TriangleType(5, 5, 8);

            Assert.IsTrue(test.IsIsocelesTriangle());

            Assert.IsTrue(test.IsObtuseTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.OBTUSE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestIsocelesTriangleFirst()
        {
            var test = new TriangleType(8, 5, 5);

            Assert.IsTrue(test.IsIsocelesTriangle());
        }

        [TestMethod]
        public void TestIsocelesTriangleSecond()
        {
            var test = new TriangleType(5, 8, 5);

            Assert.IsTrue(test.IsIsocelesTriangle());
        }

        [TestMethod]
        public void TestIsocelesTriangleThird()
        {
            var test = new TriangleType(5, 5, 8);

            Assert.IsTrue(test.IsIsocelesTriangle());
        }

        [TestMethod]
        public void TestEquilateralTriangle()
        {
            var test = new TriangleType(5, 5, 5);

            Assert.IsTrue(test.IsIsocelesTriangle());

            Assert.IsTrue(test.IsEquilateralTriangle());

            Assert.IsTrue(test.IsAcuteTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.EQUILATERAL_TRIANGLE, TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestEquilateralTriangleAllValueLimit()
        {
            var test = new TriangleType(new int[] { int.MaxValue, int.MaxValue, int.MaxValue });

            Assert.IsTrue(test.IsIsocelesTriangle());

            Assert.IsTrue(test.IsEquilateralTriangle());

            Assert.IsTrue(test.IsAcuteTriangle());

            var result = test.GetTriangleTypes();

            CollectionAssert.AreEqual(new TriangleTypes[] { TriangleTypes.EQUILATERAL_TRIANGLE, TriangleTypes.ISOSCELES_TRIANGLE, TriangleTypes.ACUTE_TRIANGLE }, result);
        }

        [TestMethod]
        public void TestSumTwoEqualThirdFirst()
        {
            Assert.IsFalse(new TriangleType(new int[] { 10, 5, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestSumTwoEqualThirdSecond()
        {
            Assert.IsFalse(new TriangleType(new int[] { 5, 10, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestSumTwoEqualThirdThird()
        {
            Assert.IsFalse(new TriangleType(new int[] { 5, 5, 10 }).IsTriangle());
        }

        [TestMethod]
        public void TestSumTwoLessThanFirstThird()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 1, 5 }).IsTriangle());
        }

        [TestMethod]
        public void TestSumTwoLessThanSecoundThird()
        {
            Assert.IsFalse(new TriangleType(new int[] { 3, 5, 1 }).IsTriangle());
        }

        [TestMethod]
        public void TestSumTwoLessThanThirdThird()
        {
            Assert.IsFalse(new TriangleType(new int[] { 5, 3, 1 }).IsTriangle());
        }
    }
}
