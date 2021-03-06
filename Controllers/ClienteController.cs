using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.ClienteDTOs;
using SassApi.Models;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SassApiContext _context;

        public ClienteController(SassApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult FindAll()
        {
            try
            {
                IEnumerable<ClienteReadDto> clientes = _context.Clientes
                    .Select(cliente => _mapper.Map<ClienteReadDto>(cliente));

                return Ok(clientes);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult FindById(int id)
        {
            try
            {
                Cliente cliente = _context.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();

                if(cliente == null)
                {
                    return NotFound();
                }

                ClienteReadDto clienteReadDto = _mapper.Map<ClienteReadDto>(cliente);

                return Ok(clienteReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Create([FromBody] ClienteCreateDto clienteCreateDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteCreateDto);

                _context.Clientes.Add(cliente);

                _context.SaveChanges();

                return CreatedAtAction(nameof(FindById), new { Id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("{id}")]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Update([FromBody] ClienteUpdateDto clienteUpdateDto, int id)
        {
            try
            {
                Cliente cliente = _context.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();

                if (cliente == null)
                {
                    return NotFound();
                }

                _mapper.Map(clienteUpdateDto, cliente);

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
        public IActionResult Delete( int id)
        {
            try
            {
                Cliente cliente = _context.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();

                if (cliente == null)
                {
                    return NotFound();
                }

                _context.Clientes.Remove(cliente);

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
