using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace gp2.Models
{
    public class User
    {
        public int UserId { get; set; } // PK
        public string Username { get; set; } // Kullanıcı adı
        public string Email { get; set; } // E-posta adresi
        public string Password { get; set; } // Şifre 
        public DateTime CreatedAt { get; set; } // Hesap oluşturulma tarihi

        public List<Transaction> Transactions { get; set; }

    }

}
