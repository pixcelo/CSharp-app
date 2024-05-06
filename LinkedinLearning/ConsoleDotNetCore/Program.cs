// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ConsoleDotNetCore.Basis;

internal class Program
{
    static void Main(string[] args)
    {
        var model = new AsyncTips();
        model.Run();
    }
}
