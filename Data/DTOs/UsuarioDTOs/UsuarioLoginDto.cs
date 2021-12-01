using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.UsuarioDTOs
{
    public class UsuarioLoginDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}
