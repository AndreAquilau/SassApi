using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.UsuarioDTOs;
using SassApi.Models;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly SassApiContext _context;
        public SignupController(SassApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [EnableCors("CorsDefault")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UsuarioCreateDto usuarioCreateDto)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(usuarioCreateDto);

                usuario.Senha = BCrypt.Net.BCrypt.EnhancedHashPassword(usuario.Senha);

                _context.Usuarios.Add(usuario);

                _context.SaveChanges();

                return Ok(new { Id= usuario.Id, Email = usuario.Email, Nome = usuario.Nome });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
