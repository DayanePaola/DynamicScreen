﻿using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationRepository : IRepository<ConfigurationModel>
    {
        ConfigurationModel GetConfigurationColumnRows(int id);
    }
}
