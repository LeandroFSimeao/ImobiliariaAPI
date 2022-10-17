using FluentResults;
using imobiliaria.Data.Dtos;
using imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        private ImovelService _imovelService;

        public ImovelController(ImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        [HttpPost]
        public IActionResult AdicionarImovel(ImovelDTO dto)
        {
            ImovelDTO readDTO = _imovelService.Create(dto);
            return CreatedAtAction(nameof(RecuperaImovelPorId), new { Id = readDTO.IdImovel }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaImovels()
        {
            List<ImovelDTO> readDTO = _imovelService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaImovelPorId(int id)
        {
            ImovelDTO readDTO = _imovelService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut]
        public IActionResult AtualizaImovel(ImovelDTO dto)
        {
            Result resultado = _imovelService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaImovel(int id)
        {
            Result resultado = _imovelService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
