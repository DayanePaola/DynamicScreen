using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationRowService
    {
        IEnumerable<ConfigurationRowDto> GetRowsByConfigurationDto(int idConfiguration);
    }
}
