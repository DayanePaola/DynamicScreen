using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationValueRepository : IRepository<ConfigurationValueModel>
    {
        ConfigurationValueModel GetValeuByColumnRow(int idColumn, int idRow);
        IEnumerable<ConfigurationValueModel> GetValuesByRow(int idRow);
        IEnumerable<ConfigurationValueModel> GetValuesByColumn(int idColumn);
    }
}
