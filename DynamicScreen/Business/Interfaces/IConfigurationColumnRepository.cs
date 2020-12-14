using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationColumnRepository : IRepository<ConfigurationColumnModel>
    {
        IEnumerable<ConfigurationColumnModel> GetColumnsByConfiguration(int idConfiguration);
        ConfigurationColumnModel GetConfigurationColumnValues(int id);
    }
}
