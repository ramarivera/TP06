﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

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



        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }

        public AgendaContext() : base()
        {
            Database.SetInitializer<AgendaContext>(new DropCreateDatabaseIfModelChanges<AgendaContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AgendaContext, Migrations.Configuration>());
            //Console.WriteLine(this.Database.Connection.ConnectionString);
            //

            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //

            modelBuilder.HasDefaultSchema("TDP");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Telefono>().ToTable("Telefono");

            modelBuilder.Entity<Persona>()
                        .HasMany<Telefono>(p => p.Telefonos);
                       /* .WithRequired()
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
