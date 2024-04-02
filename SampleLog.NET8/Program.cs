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
            ApplicationConfiguration.Initialize();
            Application.Run(new CalculatorForm());
        }
    }
}