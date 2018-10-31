using Autofac;
using KMT.ReviewTask1.Application.IoC;

namespace KMT.ReviewTask1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

        }

        private static ILifetimeScope BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<IoCModule>();
            return containerBuilder.Build();
        }
    }
}
