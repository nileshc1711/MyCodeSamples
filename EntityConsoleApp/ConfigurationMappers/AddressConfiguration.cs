using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EntityConsoleApp.Models;


namespace EntityConsoleApp.ConfigurationMappers
{
    class AddressConfiguration : ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration() 
        {
            Property(p => p.StreetAddress).HasMaxLength(250);
           
        }
    }
}
