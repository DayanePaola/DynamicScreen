using DynamicScreen.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace DynamicScreen.Data.Mappings
{
    public class ConfigurationMapping : EntityTypeConfiguration<ConfigurationModel>
    {
        public ConfigurationMapping()
        {
            ToTable("Configuration");
            HasKey(x => x.Id);
        }
    }
}