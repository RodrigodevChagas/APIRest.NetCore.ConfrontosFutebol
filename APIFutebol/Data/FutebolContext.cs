using APIFutebol.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFutebol.Data
{
    public class FutebolContext : DbContext
    {
     
        // Preenchendo o construtuor de DbContext
        public FutebolContext(DbContextOptions<FutebolContext> opt) : base(opt){}

        public DbSet<Confronto> Confrontos { get; set; } // Definindo o conjunto que estarei usando para o banco de dados
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}
