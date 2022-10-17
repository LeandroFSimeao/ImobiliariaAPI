using AutoMapper;
using FluentResults;
using imobiliaria.Data;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Services
{
    public class ProprietarioService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProprietarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProprietarioDTO Create(ProprietarioDTO dto)
        {
            Proprietario proprietario = _mapper.Map<Proprietario>(dto);

            _context.Proprietarios.Add(proprietario);
            _context.SaveChanges();

            return _mapper.Map<ProprietarioDTO>(proprietario);
        }

        public ProprietarioDTO GetById(int id)
        {
            Proprietario proprietario = _context.Proprietarios.FirstOrDefault(proprietario => proprietario.IdProprietario == id);
            if(proprietario != null)
            {
                ProprietarioDTO proprietarioDTO = _mapper.Map<ProprietarioDTO>(proprietario);

                return proprietarioDTO;
            }
            return null;
        }

        public List<ProprietarioDTO> GetAll()
        {
            List<Proprietario> proprietarios = _context.Proprietarios.ToList();

            if(proprietarios != null)
            {
                List<ProprietarioDTO> readDTO = _mapper.Map<List<ProprietarioDTO>>(proprietarios);
                return readDTO;
            }

            return null;
        }

        public Result Update(ProprietarioDTO dto)
        {
            Proprietario proprietario = _context.Proprietarios.FirstOrDefault(proprietario => proprietario.IdProprietario == dto.IdProprietario);
            if (proprietario == null)
            {
                return Result.Fail(" Proprietario não encontrado");
            }

            _mapper.Map(dto, proprietario);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Proprietario proprietario = _context.Proprietarios.FirstOrDefault(proprietario => proprietario.IdProprietario == id);
            if(proprietario == null)
            {
                return Result.Fail("Proprietário não encontrado");
            }

            _context.Remove(proprietario);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
