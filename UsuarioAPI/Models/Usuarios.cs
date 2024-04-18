using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Mail { get; set; } = string.Empty;
    }
}
