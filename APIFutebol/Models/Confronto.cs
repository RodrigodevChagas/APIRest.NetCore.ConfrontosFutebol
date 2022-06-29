using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFutebol.Models
{
    public class Confronto
    {
        public int Id { get; set; }
        public string Times { get; set; } = string.Empty;
        public int ChutesAGol { get; set; }
    }
}
