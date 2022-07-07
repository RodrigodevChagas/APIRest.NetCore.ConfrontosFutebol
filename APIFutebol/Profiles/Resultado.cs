using APIFutebol.Data.Dtos.Estadio;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class Resultado : Profile
    {
        public Resultado()
        {
            CreateMap<PostEPutResultadoDto, Models.Resultado>();
            CreateMap<Models.Resultado, GetResultadoDto>();
        }
    }
}
