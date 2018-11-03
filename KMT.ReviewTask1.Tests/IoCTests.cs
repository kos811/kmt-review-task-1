using Autofac;
using Autofac.Builder;
using KMT.ReviewTask1.Application.IoC;
using KMT.ReviewTask1.Application.Service;
using NUnit.Framework;

namespace KMT.ReviewTask1.Tests
{

    [TestFixture]
    public class Tests:IoCTestBase
    {
        [Test]
        public void Resolve_Test()
        {
            // Arrange
            // Act
            var fileReader = Scope.Resolve<IFileReader>();
            var folderProvider = Scope.Resolve<IFolderProvider>();
            var logger =Scope.Resolve<ILogger>();
            var matrixOperationResolver = Scope.Resolve<IMatrixOperationResolver>();
            var matrixProcessor = Scope.Resolve<IMatrixProcessor>();
            var matrixSerializer = Scope.Resolve<IMatrixSerializer>();
            var processingTask = Scope.Resolve<IProcessingTask>();
            //Assert
            Assert.NotNull(fileReader);
            Assert.NotNull(folderProvider);
            Assert.NotNull(logger);
            Assert.NotNull(matrixOperationResolver);
            Assert.NotNull(matrixProcessor);
            Assert.NotNull(matrixSerializer);
            Assert.NotNull(processingTask);
        }
    }

    [TestFixture]
    public abstract class IoCTestBase
    {
        protected ILifetimeScope Scope;

        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IoCModule>();
            Scope = builder.Build();
        }
    }
}
