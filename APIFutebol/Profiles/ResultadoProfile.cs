using APIFutebol.Data.Dtos.ResultadoDto;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<PostEPutResultadoDto, Models.Resultado>();
            CreateMap<Models.Resultado, GetResultadoDto>();
        }
    }
}
