// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/*
 問題文
 高橋君はデータの加工が行いたいです。
 整数 a, b, cと、文字列 s が与えられます。 
 a+b+c の計算結果と、文字列 s を並べて表示しなさい。

 制約
 1≤a, b, c≤1,000
 1≤∣s∣≤100

 入力
 入力は以下の形式で与えられる。
 a
 b c
 s
*/


int a = int.Parse(Console.ReadLine());
int[] bc = Console.ReadLine().Split().Select(int.Parse).ToArray();
string s = Console.ReadLine();
Console.WriteLine(($"{a + bc[0] + bc[1]} {s}"));