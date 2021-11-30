using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.ClienteDTOs
{
    public class ClienteCreateDto
    {
        [Required]
        public string? Nome { get; set; }

        public string? Cpf { get; set; }

        public string? Endereco { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

    }
}
