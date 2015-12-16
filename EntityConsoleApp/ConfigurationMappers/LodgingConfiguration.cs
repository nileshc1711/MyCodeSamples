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
        
        }
    }
}
