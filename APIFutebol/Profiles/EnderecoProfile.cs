using APIFutebol.Data.Dtos.Endereco;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<PostEPutEnderecoDto, Endereco>();
            CreateMap<Endereco, GetEnderecoDto>();
        }
    }
}
