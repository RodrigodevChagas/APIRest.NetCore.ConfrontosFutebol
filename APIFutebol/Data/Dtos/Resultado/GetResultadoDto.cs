using APIFutebol.Models;
using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.Estadio
{
    public class GetResultadoDto
    {
     
        [Key]
        [Required]
        public int Id { get; set; }

        public int Placar { get; set; } 

        public Resultado Endereco { get; set; }
    }
}
