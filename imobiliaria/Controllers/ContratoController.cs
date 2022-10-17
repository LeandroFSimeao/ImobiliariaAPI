using FluentResults;
using imobiliaria.Data.Dtos;
using imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratoController : ControllerBase
    {
        private ContratoService _contratoService;

        public ContratoController(ContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        [HttpPost]
        public IActionResult AdicionarContrato(ContratoDTO dto)
        {
            ContratoDTO readDTO = _contratoService.Create(dto);
            return CreatedAtAction(nameof(RecuperaContratoPorId), new { Id = readDTO.idContratoAluguel }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaContratos()
        {
            List<ContratoDTO> readDTO = _contratoService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaContratoPorId(int id)
        {
            ContratoDTO readDTO = _contratoService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut]
        public IActionResult AtualizaContrato(ContratoDTO dto)
        {
            Result resultado = _contratoService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaContrato(int id)
        {
            Result resultado = _contratoService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
