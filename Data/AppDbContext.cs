using APIDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Data {
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
            { }
        public DbSet<Espera>? Esperas { get; set; }
        public DbSet<Atendimento>? Atendimentos { get; set; }


    }
}
