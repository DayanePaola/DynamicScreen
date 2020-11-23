using DynamicScreen.Data.Mappings;
using DynamicScreen.Data.Models;
using Npgsql;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace DynamicScreen.Data
{
    [DbConfigurationType(typeof(NpgSqlConfiguration))]
    public class Context : DbContext
    {
        public Context()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
            Database.Log = log => Debug.WriteLine(log);
        }

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

    public class NpgSqlConfiguration : DbConfiguration
    {
        public NpgSqlConfiguration()
        {
            var name = "Npgsql";

            SetProviderFactory(providerInvariantName: name, providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(providerInvariantName: name, provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());

            SetMigrationSqlGenerator(providerInvariantName: name, () => new SqlGenerator());
        }
    }

    public class SqlGenerator : NpgsqlMigrationSqlGenerator
    {
        private readonly string[] systemColumnNames = { "oid", "tableoid", "xmin", "cmin", "xmax", "cmax", "ctid" };

        protected override void Convert(CreateTableOperation createTableOperation)
        {
            var systemColumns = createTableOperation.Columns.Where(x => systemColumnNames.Contains(x.Name)).ToArray();
            foreach (var systemColumn in systemColumns)
                createTableOperation.Columns.Remove(systemColumn);

            base.Convert(createTableOperation);
        }

        protected override void Convert(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.Name = GetFkName(addForeignKeyOperation.PrincipalTable,
                addForeignKeyOperation.DependentTable, addForeignKeyOperation.DependentColumns.ToArray());

            base.Convert(addForeignKeyOperation);
        }

        protected override void Convert(DropForeignKeyOperation dropForeignKeyOperation)
        {
            dropForeignKeyOperation.Name = GetFkName(dropForeignKeyOperation.PrincipalTable,
                dropForeignKeyOperation.DependentTable, dropForeignKeyOperation.DependentColumns.ToArray());

            base.Convert(dropForeignKeyOperation);
        }

        private static string GetFkName(string primaryKeyTable, string foreignKeyTable, params string[] foreignTableFields)
        {
            return $"FK_{primaryKeyTable.Replace("dbo.","").Substring(0, 5)}_{foreignKeyTable.Replace("dbo.", "").Substring(0, 5)}_{string.Join("-", foreignTableFields.Select(s => s.Replace("dbo.", "")).ToArray())}";
        }
    }
}