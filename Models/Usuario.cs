﻿using System;
using System.ComponentModel.DataAnnotations;


namespace SassApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }

    }
}
