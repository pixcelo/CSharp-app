namespace ConsoleApp.Classes.Models
{
    /*
    ユーザー名を使用するたびに、各箇所で文字数の確認を行う必要がなくなるメリット
    変更にも対応しやすい(明確なルールの定義が可能)
    */
    public class UserName
    {
        private readonly string value;

        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。 ", nameof(value));

            this.value = value;
        }
    }
}
