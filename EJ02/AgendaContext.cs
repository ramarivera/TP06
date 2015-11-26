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
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                        .HasOptional(p => p.Telefonos)
                        .WithMany()
                        .WillCascadeOnDelete(true);
        }
    }
}
