using AutoMapper;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Profiles
{
    public class ContratoProfile : Profile
    {
        public ContratoProfile()
        {
            CreateMap<ContratoDTO, ContratoAluguel>();
            CreateMap<ContratoAluguel, ContratoDTO>();
        }
    }
}
