using DynamicScreen.Data.Mappings;
using DynamicScreen.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DynamicScreen.Data
{
    public class Context : DbContext
    {
        public Context(string connString) : base(connString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
            Database.Log = log => Debug.WriteLine(log);
        }

        public DbSet<ConfigurationColumnModel> ConfigurationColumn { get; set; }
        public DbSet<ConfigurationColumnFillModel> ConfigurationColumnFill { get; set; }
        public DbSet<ConfigurationModel> Configurationn { get; set; }
        public DbSet<ConfigurationRowModel> ConfigurationRow { get; set; }
        public DbSet<ConfigurationValueModel> ConfigurationValue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new ConfigurationColumnMapping());
            modelBuilder.Configurations.Add(new ConfigurationColumnFillMapping());
            modelBuilder.Configurations.Add(new ConfigurationMapping());
            modelBuilder.Configurations.Add(new ConfigurationRowMapping());
            modelBuilder.Configurations.Add(new ConfigurationValueMapping());
        }

        public override int SaveChanges()
        {
            try
            {
                var result = base.SaveChanges();
                return result;

            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }

                Debug.WriteLine(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }
    }
}