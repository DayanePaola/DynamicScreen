using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public class ConfigurationRepository : Repository<ConfigurationModel>, IConfigurationRepository
    {
        public ConfigurationRepository(Context db) : base(db)
        {
        }

        public ConfigurationModel GetConfigurationColumnRows(int id)
        {
            return Db.Configurationn.AsNoTracking()
                .Include("ConfigurationRow")
                .Include("ConfigurationColumn")
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
