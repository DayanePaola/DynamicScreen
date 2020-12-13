using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationService
    {
        IEnumerable<ConfigurationTabDto> GetAllConfigurationsDto();
        ConfigurationTabDto GetConfigurationByIdDto(int idConfiguration);
    }
}
