using APIFutebol.Data.Dtos.Estadio;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class EstadioProfile : Profile
    {
        public EstadioProfile()
        {
            CreateMap<PostEPutEstadioDto, Estadio>();
            CreateMap<Estadio, GetEstadioDto>();
        }
    }
}
