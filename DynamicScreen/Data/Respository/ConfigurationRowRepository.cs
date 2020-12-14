using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public class ConfigurationRowRepository : Repository<ConfigurationRowModel>, IConfigurationRowRepository
    {
        public ConfigurationRowRepository(Context db) : base(db)
        {
        }

        public ConfigurationRowModel GetConfigurationRowValues(int id)
        {
            return Db.ConfigurationRow.AsNoTracking()
                .Include("ConfigurationValue")
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<ConfigurationRowModel> GetRowsByConfiguration(int idConfiguration)
        {
            return Db.ConfigurationRow.AsNoTracking()
                .Where(a => a.ConfigurationId == idConfiguration);
        }
    }
}
