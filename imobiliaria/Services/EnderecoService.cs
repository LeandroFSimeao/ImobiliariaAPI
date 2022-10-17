using AutoMapper;
using FluentResults;
using imobiliaria.Data;
using imobiliaria.Data.Dtos;
using imobiliaria.Models;
using Newtonsoft.Json;

namespace imobiliaria.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EnderecoDTO Create(CreateEnderecoDTO dto)
        {
            //Consulta API do ViaCep para recuperar as outras informações do endereco para que o usuário não precise mandar
            EnderecoViaCepDTO enderecoCompleto = this.RecuperaEnderecoPeloCep(dto.Cep);
         
            Endereco endereco = new Endereco();
            endereco.Cep = enderecoCompleto.cep;
            endereco.Logradouro = enderecoCompleto.logradouro;
            endereco.Numero = dto.Numero;
            endereco.Cidade = enderecoCompleto.localidade;
            endereco.Estado = enderecoCompleto.uf;

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<EnderecoDTO>(endereco);
        }

        private EnderecoViaCepDTO RecuperaEnderecoPeloCep(string cep)
        {
            string urlApi = $"https://viacep.com.br/ws/{cep}/json";
            try
            {
                using( var cliente = new HttpClient())
                {
                    //Requisição assíncrona à API ViaCep
                    var request = cliente.GetStringAsync(urlApi);
                    request.Wait();

                    var response = JsonConvert.DeserializeObject<EnderecoViaCepDTO>(request.Result);

                    return response;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public EnderecoDTO GetById(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEndereco == id);
            if (endereco != null)
            {
                EnderecoDTO enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);

                return enderecoDTO;
            }
            return null;
        }

        public List<EnderecoDTO> GetAll()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();

            if (enderecos != null)
            {
                List<EnderecoDTO> readDTO = _mapper.Map<List<EnderecoDTO>>(enderecos);
                return readDTO;
            }

            return null;
        }

        public Result Update(EnderecoDTO dto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEndereco == dto.IdEndereco);
            if (endereco == null)
            {
                return Result.Fail(" Endereco não encontrado");
            }

            _mapper.Map(dto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEndereco == id);
            if (endereco == null)
            {
                return Result.Fail("Proprietário não encontrado");
            }

            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
