using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp.Models
{
    /// <summary>
    /// We can configure the In those cases where Code First needs some help understanding your intent, you have
    ///two options for performing configuration: Data Annotations and Code First’s Fluent
    ///API.
    ///This is by using Fluent API
    /// </summary>
    public class VetContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //This is to map to AnimalType Entity to Table Species
            modelBuilder.Entity<AnimalType>().ToTable("Species");

            //Making a field to Required
            modelBuilder.Entity<AnimalType>().Property(p => p.TypeName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }


    }

    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destionations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().Property(d => d.Name).IsRequired();

            modelBuilder.Entity<Destination>().Property(d => d.Description).HasMaxLength(500);

            modelBuilder.Entity<Destination>().Property(d => d.Photo).HasColumnType("image");

            modelBuilder.Entity<Lodging>()
                        .Property(l => l.Name).IsRequired().HasMaxLength(500);

            base.OnModelCreating(modelBuilder);
        }
    }
}
