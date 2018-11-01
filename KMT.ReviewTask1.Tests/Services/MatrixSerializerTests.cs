using KMT.ReviewTask1.Application.Model;
using KMT.ReviewTask1.Application.Service.Impl;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests.Services
{
    [TestFixture]
    public class MatrixSerializerTests
    {
        [Test]
        public void Serialize_Test()
        {
            // Arrange
            var example = new Matrix(new double[,] {{1,2,3},{4,5,6} });
            // Act
            var result = new MatrixSerializer().Serialize(example);
            //Assert
            Assert.AreEqual("1 2 3\r\n4 5 6\r\n", result);
        }
        [Test]
        public void Deserialize_Test()
        {
            // Arrange
            var example = "1 2 3\r\n4 5 6\r\n";
            var expected = new Matrix(new double[,] {{1, 2, 3}, {4, 5, 6}});
            // Act
            var result = new MatrixSerializer().Deserialize(example);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}