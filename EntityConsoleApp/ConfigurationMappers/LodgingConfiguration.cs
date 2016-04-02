using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EntityConsoleApp.Models;

namespace EntityConsoleApp.ConfigurationMappers
{
    internal class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration() {
            Property(l => l.Name).IsRequired().HasMaxLength(200);
            Property(l => l.Owner).IsUnicode();
            Property(l => l.MilesFromNearestAirport).HasPrecision(8, 1);

            HasOptional<Person>(l => l.PrimaryContact).WithMany(p => p.PrimaryContactFor);
            HasOptional<Person>(l => l.SecondaryContact).WithMany(p => p.SecondaryContactFor);

            HasRequired<Destination>(l => l.Destination).WithMany(d => d.Lodgings).WillCascadeOnDelete(false); 
        }
    }
}
