using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.ProdutoDTOs
{
    public class ProdutoUpdateDto
    {

        [Required]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        [Required]
        public double Valor { get; set; }

    }
}
