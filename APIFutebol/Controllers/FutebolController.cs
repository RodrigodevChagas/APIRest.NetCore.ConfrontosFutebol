using APIFutebol.Data.Dtos;
using APIFutebol.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FutebolController : ControllerBase
    {
        private FutebolContext _context;

        public FutebolController(FutebolContext context)
        {
            _context = context;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarConfronto([FromBody] PostEPutDto requestDto) {

            Confronto confronto = new Confronto{

                Campeonato = requestDto.Campeonato,
                Times = requestDto.Times,
                Estadio = requestDto.Estadio,
                PublicoPresente = requestDto.PublicoPresente,
                ChutesAGol_Time1 = requestDto.ChutesAGol_Time1,
                ChutesAGol_Time2 = requestDto.ChutesAGol_Time2
            };

            _context.Confrontos.Add(confronto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaConfrontoPorId), new { Id = confronto.Id }, confronto);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IEnumerable RecuperarConfronto(){
            
            return _context.Confrontos;    
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaConfrontoPorId (int id)
        {

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto => confronto.Id == id);
            if (confronto != null){
                
                GetDto requestDto = new GetDto{

                    Campeonato = confronto.Campeonato,
                    Times = confronto.Times,
                    Estadio = confronto.Estadio,
                    PublicoPresente = confronto.PublicoPresente,
                    ChutesAGol_Time1 = confronto.ChutesAGol_Time1,
                    ChutesAGol_Time2 = confronto.ChutesAGol_Time2
                };
                
                return Ok(requestDto);
            }
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaConfronto(int id, [FromBody] PostEPutDto requestDto) {
        

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto =>confronto.Id == id);
            if (confronto == null) {

                return NotFound();
            }

            confronto.Campeonato = requestDto.Campeonato;
            confronto.Times = requestDto.Times;
            confronto.Estadio = requestDto.Estadio;
            confronto.PublicoPresente = requestDto.PublicoPresente;
            confronto.ChutesAGol_Time1 = requestDto.ChutesAGol_Time1;
            confronto.ChutesAGol_Time2 = requestDto.ChutesAGol_Time2;
            
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConfronto(int id) {

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto => confronto.Id == id);
            
            if (confronto == null)
            {

                return NotFound();
            }

            _context.Remove(confronto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
