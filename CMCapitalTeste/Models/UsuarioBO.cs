using System.ComponentModel.DataAnnotations;

namespace CMCapitalAvaliacao.Models
{
    public class UsuarioBO
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User"; 
    }
}



