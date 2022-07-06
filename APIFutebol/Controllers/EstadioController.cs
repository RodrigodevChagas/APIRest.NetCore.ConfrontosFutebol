using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Data.Dtos.Estadio;
using APIFutebol.Models;
using System.Collections;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class EstadioController : Controller
    {
        private FutebolContext _context;
        private IMapper _mapper;

        public EstadioController(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarEstadio([FromBody] PostEPutEstadioDto requestDto)
        {

            Estadio estadio = _mapper.Map<Estadio>(requestDto);

            _context.Estadios.Add(estadio);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEstadioPorId), new { Id = estadio.Id }, estadio);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IEnumerable RecuperarEstadio()
        {

            return _context.Estadios;
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaEstadioPorId(int id)
        {

            Estadio estadio = _context.Estadios.FirstOrDefault(estadio => estadio.Id == id);
            if (estadio != null)
            {

                GetEstadioDto requestDto = _mapper.Map<GetEstadioDto>(estadio);
                return Ok(requestDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEstadio(int id, [FromBody] PostEPutEstadioDto requestDto)
        {


            Estadio estadio = _context.Estadios.FirstOrDefault(estadio => estadio.Id == id);
            if (estadio == null)
            {

                return NotFound();
            }

            _mapper.Map(requestDto, estadio);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEstadio(int id)
        {

            Estadio estadio = _context.Estadios.FirstOrDefault(estadio => estadio.Id == id);

            if (estadio == null)
            {

                return NotFound();
            }

            _context.Remove(estadio);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
