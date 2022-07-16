using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Models
{
    public class Resultado
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Placar { get; set; }

        public virtual Confronto Confronto { get; set; }

        public int ConfrontoId { get; set; }
    }
}
