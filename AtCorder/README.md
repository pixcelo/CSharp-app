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
- TLE = Time Limit Exceeded（時間制限超過）

## Reference
- [AtCorder](https://atcoder.jp/home)
- [Console.ReadLineメソッド](https://learn.microsoft.com/ja-jp/dotnet/api/system.console.readline?view=net-8.0)
- [競技プログラミングの鉄則](https://github.com/E869120/kyopro-tessoku?tab=readme-ov-file)

## コーディングテスト・試験関連
- [LeetCode](https://leetcode.com/)
- [Codility](https://www.codility.com/)

## 勉強になりそうな書籍・サイトのリンク
- [Atcoder入緑したのでまとめ ~競技プログラミングは個人的には役に立ってる~](https://zenn.dev/sojiro/articles/a9bb4852598aa2)
- [AtCoder　凡人が『緑』になるための精選50問詳細解説 ](https://www.amazon.co.jp/gp/product/B09C3TPQYV/ref=kinw_myk_ro_title)
- [アルゴ式](https://algo-method.com/)