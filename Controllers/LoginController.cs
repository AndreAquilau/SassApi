using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.UsuarioDTOs;
using SassApi.Models;
using BCrypt.Net;
using SassApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
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
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UsuarioLoginDto usuarioLoginDto)
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

                var token = TokenService.GenerateToken(usuario);

                return Ok(new { token });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
