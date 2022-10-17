using AutoMapper;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Profiles
{
    public class InquilinoProfile : Profile
    {
        public InquilinoProfile()
        {
            CreateMap<InquilinoDTO, Inquilino>();
            CreateMap<Inquilino, InquilinoDTO>();
        }
    }
}
