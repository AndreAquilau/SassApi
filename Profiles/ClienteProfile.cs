using AutoMapper;
using SassApi.Data.DTOs.ClienteDTOs;
using SassApi.Models;

namespace SassApi.Profiles
{
    public class ClienteProfile : Profile
    {

        public ClienteProfile()
        {
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<Cliente, ClienteReadDto>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
