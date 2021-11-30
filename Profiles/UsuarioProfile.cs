using AutoMapper;
using SassApi.Data.DTOs.UsuarioDTOs;
using SassApi.Models;

namespace SassApi.Profiles
{
    public class UsuarioProfile : Profile
    {

        public UsuarioProfile()
        {
            CreateMap<UsuarioCreateDto,Usuario>();
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}
