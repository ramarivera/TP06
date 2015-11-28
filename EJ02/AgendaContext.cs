using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ02
{
    public class AgendaContext : DbContext
    {
        /*public SchoolDBContext(): base("SchoolDBConnectionString") 
        {
            Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }*/

        

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        public AgendaContext() : base()
        {
            Database.SetInitializer<AgendaContext>(new DropCreateDatabaseIfModelChanges<AgendaContext>());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("TDP");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Telefono>().ToTable("Telefono");

            modelBuilder.Entity<Persona>()
                        .HasMany<Telefono>(p => p.Telefonos)
                        .WithRequired()
                        .Map(a => a.MapKey("Persona"))
                        .WillCascadeOnDelete(true);
        }
    }
}
