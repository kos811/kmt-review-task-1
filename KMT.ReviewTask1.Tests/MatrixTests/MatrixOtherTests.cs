using KMT.ReviewTask1.Application.Model;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests.MatrixTests
{
    [TestFixture]
    public class MatrixOtherTests
    {
        [Test]
        public void Dimensions_Test()
        {
            //arrange
            //act
            var x = new Matrix(2, 3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6,
            };
            //assert
            Assert.AreEqual(2, x.RowCount);
            Assert.AreEqual(3, x.ColCount);
        }

        [Test]
        public void Constructor_Test()
        {
            //arrange
            //act
            var x = new Matrix(2, 2)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [1, 0] = 3,
                [1, 1] = 4,
            };
            //assert
            Assert.AreEqual(1, x[0, 0]);
            Assert.AreEqual(2, x[0, 1]);
            Assert.AreEqual(3, x[1, 0]);
            Assert.AreEqual(4, x[1, 1]);
        }
    }
}