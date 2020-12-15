using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public class ConfigurationColumnFillRepository : Repository<ConfigurationColumnFillModel>, IConfigurationColumnFillRepository
    {
        public ConfigurationColumnFillRepository(Context db) : base(db)
        {

        }
        public IEnumerable<ConfigurationColumnFillModel> GetValuesByColumnSource(int idColumn)
        {
            return Db.ConfigurationColumnFill.AsNoTracking()
                .Where(a => a.ConfigurationColumnSourceId == idColumn);
        }

        public IEnumerable<ConfigurationColumnFillModel> GetValuesByColumnDestination(int idColumn)
        {
            return Db.ConfigurationColumnFill.AsNoTracking()
                .Where(a => a.ConfigurationColumnDestinationId == idColumn);
        }
    }
}
