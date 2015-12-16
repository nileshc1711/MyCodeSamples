using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EntityConsoleApp.Models;

namespace EntityConsoleApp.ConfigurationMappers
{
    internal class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration() 
        {
            this.HasKey<Guid>(t => t.Identifier);
        }

    }
}
