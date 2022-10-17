using FluentResults;
using imobiliaria.Data.Dtos;
using imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InquilinoController : ControllerBase
    {
        private InquilinoService _inquilinoService;

        public InquilinoController(InquilinoService inquilinoService)
        {
            _inquilinoService = inquilinoService;
        }

        [HttpPost]
        public IActionResult AdicionarInquilino(InquilinoDTO dto)
        {
            InquilinoDTO readDTO = _inquilinoService.Create(dto);
            return CreatedAtAction(nameof(RecuperaInquilinoPorId), new { Id = readDTO.IdInquilino }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaInquilinos()
        {
            List<InquilinoDTO> readDTO = _inquilinoService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaInquilinoPorId(int id)
        {
            InquilinoDTO readDTO = _inquilinoService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut]
        public IActionResult AtualizaInquilino(InquilinoDTO dto)
        {
            Result resultado = _inquilinoService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaInquilino(int id)
        {
            Result resultado = _inquilinoService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
