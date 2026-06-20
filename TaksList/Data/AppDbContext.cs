using Microsoft.EntityFrameworkCore;
using TaksList.Models.Classes;

namespace TaksList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TarefaAgenda> TarefaAgendas { get; set; }
        public DbSet<TarefaDiaria> TarefaDiarias { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
