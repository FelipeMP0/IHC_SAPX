using IHC.Models;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace IHC.Contexts
{
    public class IhcContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Planning> Plannings { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<IhcContext>(modelBuilder));
        }
    }
}
