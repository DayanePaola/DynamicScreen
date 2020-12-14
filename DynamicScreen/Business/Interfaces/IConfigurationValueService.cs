using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IConfigurationValueService
    {
        ConfigurationValueDto GetValeuByColumnRow(int idColumn, int idRow);
        IEnumerable<ConfigurationValueDto> GetValuesByRow(int idRow);
        IEnumerable<ConfigurationValueDto> GetValuesByColumn(int idColumn);
    }
}
