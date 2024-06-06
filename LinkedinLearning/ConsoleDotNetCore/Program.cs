// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ConsoleDotNetCore.Basis;
using ConsoleDotNetCore.Delegate;
using ConsoleDotNetCore.DesignPattern;
using ConsoleDotNetCore.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        //var model = new Iterator();
        //model.Run();

        // コンストラクタの確認
        var person = new Person("Taro", 20);
        Console.WriteLine(person.Name + " " + person.Age);

        var person2 = new Person("Ken");
        Console.WriteLine(person2.Name + " " + person2.Age);

        var person3 = new Person();
        Console.WriteLine(person3.Name + " " + person3.Age);
    }
}
