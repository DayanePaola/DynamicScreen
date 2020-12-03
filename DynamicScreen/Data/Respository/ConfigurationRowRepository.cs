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
    }
}
