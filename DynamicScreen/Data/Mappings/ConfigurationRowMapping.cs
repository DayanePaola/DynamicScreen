using DynamicScreen.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace DynamicScreen.Data.Mappings
{
    public class ConfigurationRowMapping : EntityTypeConfiguration<ConfigurationRowModel>
    {
        public ConfigurationRowMapping()
        {
            ToTable("ConfigurationRow");
            HasKey(x => x.Id);

            HasRequired(x => x.Configuration)
                .WithMany(x => x.ConfigurationRow)
                .HasForeignKey(x => x.ConfigurationId)
                .WillCascadeOnDelete(false);
        }
    }
}