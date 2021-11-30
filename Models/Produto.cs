using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SassApi.Models
{
    public class Produto
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
