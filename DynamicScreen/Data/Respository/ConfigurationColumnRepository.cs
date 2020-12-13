using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public class ConfigurationColumnRepository : Repository<ConfigurationColumnModel>, IConfigurationColumnRepository
    {
        public ConfigurationColumnRepository(Context db) : base(db)
        {
        }

        public IEnumerable<ConfigurationColumnModel> GetColumnsByConfiguration(int idConfiguration)
        {
            return Db.ConfigurationColumn.AsNoTracking()
                .Where(a => a.ConfigurationId == idConfiguration);
        }

        public ConfigurationColumnModel GetConfigurationColumnValues(int id)
        {
            return Db.ConfigurationColumn.AsNoTracking()
                .Include("ConfigurationValue")
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
