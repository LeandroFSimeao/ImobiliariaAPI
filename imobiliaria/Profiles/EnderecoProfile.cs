using AutoMapper;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<Endereco, EnderecoDTO>();
        }
    }
}
