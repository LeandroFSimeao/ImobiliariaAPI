using FluentResults;
using imobiliaria.Data.Dtos;
using imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private ProprietarioService _proprietarioService;

        public ProprietarioController(ProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        [HttpPost]
        public IActionResult AdicionarProprietario(ProprietarioDTO dto)
        {
            ProprietarioDTO readDTO = _proprietarioService.Create(dto);
            return CreatedAtAction(nameof(RecuperaProprietarioPorId), new {Id = readDTO.IdProprietario}, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaProprietarios()
        {
            List<ProprietarioDTO> readDTO = _proprietarioService.GetAll();
            if(readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProprietarioPorId(int id)
        {
            ProprietarioDTO readDTO = _proprietarioService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut]
        public IActionResult AtualizaProprietario(ProprietarioDTO dto)
        {
            Result resultado = _proprietarioService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaProprietario(int id)
        {
            Result resultado = _proprietarioService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
