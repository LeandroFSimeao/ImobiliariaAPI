using AutoMapper;
using FluentResults;
using imobiliaria.Data;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Services
{
    public class ImovelService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ImovelService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ImovelDTO Create(ImovelDTO dto)
        {
            Imovel imovel = _mapper.Map<Imovel>(dto);

            _context.Imoveis.Add(imovel);
            _context.SaveChanges();

            return _mapper.Map<ImovelDTO>(imovel);
        }

        public ImovelDTO GetById(int id)
        {
            Imovel imovel = _context.Imoveis.FirstOrDefault(imovel => imovel.IdImovel == id);
            if (imovel != null)
            {
                ImovelDTO imovelDTO = _mapper.Map<ImovelDTO>(imovel);

                return imovelDTO;
            }
            return null;
        }

        public List<ImovelDTO> GetAll()
        {
            List<Imovel> imovels = _context.Imoveis.ToList();

            if (imovels != null)
            {
                List<ImovelDTO> readDTO = _mapper.Map<List<ImovelDTO>>(imovels);
                return readDTO;
            }

            return null;
        }

        public Result Update(ImovelDTO dto)
        {
            Imovel imovel = _context.Imoveis.FirstOrDefault(imovel => imovel.IdImovel == dto.IdImovel);
            if (imovel == null)
            {
                return Result.Fail(" Imovel não encontrado");
            }

            _mapper.Map(dto, imovel);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Imovel imovel = _context.Imoveis.FirstOrDefault(imovel => imovel.IdImovel == id);
            if (imovel == null)
            {
                return Result.Fail("Proprietário não encontrado");
            }

            _context.Remove(imovel);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
