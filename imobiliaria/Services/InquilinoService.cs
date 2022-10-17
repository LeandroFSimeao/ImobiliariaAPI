using AutoMapper;
using FluentResults;
using imobiliaria.Data;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Services
{
    public class InquilinoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public InquilinoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public InquilinoDTO Create(InquilinoDTO dto)
        {
            Inquilino inquilino = _mapper.Map<Inquilino>(dto);

            _context.Inquilinos.Add(inquilino);
            _context.SaveChanges();

            return _mapper.Map<InquilinoDTO>(inquilino);
        }

        public InquilinoDTO GetById(int id)
        {
            Inquilino inquilino = _context.Inquilinos.FirstOrDefault(inquilino => inquilino.IdInquilino == id);
            if (inquilino != null)
            {
                InquilinoDTO InquilinoDTO = _mapper.Map<InquilinoDTO>(inquilino);

                return InquilinoDTO;
            }
            return null;
        }

        public List<InquilinoDTO> GetAll()
        {
            List<Inquilino> inquilinos = _context.Inquilinos.ToList();

            if (inquilinos != null)
            {
                List<InquilinoDTO> readDTO = _mapper.Map<List<InquilinoDTO>>(inquilinos);
                return readDTO;
            }

            return null;
        }

        public Result Update(InquilinoDTO dto)
        {
            Inquilino inquilinos = _context.Inquilinos.FirstOrDefault(inquilinos => inquilinos.IdInquilino == dto.IdInquilino);
            if (inquilinos == null)
            {
                return Result.Fail(" Inquilino não encontrado");
            }

            _mapper.Map(dto, inquilinos);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Inquilino inquilinos = _context.Inquilinos.FirstOrDefault(inquilinos => inquilinos.IdInquilino == id);
            if (inquilinos == null)
            {
                return Result.Fail("Proprietário não encontrado");
            }

            _context.Remove(inquilinos);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
