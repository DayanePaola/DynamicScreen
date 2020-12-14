using DynamicScreen.Business.Forms;
using DynamicScreen.Business.HardCode;
using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using DynamicScreen.Enums;
using DynamicScreen.View;
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

            var configurationsDto = _configurationService.GetAllConfigurationsDto();
            var tabPage = new TabPage();

            foreach (var item in configurationsDto)
            {
                var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);

                var rowsDto = _configurationRowService.GetRowsByConfigurationDto(item.Id);
                var columnsDto = _configurationColumnService.GetColumnsByConfigurationDto(item.Id);

                tabPage = new TabPage
                {
                    Name = $"{configurationDto.Name}",
                    Text = $"{configurationDto.Title}"
                };

                tabPage.SuspendLayout();

                foreach (var col in columnsDto)
                {
                    ComboBoxFormService.GetComponent(col, tabPage);
                    RadioButonFormService.GetComponent(col, tabPage);
                    CheckBoxFormService.GetComponent(col, tabPage);
                }

                tabPage.ResumeLayout();
                tabControl1.Controls.Add(tabPage);
            }
        }

    }
}
