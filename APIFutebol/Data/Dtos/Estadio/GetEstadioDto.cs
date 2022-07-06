using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.Estadio
{
    public class GetEstadioDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string NomeEstadio { get; set; } = string.Empty;
        
        public int PublicoPresente { get; set; }
    }
}
