using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SassApi.Data;
using SassApi.Data.DTOs.ProdutoDTOs;
using SassApi.Models;

namespace SassApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly SassApiContext _context;

        public ProdutoController(SassApiContext context, IMapper mapper)
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
                IEnumerable<ProdutoReadDto> produtos = _context
                    .Produtos.Select(produto => _mapper.Map<ProdutoReadDto>(produto));

                return Ok(produtos);
            } catch (Exception ex)
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
                Produto produto = _context.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

                if(produto == null)
                {
                    return NotFound();
                }

                ProdutoReadDto produtoReadDto = _mapper.Map<ProdutoReadDto>(produto);

                return Ok(produtoReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Create([FromBody] ProdutoCreateDto produtoCreateDto)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(produtoCreateDto); 

                _context.Produtos.Add(produto);

                _context.SaveChanges();

                return CreatedAtAction(nameof(FindById), new {Id = produto.Id}, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [EnableCors("CorsDefault")]
        [Authorize]
        public IActionResult Update([FromBody] ProdutoUpdateDto produtoUpdateDto,int id)
        {
            try
            {
                Produto produto = _context.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

                if (produto == null)
                {
                    return NotFound();
                }

                _mapper.Map(produtoUpdateDto, produto);

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
        public IActionResult Delete(int id)
        {
            try
            {
                Produto produto = _context.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

                if (produto == null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);

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
