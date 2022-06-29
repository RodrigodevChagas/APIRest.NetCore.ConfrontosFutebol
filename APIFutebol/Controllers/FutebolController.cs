using APIFutebol.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FutebolController : ControllerBase
    {
        
        private static List<Confronto> confrontos= new List<Confronto>(); // Cria lista do tipo Confronto
        private static int id = 1; // cria o id para ser usado no programa

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarConfronto([FromBody] Confronto confronto) {

            confronto.Id = id++;   
            confrontos.Add(confronto);
            return CreatedAtAction(nameof(RecuperaConfrontoPorId), new { Id = confronto.Id }, confronto);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IActionResult RecuperarConfronto(){
            
            return Ok(confrontos);    
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaConfrontoPorId (int id)
        {

            Confronto confronto = confrontos.FirstOrDefault(confronto => confronto.Id == id);
            if (confronto != null)
            {

                return Ok(confronto);
            }
            return NotFound();
        }
    }
}
