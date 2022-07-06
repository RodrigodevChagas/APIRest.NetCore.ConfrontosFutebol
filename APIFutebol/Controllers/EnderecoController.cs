using APIFutebol.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Data.Dtos.Endereco;
using System.Collections;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class EnderecoController : Controller
    {
        private FutebolContext _context;
        private IMapper _mapper;

        public EnderecoController(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] PostEPutEnderecoDto requestDto)
        {

            Endereco endereco = _mapper.Map<Endereco>(requestDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IEnumerable RecuperarEndereco()
        {

            return _context.Enderecos;
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {

            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            
            if (endereco != null)
            {

                GetEnderecoDto requestDto = _mapper.Map<GetEnderecoDto>(endereco);
                return Ok(requestDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] PostEPutEnderecoDto requestDto)
        {


            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            
            if (endereco == null)
            {

                return NotFound();
            }

            _mapper.Map(requestDto, endereco);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {

            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
            {

                return NotFound();
            }

            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
