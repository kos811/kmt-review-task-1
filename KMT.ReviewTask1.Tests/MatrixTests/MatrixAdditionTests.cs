using System;
using KMT.ReviewTask1.Application.Model;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests.MatrixTests
{
    [TestFixture]
    public class MatrixAdditionTests
    {

        [Test]
        public void Addition_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2},
                {3, 4}
            });
            //act
            var c = a + a;
            //assert
            Console.WriteLine(a);
            Console.WriteLine("*");
            Console.WriteLine(a);
            Console.WriteLine("=");
            Console.WriteLine(c);

            Assert.AreEqual(2, c[0, 0]);
            Assert.AreEqual(4, c[0, 1]);
            Assert.AreEqual(6, c[1, 0]);
            Assert.AreEqual(8, c[1, 1]);
        }

        [Test]
        public void Subtraction_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2},
                {3, 4}
            });
            //act
            var c = a - a;
            //assert
            Console.WriteLine(a);
            Console.WriteLine("-");
            Console.WriteLine(a);
            Console.WriteLine("=");
            Console.WriteLine(c);

            Assert.AreEqual(0, c[0, 0]);
            Assert.AreEqual(0, c[0, 1]);
            Assert.AreEqual(0, c[1, 0]);
            Assert.AreEqual(0, c[1, 1]);
        }


        [Test]
        public void Addition_RowCount_Equality_Exception_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2},
                {3, 4}
            });

            var b = new Matrix(new double[,]
            {
                {1, 2},
                {1, 2},
                {3, 0}
            });
            //act
            Exception catched = null;
            try
            {
                var c = a + b;
            }
            catch (Exception ex)
            {
                catched = ex;
            }

            //assert
            Assert.NotNull(catched);
            Assert.IsInstanceOf<ArgumentException>(catched);
            Assert.AreEqual("Количество строк в матрицах не совпадает", catched.Message);
        }

        [Test]
        public void Addition_ColCount_Equality_Exception_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2},
                {3, 4}
            });

            var b = new Matrix(new double[,]
            {
                {1, 2, 3},
                {1, 2, 3},
            });
            //act
            Exception catched = null;
            try
            {
                var c = a + b;
            }
            catch (Exception ex)
            {
                catched = ex;
            }

            //assert
            Assert.NotNull(catched);
            Assert.IsInstanceOf<ArgumentException>(catched);
            Assert.AreEqual("Количество столбцов в матрицах не совпадает", catched.Message);
        }
    }
}