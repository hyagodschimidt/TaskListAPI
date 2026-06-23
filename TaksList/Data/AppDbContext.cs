using Microsoft.EntityFrameworkCore;
using TaksList.Models.Classes;

namespace TaksList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ScheduledTask> ScheduledTasks { get; set; }
        public DbSet<RecurringTask> RecurringTasks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

