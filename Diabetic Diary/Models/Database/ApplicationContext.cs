using Microsoft.EntityFrameworkCore;

namespace Diabetic_Diary.Models.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Record> Records => Set<Record>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=diary_history.db");
        }
    }
}
