using Microsoft.Extensions.DependencyInjection;
using SampleLog.NET8.Calculator.Command;
using SampleLog.NET8.Repositories;
using System.Runtime.InteropServices;

namespace SampleLog.NET8
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
#if DEBUG
            AllocConsole();
#endif
            var services = new ServiceCollection();
            ConfigureServices(services);

            ApplicationConfiguration.Initialize();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<CalculatorForm>();
                Application.Run(form);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<CalculatorForm>();
            services.AddTransient<CommandManager>();
            //services.AddTransient<IHistoryRepository, HistoryRepository>();
            services.AddSingleton<IHistoryRepository, InMemoryHistoryRepository>();
        }

    }
}