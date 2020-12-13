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
    public class ConfigurationRowService : IConfigurationRowService
    {
        private readonly IConfigurationRowRepository _configurationRowRepository;
        private readonly IMapper _mapper;
        public ConfigurationRowService(Context context)
        {
            _configurationRowRepository = new ConfigurationRowRepository(context);
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
        }

        public IEnumerable<ConfigurationRowDto> GetRowsByConfigurationDto(int idConfiguration)
        {
            var rows = _configurationRowRepository.GetRowsByConfiguration(idConfiguration);
            return _mapper.Map<IEnumerable<ConfigurationRowDto>>(rows);
        }
    }
}
