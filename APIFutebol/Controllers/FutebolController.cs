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
        public IActionResult AdicionarConfronto([FromBody] Confronto confronto) {

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

                return Ok(confronto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaConfronto(int id, [FromBody] Confronto request) {
        
            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto =>confronto.Id == id);
            if (confronto == null) {

                return NotFound();
            }
            
            confronto.Campeonato = request.Campeonato;
            confronto.Times = request.Times;
            confronto.Estadio = request.Estadio;
            confronto.PublicoPresente = request.PublicoPresente;
            confronto.ChutesAGol_Time1 = request.ChutesAGol_Time1;
            confronto.ChutesAGol_Time2 = request.ChutesAGol_Time2;

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
