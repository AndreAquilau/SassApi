﻿using System.ComponentModel.DataAnnotations;

namespace SassApi.Data.DTOs.UsuarioDTOs
{
    public class UsuarioCreateDto
    {

        [Required]
        public string? Email { get; set; }

        [Required]

        public string? Senha { get; set; }

    }
}
