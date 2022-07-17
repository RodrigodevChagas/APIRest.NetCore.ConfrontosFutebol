using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Models;
using System.Collections;
using APIFutebol.Data.Dtos.ResultadoDto;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadoController : ControllerBase
    {
        private FutebolContext _context;
        private IMapper _mapper;

        public ResultadoController(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarResultado([FromBody] PostEPutResultadoDto requestDto)
        {

            Resultado resultado = _mapper.Map<Resultado>(requestDto);

            _context.Resultados.Add(resultado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaResultadoPorId), new { Id = resultado.Id }, resultado);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IEnumerable RecuperarResultado()
        {

            return _context.Resultados;
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaResultadoPorId(int id)
        {

            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);
            if (resultado != null)
            {

                GetResultadoDto requestDto = _mapper.Map<GetResultadoDto>(resultado);
                return Ok(requestDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaResultado(int id, [FromBody] PostEPutResultadoDto requestDto)
        {


            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);
            if (resultado == null)
            {

                return NotFound();
            }

            _mapper.Map(requestDto, resultado);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaResultado(int id)
        {

            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);

            if (resultado == null)
            {

                return NotFound();
            }

            _context.Remove(resultado);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
