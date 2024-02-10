namespace ConsoleApp.Classes.Models
{

    /// <summary>
    /// Userクラスに対するDTO(Data Transfer Object)
    /// クライアントに渡すためのデータ転送用オブジェクト
    /// DTOへのデータの移し替えはアプリケーションサービスで処理
    /// </summary>
    public class UserData
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public UserData(User user)
        {
            Id = user.Id.Value;
            Name = user.Name.Value;
        }
    }
}
