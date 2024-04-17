# AtCorder

## 標準入力
`Console.ReadLine`は、コンソールに入力された1行を読み取る
```cs
// 文字列の入力
string s = Console.ReadLine();

// 整数の入力
long n = long.Parse(Console.ReadLine());

// スペース区切りの文字列の入力
string[] input = Console.ReadLine().Split(' ');

// 整数配列の入力
long[] input = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
```

## Reference
- [AtCorder](https://atcoder.jp/home)
- [Console.ReadLineメソッド](https://learn.microsoft.com/ja-jp/dotnet/api/system.console.readline?view=net-8.0)