using APIFutebol.Data.Dtos.Confronto;
using APIFutebol.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIFutebol.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //Indica rota
    public class FutebolController : ControllerBase
    {
        private FutebolContext _context; 
        private IMapper _mapper; 

        public FutebolController(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarConfronto([FromBody] PostEPutDto requestDto) {

            Confronto confronto = _mapper.Map<Confronto>(requestDto);

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
                
                GetDto requestDto = _mapper.Map<GetDto>(confronto);
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

            _mapper.Map(requestDto, confronto);

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
