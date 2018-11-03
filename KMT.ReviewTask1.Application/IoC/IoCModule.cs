using Autofac;
using KMT.ReviewTask1.Application.Service;
using KMT.ReviewTask1.Application.Service.Impl;

namespace KMT.ReviewTask1.Application.IoC
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FolderProvider>().As<IFolderProvider>();
            builder.RegisterType<MatrixSerializer>().As<IMatrixSerializer>();
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<MatrixOperationResolver>().As<IMatrixOperationResolver>();
            builder.RegisterType<MatrixProcessor>().As<IMatrixProcessor>();
            builder.RegisterType<ProcessingTask>().As<IProcessingTask>();
        }
    }
}