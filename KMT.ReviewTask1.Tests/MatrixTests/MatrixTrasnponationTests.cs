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
            Assert.AreEqual(new Matrix(new double[,]
            {
                {1, 4, 7},
                {2, 5, 8},
                {3, 6, 9}
            }), c);

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