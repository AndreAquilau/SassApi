using AutoMapper;
using SassApi.Data.DTOs.ProdutoDTOs;
using SassApi.Models;

namespace SassApi.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoCreateDto, Produto>();
            CreateMap<Produto, ProdutoReadDto>();
            CreateMap<ProdutoUpdateDto, Produto>();
        }
    }
}
