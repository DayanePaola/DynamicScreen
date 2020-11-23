using DynamicScreen.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace DynamicScreen.Data.Mappings
{
    public class ConfigurationColumnFillMapping : EntityTypeConfiguration<ConfigurationColumnFillModel>
    {
        public ConfigurationColumnFillMapping()
        {
            ToTable("ConfigurationColumnFill");
            HasKey(x => x.Id);

            HasRequired(x => x.ConfigurationColumnDestination)
               .WithMany(x => x.ConfigurationColumnDestination)
               .HasForeignKey(x => x.ConfigurationColumnDestinationId)
               .WillCascadeOnDelete(false);

            HasRequired(x => x.ConfigurationColumnSource)
               .WithMany(x => x.ConfigurationColumnSource)
               .HasForeignKey(x => x.ConfigurationColumnSourceId)
               .WillCascadeOnDelete(false);
        }
    }
}