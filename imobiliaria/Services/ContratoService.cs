using AutoMapper;
using FluentResults;
using imobiliaria.Data;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;

namespace imobiliaria.Services
{
    public class ContratoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ContratoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ContratoDTO Create(ContratoDTO dto)
        {
            ContratoAluguel contrato = _mapper.Map<ContratoAluguel>(dto);

            _context.Contratos.Add(contrato);
            _context.SaveChanges();

            return _mapper.Map<ContratoDTO>(contrato);
        }

        public ContratoDTO GetById(int id)
        {
            ContratoAluguel contrato = _context.Contratos.FirstOrDefault(contrato => contrato.idContratoAluguel == id);
            if (contrato != null)
            {
                ContratoDTO contratoDTO = _mapper.Map<ContratoDTO>(contrato);

                return contratoDTO;
            }
            return null;
        }

        public List<ContratoDTO> GetAll()
        {
            List<ContratoAluguel> contratos = _context.Contratos.ToList();

            if (contratos != null)
            {
                List<ContratoDTO> readDTO = _mapper.Map<List<ContratoDTO>>(contratos);
                return readDTO;
            }

            return null;
        }

        public Result Update(ContratoDTO dto)
        {
            ContratoAluguel contrato = _context.Contratos.FirstOrDefault(contrato => contrato.idContratoAluguel == dto.idContratoAluguel);
            if (contrato == null)
            {
                return Result.Fail(" Contrato não encontrado");
            }

            _mapper.Map(dto, contrato);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            ContratoAluguel contrato = _context.Contratos.FirstOrDefault(contrato => contrato.idContratoAluguel == id);
            if (contrato == null)
            {
                return Result.Fail("Proprietário não encontrado");
            }

            _context.Remove(contrato);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
