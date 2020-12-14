using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Data.Respository
{
    public class ConfigurationValueRepository : Repository<ConfigurationValueModel>, IConfigurationValueRepository
    {
        public ConfigurationValueRepository(Context db) : base(db)
        {
        }

        public ConfigurationValueModel GetValeuByColumnRow(int idColumn, int idRow)
        {
            return Db.ConfigurationValue.AsNoTracking()
                .FirstOrDefault(a => a.ConfigurationColumnId == idColumn && a.ConfigurationRowId == idRow);
        }

        public IEnumerable<ConfigurationValueModel> GetValuesByColumn(int idColumn)
        {
            return Db.ConfigurationValue.AsNoTracking()
                .Where(a => a.ConfigurationColumnId == idColumn);
        }

        public IEnumerable<ConfigurationValueModel> GetValuesByRow(int idRow)
        {
            return Db.ConfigurationValue.AsNoTracking()
                .Where(a => a.ConfigurationRowId == idRow);
        }
    }
}
