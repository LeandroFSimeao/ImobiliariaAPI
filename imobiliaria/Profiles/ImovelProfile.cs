using AutoMapper;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Profiles
{
    public class ImovelProfile : Profile
    {
        public ImovelProfile()
        {
            CreateMap<ImovelDTO, Imovel>();
            CreateMap<Imovel, ImovelDTO>();
        }
    }
}
