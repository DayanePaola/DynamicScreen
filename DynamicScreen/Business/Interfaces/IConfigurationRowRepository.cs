using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationRowRepository : IRepository<ConfigurationRowModel>
    {
        IEnumerable<ConfigurationRowModel> GetRowsByConfiguration(int idConfiguration);
        ConfigurationRowModel GetConfigurationRowValues(int id);
    }
}
