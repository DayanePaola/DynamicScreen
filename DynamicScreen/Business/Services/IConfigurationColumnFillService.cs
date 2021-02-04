using DynamicScreen.Data.Models;
using System.Collections.Generic;

namespace DynamicScreen.Business.Services
{
    public interface IConfigurationColumnFillService
    {
        IEnumerable<ConfigurationColumnFillDto> GetColumnsFillByColumnSource(int idColumn);
    }
}