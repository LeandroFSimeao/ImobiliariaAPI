using FluentResults;
using imobiliaria.Data.Dtos;
using imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco(CreateEnderecoDTO dto)
        {
            EnderecoDTO readDTO = _enderecoService.Create(dto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDTO.IdEndereco }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<EnderecoDTO> readDTO = _enderecoService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            EnderecoDTO readDTO = _enderecoService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut]
        public IActionResult AtualizaEndereco(EnderecoDTO dto)
        {
            Result resultado = _enderecoService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _enderecoService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
