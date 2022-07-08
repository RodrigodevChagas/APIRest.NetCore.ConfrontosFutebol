using APIFutebol.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Data.Dtos.Endereco;
using System.Collections;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class LocalizacaoController : Controller
    {
        private FutebolContext _context;
        private IMapper _mapper;

        public LocalizacaoController(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarLocalizacao([FromBody] PostEPutLocalizacaoDto requestDto)
        {

            Localizacao localizacao = _mapper.Map<Localizacao>(requestDto);

            _context.Localizacoes.Add(localizacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLocalizacaoPorId), new { Id = localizacao.Id }, localizacao);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IEnumerable RecuperarLocalizacao()
        {

            return _context.Localizacoes;
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaLocalizacaoPorId(int id)
        {

            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);
            
            if (localizacao != null)
            {

                GetLocalizacaoDto requestDto = _mapper.Map<GetLocalizacaoDto>(localizacao);
                return Ok(requestDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLocalizacao(int id, [FromBody] PostEPutLocalizacaoDto requestDto)
        {


            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);
            
            if (localizacao == null)
            {

                return NotFound();
            }

            _mapper.Map(requestDto, localizacao);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLocalizacao(int id)
        {

            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);

            if (localizacao == null)
            {

                return NotFound();
            }

            _context.Remove(localizacao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
