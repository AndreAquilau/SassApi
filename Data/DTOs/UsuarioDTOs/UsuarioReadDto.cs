using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.UsuarioDTOs
{
    public class UsuarioReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }

    }
}
