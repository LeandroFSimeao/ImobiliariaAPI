using AutoMapper;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Profiles
{
    public class ProprietarioProfile : Profile
    {
        public ProprietarioProfile()
        {
            CreateMap<ProprietarioDTO, Proprietario>();
            CreateMap<Proprietario, ProprietarioDTO>();
        }
    }
}
