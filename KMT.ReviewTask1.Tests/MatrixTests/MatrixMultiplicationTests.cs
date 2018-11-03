using System;
using KMT.ReviewTask1.Application.Model;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests.MatrixTests
{
    [TestFixture]
    public class MatrixMultiplicationTests
    {

        [Test]
        public void Multiplication_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 1},
                {0, 1, 2}
            });
            var b = new Matrix(new double[,]
            {
                {1, 0},
                {0, 1},
                {1, 1}
            });
            //act
            var c = a * b;

            //assert
            Console.WriteLine(a);
            Console.WriteLine("*");
            Console.WriteLine(b);
            Console.WriteLine("=");
            Console.WriteLine(c);

            Assert.AreEqual(2, c.RowCount);
            Assert.AreEqual(2, c.ColCount);
            Assert.AreEqual(new Matrix(new double[,]
            {
                {2, 3},
                {2, 3}
            }), c);
        }

        [Test]
        public void Multiplication_Exception_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {2, 5, 6, 99},
                {8, 55, 6, 9},
                {7, 8, 5, 56}
            });
            var b = new Matrix(new double[,]
            {
                {59, 48, 65},
                {59, 141, 56},
                {5, 5, 6},
            });
            //act
            Exception catched = null;
            try
            {
                var c = a * b;
                Console.WriteLine(c);
            }
            catch (Exception ex)
            {
                catched = ex;
            }

            //assert
            Assert.NotNull(catched);
            Assert.IsInstanceOf<ArgumentException>(catched);
            Assert.AreEqual("Количество столбцов в матрице А (4) не соответствует количеству строк в матрице Б (3)",
                catched.Message);
        }

        [Test]
        public void Multiplication2_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 1},
                {1, 2, 1},
                {0, 1, 1}
            });
            var b = new Matrix(new double[,]
            {
                {1, 0},
                {0, 1},
                {1, 1}
            });
            //act
            var c = a * b;
            //assert
            Console.WriteLine(a);
            Console.WriteLine("*");
            Console.WriteLine(b);
            Console.WriteLine("=");
            Console.WriteLine(c);

            Assert.AreEqual(3, c.RowCount);
            Assert.AreEqual(2, c.ColCount);
            Assert.AreEqual(new Matrix(new double[,]
            {
                {2, 3},
                {2, 3},
                {1, 2}
            }), c);
        }


        [Test]
        public void Multiplication3_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 1},
                {0, 1, 2}
            });
            var b = new Matrix(new double[,]
            {
                {1, 0},
                {0, 1},
                {1, 1}
            });
            //act
            var c = b * a;

            //assert
            Console.WriteLine(a);
            Console.WriteLine("*");
            Console.WriteLine(b);
            Console.WriteLine("=");
            Console.WriteLine(c);

            Assert.AreEqual(3, c.RowCount);
            Assert.AreEqual(3, c.ColCount);
            Assert.AreEqual(new Matrix(new double[,]
            {
                {1, 2, 1},
                {0, 1, 2},
                {1, 3, 3}
            }), c);
        }
    }
}