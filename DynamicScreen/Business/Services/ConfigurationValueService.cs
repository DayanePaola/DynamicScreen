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
    public class ConfigurationValueService : IConfigurationValueService
    {
        private readonly IConfigurationValueRepository _configurationValueRepository;
        private readonly IConfigurationRowRepository _configurationRowRepository;
        private readonly IMapper _mapper;
        public ConfigurationValueService(Context context)
        {
            _configurationValueRepository = new ConfigurationValueRepository(context);
            _configurationRowRepository = new ConfigurationRowRepository(context);
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
        }

        public ConfigurationValueDto GetValeuByColumnRow(int idColumn, int idRow)
        {
            return _mapper.Map<ConfigurationValueDto>(_configurationValueRepository.GetValeuByColumnRow(idColumn, idRow));
        }

        public IEnumerable<ConfigurationValueDto> GetValuesByColumn(int idColumn)
        {
            return _mapper.Map<IEnumerable<ConfigurationValueDto>>(_configurationValueRepository.GetValuesByColumn(idColumn));
        }

        public IEnumerable<ConfigurationValueDto> GetValuesByRow(int idRow)
        {
            return _mapper.Map<IEnumerable<ConfigurationValueDto>>(_configurationValueRepository.GetValuesByRow(idRow));
        }

        public void InsertRangeValuesDto(int idConfiguration, int idRow, IEnumerable<ConfigurationValueDto> configurationValuesDto)
        {
            var configurationValuesModel = _mapper.Map<IEnumerable<ConfigurationValueModel>>(configurationValuesDto);

            var configurationRowModel = _configurationRowRepository.GetById(idRow);

            if (configurationRowModel == null)
            {
                var lastRow = _configurationRowRepository.GetRowsByConfiguration(idConfiguration).FirstOrDefault();
                var lastIndex = lastRow == null ? 0 : lastRow.Index;
                configurationRowModel = new ConfigurationRowModel()
                {
                    ConfigurationId = idConfiguration,
                    Index = lastIndex++
                };
                _configurationRowRepository.Insert(configurationRowModel);
            }

            configurationValuesModel.ToList().ForEach(a => a.ConfigurationRowId = configurationRowModel.Id);

            _configurationValueRepository.InsertRange(configurationValuesModel);
        }
    }
}
