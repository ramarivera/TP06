using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EJ02
{
    /// <summary>
    /// Representa el contenedor de la entidad definido en el modelo conceptual, la asociacion de los objetos y el uso de las relaciones, en este caso, para una simple agenda telefónica
    /// </summary>
    public class AgendaContext : DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }

        public AgendaContext() : base()
        {
            Database.SetInitializer<AgendaContext>(new DropCreateDatabaseIfModelChanges<AgendaContext>());
        }

        /// <summary>
        /// Define configuracion del modelo una vez que este fue inicializado, pero antes de ver bloqueado para inicializar el contexto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("TDP");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Telefono>().ToTable("Telefono");

            modelBuilder.Entity<Persona>()
                        .HasMany<Telefono>(p => p.Telefonos);
                      /*  .WithRequired()
                        .Map(a => a.MapKey("Persona"))
                        .WillCascadeOnDelete(true);*/


            modelBuilder.Entity<Persona>().HasKey<int>(p => p.PersonaId);

            modelBuilder.Entity<Telefono>().HasKey<int>(t => t.TelefonoId);


            modelBuilder.Entity<Persona>()
                        .Property(p => p.PersonaId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Telefono>()
                        .Property(t => t.TelefonoId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
