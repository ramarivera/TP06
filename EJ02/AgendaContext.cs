using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core.Objects;

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
            // this.Configuration.ProxyCreationEnabled = false;
            // this.Configuration.LazyLoadingEnabled = false;
          //  this.Configuration.AutoDetectChangesEnabled = false;
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
                        .HasMany<Telefono>(p => p.Telefonos)
                    
                       .WithRequired()
                        .Map(m => m.MapKey("PersonaID"))
                        .WillCascadeOnDelete(true);

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

        public override int SaveChanges()
        {
            StreamWriter text = new StreamWriter(".\\sarasa.txt", true);
            text.WriteLine(String.Format("guardando cambios {0}", DateTime.Now));
            try
            {
                // Telefono DELETED
                // Persona MODIFIED

                /*  var lPersonaEntries = this.ChangeTracker.Entries<Persona>();
                  var lTelefonoEntries = this.ChangeTracker.Entries<Telefono>();

                  foreach (var persEntry in lPersonaEntries)
                  {
                      if (persEntry.State == EntityState.Modified)
                      {
                          var sarasa = persEntry.Collection(p => p.Telefonos);
                        //  persEntry.
                          foreach (var item in sarasa.CurrentValue)
                          {

                              if (this.Entry(item).State == EntityState.Deleted)
                              {
                                  ((IObjectContextAdapter)this).ObjectContext.
                                      ObjectStateManager.
                                          ChangeRelationshipState(
                                              persEntry.Entity,
                                              item,
                                              (p => p.Telefonos),
                                              EntityState.Deleted);
                              }
                          }
                      }

                  }*/

                var ent = ChangeTracker.Entries();

                  foreach (var item in this.ChangeTracker.Entries())
                  {
                      text.WriteLine(String.Format("\t entidad: {0},\t estado:{1}", item.Entity, item.State));
                  }

                var algo = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged |EntityState.Modified | EntityState.Deleted);
                foreach (ObjectStateEntry entry in  algo)
                {
                    if (!entry.IsRelationship)
                    {
                        var otra = entry.RelationshipManager;


                        text.WriteLine("Queseyo " +entry.ToString());

                      //  otra.
                    }
                }



                text.Flush();


                return base.SaveChanges();
            }
            catch (Exception e)
            {
                text.WriteLine(e.ToString());
                //   this.ChangeTracker
                throw;
            }
            finally
            {
                text.Close();
            }

        }
    }
}
