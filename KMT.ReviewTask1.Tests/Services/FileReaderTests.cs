using KMT.ReviewTask1.Application.Service.Impl;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using KMT.ReviewTask1.Application.Model;

namespace KMT.ReviewTask1.Tests.Services
{
    [TestFixture]
    public class FileReaderTests
    {
        [Test]
        public void Read1_Test()
        {
            // Arrange
            var expected =new Matrix(new double[,]{{1,2},{3,4}}); 
            var service = new FileReader(new MatrixSerializer());
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                "addition_example1.txt");
            // Act
            var result = service.Read(filename);
            //Assert
            Assert.AreEqual(MatrixOperation.add, result.Operation);
            Assert.AreEqual(2, result.Matrices.Count);
            Assert.AreEqual(expected, result.Matrices.ToArray()[0]);
            Assert.AreEqual(expected, result.Matrices.ToArray()[1]);
        }

        [Test]
        public void Read2_Test()
        {
            // Arrange
            var expected =new Matrix(new double[,]{{1,2},{3,4}}); 
            var service = new FileReader(new MatrixSerializer());
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources",
                "subtraction_example1.txt");
            // Act
            var result = service.Read(filename);
            //Assert
            Assert.AreEqual(MatrixOperation.subtract, result.Operation);
            Assert.AreEqual(2, result.Matrices.Count);
            Assert.AreEqual(expected, result.Matrices.ToArray()[0]);
            Assert.AreEqual(expected, result.Matrices.ToArray()[1]);
        }
    }
}