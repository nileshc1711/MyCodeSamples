using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EntityConsoleApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityConsoleApp.ConfigurationMappers
{
    internal class PersonsConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonsConfiguration() 
        {
            //this.HasKey<int>(p => p.SocialSecurityNumber);
            this.Property<int>(p => p.SocialSecurityNumber)
                .HasDatabaseGeneratedOption(databaseGeneratedOption: DatabaseGeneratedOption.None)
                .IsConcurrencyToken();
        }
    }
}
