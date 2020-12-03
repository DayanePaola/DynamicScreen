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
    }
}
