using System;
using KMT.ReviewTask1.Application.Model;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests.MatrixTests
{
    [TestFixture]
    public class MatrixTrasnponationTests
    {
        [Test]
        public void Transponation_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            });
            //act
            var c = a.Transpose();
            //assert
            Assert.AreEqual(3, c.RowCount);
            Assert.AreEqual(3, c.ColCount);
            Assert.AreEqual(1, c[0, 0]);
            Assert.AreEqual(2, c[1, 0]);
            Assert.AreEqual(3, c[2, 0]);
            Assert.AreEqual(4, c[0, 1]);
            Assert.AreEqual(5, c[1, 1]);
            Assert.AreEqual(6, c[2, 1]);
            Assert.AreEqual(7, c[0, 2]);
            Assert.AreEqual(8, c[1, 2]);
            Assert.AreEqual(9, c[2, 2]);


            Console.WriteLine(a);
            Console.WriteLine("T()");
            Console.WriteLine(a);
        }

        [Test]
        public void Transponation_Exception_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 1},
                {0, 1, 2}
            });
            //act
            Exception catched = null;
            try
            {
                var c = a.Transpose();
            }
            catch (Exception ex)
            {
                catched = ex;
            }
            //assert
            Assert.NotNull(catched);
            Assert.IsInstanceOf<ArgumentException>(catched);
            Assert.AreEqual("Матрица должна быть квадратной", catched.Message);
        }
    }
}