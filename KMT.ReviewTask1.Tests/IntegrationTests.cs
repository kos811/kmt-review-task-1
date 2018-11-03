using System;
using System.IO;
using System.Linq;
using Autofac;
using KMT.ReviewTask1.Application.Model;
using KMT.ReviewTask1.Application.Service;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests
{
    [TestFixture]
    public class IntegrationTests:IoCTestBase
    {

        [Test]
        public void Integration_Test()
        {
            // Arrange
            var matrixSerializer = Scope.Resolve<IMatrixSerializer>();
            var processingTask = Scope.Resolve<IProcessingTask>();
            // Act
            processingTask.Do();
            //Assert
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Example1_result.txt");
            var text = File.ReadAllText(filePath);
            var resultMatrix = matrixSerializer.Deserialize(text);

            Assert.AreEqual(new Matrix(new double[,]
            {
                {2, 3},
                {2, 3},
                {1,2 }
            }), resultMatrix);
        }

        [Test]
        public void Integration2_Test()
        {
            // Arrange
            var matrixSerializer = Scope.Resolve<IMatrixSerializer>();
            var processingTask = Scope.Resolve<IProcessingTask>();
            // Act
            processingTask.Do();
            //Assert
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Example2_result.txt");
            var text = File.ReadAllText(filePath);
            var resultMatrix = matrixSerializer.Deserialize(text);

            Assert.AreEqual(new Matrix(new double[,]
            {
                {5, 10, 5},
                {5, 10, 5},
                {3, 6, 3}
            }), resultMatrix);
        }

        //[Test]
        //public void Integration3_Test()
        //{
        //    // Arrange
        //    var fileReader = Scope.Resolve<IFileReader>();
        //    var processingTask = Scope.Resolve<IProcessingTask>();
        //    // Act
        //    processingTask.Do();
        //    //Assert
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Example3_result.txt");
        //    var resultMatrix = fileReader.Read(filePath).Matrices;

        //    Assert.AreEqual(new Matrix(new double[,]
        //    {
        //        {1, 5, 9, 13},
        //        {2, 6, 10, 14},
        //        {3, 7, 11, 15},
        //        {4, 8, 12, 16}
        //    }), resultMatrix.First());

        //    Assert.AreEqual(new Matrix(new double[,]
        //    {
        //        {1, 4, 7},
        //        {2, 5, 8},
        //        {3, 6, 9}
        //    }), resultMatrix.Skip(1).First());

        //    Assert.AreEqual(new Matrix(new double[,]
        //    {
        //        {4,5, 6},
        //        {4,5, 6},
        //        {4,5, 6}
        //    }), resultMatrix.Skip(2).First());
        //}

    }
}