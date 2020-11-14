using DynamicScreen.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace DynamicScreen.Data.Mappings
{
    public class ConfigurationColumnMapping : EntityTypeConfiguration<ConfigurationColumnModel>
    {
        public ConfigurationColumnMapping()
        {
            ToTable("ConfigurationColumn");
            HasKey(x => x.Id);

            HasRequired(x => x.Configuration)
                .WithMany(x => x.ConfigurationColumn)
                .HasForeignKey(x => x.ConfigurationId)
                .WillCascadeOnDelete(false);
        }
    }
}