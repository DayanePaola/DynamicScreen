using DynamicScreen.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace DynamicScreen.Data.Mappings
{
    public class ConfigurationValueMapping : EntityTypeConfiguration<ConfigurationValueModel>
    {
        public ConfigurationValueMapping()
        {
            ToTable("ConfigurationValue");
            HasKey(x => x.Id);

            HasRequired(x => x.ConfigurationColumn)
               .WithMany(x => x.ConfigurationValue)
               .HasForeignKey(x => x.ConfigurationColumnId)
               .WillCascadeOnDelete(false);

            HasRequired(x => x.ConfigurationRow)
               .WithMany(x => x.ConfigurationValue)
               .HasForeignKey(x => x.ConfigurationRowId)
               .WillCascadeOnDelete(false);
        }
    }
}