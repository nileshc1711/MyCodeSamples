using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EntityConsoleApp.Models;

namespace EntityConsoleApp.ConfigurationMappers
{
    internal class DestinationConfiguration :EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration() {
            Property(d => d.Name).IsRequired();
            Property(d => d.Description).HasMaxLength(500);
            Property(d => d.Photo).HasColumnType("Image");

            

        }
    }
}
