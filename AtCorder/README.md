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

## 提出結果
- AC = Accepted(正解)
- WA = Wrong Answer(不正解)
- CE = Compile Error（コンパイルエラー）
- RE = Runtime Error（実行時エラー）

## Reference
- [AtCorder](https://atcoder.jp/home)
- [Console.ReadLineメソッド](https://learn.microsoft.com/ja-jp/dotnet/api/system.console.readline?view=net-8.0)
- [競技プログラミングの鉄則](https://github.com/E869120/kyopro-tessoku?tab=readme-ov-file)

## コーディングテスト・試験関連
- [LeetCode](https://leetcode.com/)
- [Codility](https://www.codility.com/)