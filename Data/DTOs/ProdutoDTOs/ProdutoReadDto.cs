using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.ProdutoDTOs
{
    public class ProdutoReadDto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        [Required]
        public double Valor { get; set; }

    }
}
