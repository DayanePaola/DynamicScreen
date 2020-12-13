using AutoMapper;
using DynamicScreen.Business.AutoMapper;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Services
{
    public class ConfigurationColumnService : IConfigurationColumnService
    {
        private readonly IConfigurationColumnRepository _configurationColumnRepository;
        private readonly IMapper _mapper;
        public ConfigurationColumnService(Context context)
        {
            _configurationColumnRepository = new ConfigurationColumnRepository(context);
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
        }

        public IEnumerable<ConfigurationColumnDto> GetColumnsByConfigurationDto(int idConfiguration)
        {
            return _mapper.Map<IEnumerable<ConfigurationColumnDto>>(_configurationColumnRepository.GetColumnsByConfiguration(idConfiguration));
        }
    }
}
