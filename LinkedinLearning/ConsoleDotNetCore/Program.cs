// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ConsoleDotNetCore.Basis;
using ConsoleDotNetCore.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        var model = new GenericTips();
        model.Run();
    }
}
