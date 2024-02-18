// クエリタイプを表すクラス
using Microsoft.VisualBasic;

public class Query
{
    // リゾルバー関数
    public string Hello(string Name = "World")
        => $"Hello, {Name}!";

    public IEnumerable<Book> GetBooks()
    {
        var author = new Author("Jon Skeet");
        yield return new Book("C# in Depth", author);
        yield return new Book("C# in Depth 2nd Edition", author);
    }
}

public record Author(string name);

public record Book(string Title, Author Author);