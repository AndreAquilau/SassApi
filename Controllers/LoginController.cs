using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.UsuarioDTOs;
using SassApi.Models;
using BCrypt.Net;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly SassApiContext _context;

        public LoginController(SassApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Stored([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            try
            {
                Usuario usuario =
                    _context.Usuarios.Where(usuario => usuario.Email == usuarioLoginDto.Email).FirstOrDefault();

                if (usuario == null)
                {
                    return NotFound();
                }

                var validatePassword = BCrypt.Net.BCrypt.EnhancedVerify(usuarioLoginDto.Senha, usuario.Senha);

                if (validatePassword == false)
                {
                    return StatusCode(403);
                }

                return Ok();

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
