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
            Assert.AreEqual(2, c[0, 0]);
            Assert.AreEqual(2, c[1, 0]);
            Assert.AreEqual(3, c[0, 1]);
            Assert.AreEqual(3, c[1, 1]);
        }

        [Test]
        public void Multiplication_Exception_Test()
        {
            //arrange
            var a = new Matrix(new double[,]
            {
                {1, 2, 1},
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
            Exception catched = null;
            try
            {
                var c = a * b;
            }
            catch (Exception ex)
            {
                catched = ex;
            }
            //assert
            Assert.NotNull(catched);
            Assert.IsInstanceOf<ArgumentException>(catched);
            Assert.AreEqual("Количество строк в матрице А (3) не соответствует количеству столбцов в матрице Б (2)", catched.Message);
        }


        [Test]
        public void Multiplication2_Test()
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
            Assert.AreEqual(1, c[0, 0]);
            Assert.AreEqual(0, c[1, 0]);
            Assert.AreEqual(1, c[2, 0]);
            Assert.AreEqual(2, c[0, 1]);
            Assert.AreEqual(1, c[1, 1]);
            Assert.AreEqual(3, c[2, 1]);
            Assert.AreEqual(1, c[0, 2]);
            Assert.AreEqual(2, c[1, 2]);
            Assert.AreEqual(3, c[2, 2]);
        }
    }
}