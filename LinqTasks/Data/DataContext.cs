using LinqTasks.Models.Home;
using Microsoft.EntityFrameworkCore;

namespace LinqTasks.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ProgrammingTask> ProgrammingTasks { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<Difficulty> Difficulties { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
