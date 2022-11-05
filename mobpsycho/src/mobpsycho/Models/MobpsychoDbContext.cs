using Microsoft.EntityFrameworkCore;

namespace mobpsycho.Models
{
    // Read more about Code Fist https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

    public class MobpsychoDbContext: DbContext
    {
        // Constructor
        public MobpsychoDbContext() { }

        public MobpsychoDbContext(DbContextOptions<MobpsychoDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Abilitie> Abilities { get; set; }

        // Override names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Abilitie>().ToTable("Abilitie");
        }

    }
}
