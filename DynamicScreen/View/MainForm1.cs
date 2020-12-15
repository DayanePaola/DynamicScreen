using AutoMapper;
using DynamicScreen.Business.AutoMapper;
using DynamicScreen.Business.Forms;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class MainForm1 : Form
    {
        private readonly IConfigurationService _configurationService;
        private readonly IConfigurationColumnService _configurationColumnService;
        private readonly IConfigurationRowService _configurationRowService;
        private readonly IConfigurationValueService _configurationValueService;

        public MainForm1(Context db)
        {
            InitializeComponent();

            _configurationService = new ConfigurationService(db);
            _configurationColumnService = new ConfigurationColumnService(db);
            _configurationRowService = new ConfigurationRowService(db);
            _configurationValueService = new ConfigurationValueService(db);

            var configurationsDto = _configurationService.GetAllConfigurationsDto();
            foreach (var item in configurationsDto)
            {
                var tab = AddTab(item);
                Button btn = new Button();
                btn.Parent = tab;
                btn.Name = $"btn_salvar_{item.Id}";
                btn.Text = "Salvar";
                btn.Dock = DockStyle.Top;
                btn.Click += (object sender, EventArgs e) =>
                {
                    Salvar(item, tab);
                };

                SetComponents(item, tab);
            }
        }

        private void Salvar(ConfigurationTabDto item, TabPage tab)
        {
            var configValues = new List<ConfigurationValueDto>();
            var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);
            foreach (var col in configurationDto.ConfigurationColumn)
            {
                var component = tab.Controls.Find($"{col.Name}_{col.Id}", true).FirstOrDefault();
                var value = new ConfigurationValueDto()
                {
                    ConfigurationColumnId = col.Id,
                    Value = component.Text,
                    ConfigurationRowId = item.RowId
                };
                configValues.Add(value);
            }
            _configurationValueService.InsertRangeValuesDto(item.Id, item.RowId, configValues);
        }

        private void SetComponents(ConfigurationTabDto item, TabPage tab)
        {
            tab.SuspendLayout();
            var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);
            AddComponents(configurationDto, tab);
            tab.ResumeLayout();
        }

        private TabPage AddTab(ConfigurationTabDto item)
        {
            TabPage tbp = new TabPage();
            tbp.Name = item.Name;
            tbp.Text = item.Title;
            tabControl.TabPages.Add(tbp);
            return tbp;
        }

        private void AddComponents(ConfigurationTabDto config, TabPage tab)
        {
            config.ConfigurationColumn
                  .OrderByDescending(o => o.Index)
                  .GroupBy(g => g.Group)
                  .Select(s => new ComponentItemDto()
                  {
                      Group = s.Key,
                      ConfigurationColumns = s.ToList(),
                      SearchModal = s.All(a => a.Component == ComponentAllowed.SeachModal)
                  })
                  .ToList()
                  .ForEach(f =>
                  {
                      var control = AddControl(tab, f);
                      var position = 20;
                      f.ConfigurationColumns.ToList().ForEach(fo =>
                      {
                          switch (fo.Component)
                          {
                              case ComponentAllowed.TextBox:
                                  position = AddTextBox(control, fo, position);
                                  break;
                              case ComponentAllowed.RadioButton:
                                  position = RadioButonFormService.GetComponent(fo, control, position);
                                  break;
                              case ComponentAllowed.CheckBox:
                                  position = CheckBoxFormService.GetComponent(fo, control, position);
                                  break;
                              case ComponentAllowed.SeachModal:
                                  break;
                              case ComponentAllowed.DropDownList:
                                  position = AddComboBox(control, fo, position);
                                  break;
                              default:
                                  break;
                          }
                      });

                      control.ResumeLayout(false);
                  });
        }

        private static Control AddControl(TabPage tab, ComponentItemDto f)
        {
            if (f.ConfigurationColumns.Count > 1)
            {
                var group_find = tab.Controls.Find($"grp_{f.Group}", true).FirstOrDefault();
                if (group_find != null)
                {
                    return group_find;
                }

                GroupBox grp = new GroupBox();
                grp.SuspendLayout();
                grp.Text = f.Group;
                grp.Dock = DockStyle.Top;
                grp.Name = $"grp_{f.Group}";
                grp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                grp.Height = 50 * (f.ConfigurationColumns.Count);
                tab.Controls.Add(grp);
                return grp;
            }

            var panel = new Panel();
            panel.SuspendLayout();
            panel.Name = $"pnl_{f.Index}";
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Dock = DockStyle.Top;
            panel.Height = 50 * (f.ConfigurationColumns.Count);
            tab.Controls.Add(panel);
            return panel;
        }

        private static int AddTextBox(Control control, ConfigurationColumnDto fo, int position)
        {
            Label lbl = new Label();
            lbl.Text = fo.Title;
            lbl.AutoSize = true;
            lbl.Name = $"lbl_{fo.Name}_{fo.Id}";
            lbl.Parent = control;

            TextBox txt = new TextBox();
            txt.Name = $"{fo.Name}_{fo.Id}";
            txt.TabIndex = fo.Index;
            txt.AutoSize = true;
            txt.Parent = control;

            lbl.Location = new System.Drawing.Point(20, position);
            txt.Location = new System.Drawing.Point(lbl.Width + 20, position);
            position += 40;
            return position;
        }

        private static int AddComboBox(Control control, ConfigurationColumnDto fo, int position)
        {
            var lbl = new Label
            {
                Text = fo.Title,
                AutoSize = true,
                Name = $"lbl_{fo.Name}_{fo.Id}",
                Parent = control
            };

            var cbx = new ComboBox
            {
                Name = $"{fo.Name}_{fo.Id}",
                TabIndex = fo.Index,
                AutoSize = true,
                Parent = control,
                DataSource = fo.EnableValues,
                ValueMember = "Id",
                DisplayMember = "Value"
            };

            lbl.Location = new System.Drawing.Point(20, position);
            cbx.Location = new System.Drawing.Point(lbl.Width + 20, position);
            position += 40;
            return position;
        }
    }
}