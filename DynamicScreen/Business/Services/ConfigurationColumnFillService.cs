using AutoMapper;
using DynamicScreen.Business.AutoMapper;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Services
{
    public class ConfigurationColumnFillService : IConfigurationColumnFillService
    {
        private readonly IConfigurationColumnFillRepository _configurationColumnFillRepository;
        private readonly IMapper _mapper;
        public ConfigurationColumnFillService(Context context)
        {
            _configurationColumnFillRepository = new ConfigurationColumnFillRepository(context);
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
        }

        public IEnumerable<ConfigurationColumnFillDto> GetColumnsFillByColumnSource(int idColumn)
        {
            return _mapper.Map<IEnumerable<ConfigurationColumnFillDto>>(_configurationColumnFillRepository.GetValuesByColumnSource(idColumn));
        }
    }
}
