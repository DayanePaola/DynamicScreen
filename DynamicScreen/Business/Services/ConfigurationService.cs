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
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        public ConfigurationService(Context context)
        {
            _configurationRepository = new ConfigurationRepository(context);
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
        }

        public IEnumerable<ConfigurationTabDto> GetAllConfigurationsDto()
        {
            return _mapper.Map<IEnumerable<ConfigurationTabDto>>(_configurationRepository.GetAll());
        }

        public ConfigurationTabDto GetConfigurationByIdDto(int idConfiguration)
        {
            var config = _configurationRepository.GetConfigurationColumnRows(idConfiguration);
            return _mapper.Map<ConfigurationTabDto>(config);
        }

    }
}
