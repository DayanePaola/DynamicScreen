using DynamicScreen.Business.HardCode;
using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class Form2 : Form
    {
        private readonly IConfigurationService _configurationService;
        private readonly IConfigurationColumnService _configurationColumnService;
        private readonly IConfigurationRowService _configurationRowService;
        private readonly IConfigurationValueService _configurationValueService;

        public Form2(Context db)
        {
            InitializeComponent();

            _configurationService = new ConfigurationService(db);
            _configurationColumnService = new ConfigurationColumnService(db);
            _configurationRowService = new ConfigurationRowService(db);
            _configurationValueService = new ConfigurationValueService(db);

            new InitialDataBase(db);

            var configurationsDto = _configurationService.GetAllConfigurationsDto();
            foreach (var item in configurationsDto)
            {
                var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);

                var rowsDto = _configurationRowService.GetRowsByConfigurationDto(item.Id);
                var columnsDto = _configurationColumnService.GetColumnsByConfigurationDto(item.Id);


                foreach (var row in rowsDto)
                {
                    var valuesRowDto = _configurationValueService.GetValuesByRow(row.Id);
                    foreach (var col in columnsDto)
                    {
                        var valuesColumnDto = _configurationValueService.GetValuesByColumn(col.Id);
                        var valueDto = _configurationValueService.GetValeuByColumnRow(col.Id, row.Id);
                    }
                }
            }
        }
    }
}
