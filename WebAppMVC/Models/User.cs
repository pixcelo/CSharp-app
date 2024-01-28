using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Username { get; set; }
        [StringLength(100)]
        public string? Password { get; set; }
    }
}
