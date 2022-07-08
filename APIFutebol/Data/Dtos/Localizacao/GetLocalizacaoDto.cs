using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.Endereco
{
    public class GetLocalizacaoDto
    {
        [Key]
        [Required]

        public int Id { get; set; }

        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade{ get; set; } 
    }
}
