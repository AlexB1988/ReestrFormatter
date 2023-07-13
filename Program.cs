using Autofac;
using ReestrFormatter.DI;

namespace ReestrFormatter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            using var container=builder.Build();
            var form = container.Resolve<MainForm>();
            Application.Run(form);
        }
    }
}