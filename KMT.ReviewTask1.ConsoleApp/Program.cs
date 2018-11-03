using Autofac;
using KMT.ReviewTask1.Application.IoC;
using KMT.ReviewTask1.Application.Service;

namespace KMT.ReviewTask1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var task = container.Resolve<IProcessingTask>();
            task.Do();

            System.Console.WriteLine("Work finished, press any key to exit...");
            System.Console.ReadKey();
        }

        private static ILifetimeScope BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<IoCModule>();
            return containerBuilder.Build();
        }
    }
}
