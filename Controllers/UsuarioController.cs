using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.ClienteDTOs;
using SassApi.Data.DTOs.UsuarioDTOs;
using SassApi.Models;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SassApiContext _context;

        private readonly IMapper _mapper;

        public UsuarioController(SassApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableCors("CorsDefault")]
        [AllowAnonymous]
        public IActionResult FindAll()
        {
            try
            {
                IEnumerable<UsuarioReadDto> usuarios = _context
                    .Usuarios.Select(usuario => _mapper.Map<UsuarioReadDto>(usuario));

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [EnableCors("CorsDefault")]
        [AllowAnonymous]
        public IActionResult FindById(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefault();

                if (usuario == null)
                {
                    return NotFound();
                }

                UsuarioReadDto clienteReadDto = _mapper.Map<UsuarioReadDto>(usuario);

                return Ok(clienteReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Update([FromBody] UsuarioUpdateDto usuarioUpdateDto, int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefault();

                if(usuario == null)
                {
                    return NotFound();
                }

                _mapper.Map(usuarioUpdateDto, usuario);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Delete([FromBody] UsuarioUpdateDto usuarioUpdateDto, int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefault();

                if (usuario == null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
