using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Models
{
    public class Estadio
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string NomeEstadio { get; set; } = string.Empty;

        public int PublicoPresente { get; set; }
    }
}
