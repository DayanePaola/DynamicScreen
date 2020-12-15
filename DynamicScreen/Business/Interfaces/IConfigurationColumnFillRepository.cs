using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationColumnFillRepository : IRepository<ConfigurationColumnFillModel>
    {
        IEnumerable<ConfigurationColumnFillModel> GetValuesByColumnSource(int idColumn);
        IEnumerable<ConfigurationColumnFillModel> GetValuesByColumnDestination(int idColumn);
    }
}
