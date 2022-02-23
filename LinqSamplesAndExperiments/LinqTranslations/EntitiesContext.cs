using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LinqTranslations
{
    public class EntitiesContext : DbContext
    {
        //public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                .UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog = SampleEntitiesDatabase;Integrated Security =True;Connect Timeout = 30;Encrypt = False;TrustServerCertificate = False;ApplicationIntent = ReadWrite;MultiSubnetFailover = False");
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
