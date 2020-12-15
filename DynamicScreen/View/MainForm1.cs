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
using DynamicScreen.View;
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
        private readonly IConfigurationColumnFillService _configurationColumnFillService;

        public MainForm1(Context db)
        {
            InitializeComponent();

            _configurationService = new ConfigurationService(db);
            _configurationColumnService = new ConfigurationColumnService(db);
            _configurationRowService = new ConfigurationRowService(db);
            _configurationValueService = new ConfigurationValueService(db);
            _configurationColumnFillService = new ConfigurationColumnFillService(db);

            var configurationsDto = _configurationService.GetAllConfigurationsDto();
            foreach (var item in configurationsDto)
            {
                var tab = AddTab(item);
                tab.SuspendLayout();
                AddButtonSave(item, tab);
                AddGrid(item, tab);
                AddButtonSave(item, AddPanel(tab,item.Index,1));
                SetComponents(item, tab);
                tab.ResumeLayout();
            }
        }

        private void AddGrid(ConfigurationTabDto item, TabPage tab)
        {
            var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);
            DataGridView dgv = new DataGridView()
            {

            };
        }

        private void AddButtonSave(ConfigurationTabDto item, Control tab)
        {
            Button btn = new Button();
            btn.Parent = tab;
            btn.Name = $"btn_salvar_{item.Id}";
            btn.Text = "Salvar";
            btn.Dock = DockStyle.Right;
            btn.Click += (object sender, EventArgs e) =>
            {
                Salvar(item, tab);
            };
        }

        private void Salvar(ConfigurationTabDto item, Control tab)
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
            var configurationDto = _configurationService.GetConfigurationByIdDto(item.Id);
            AddComponents(configurationDto, tab);
        }
        public void SetFieldValue(SearchDto item)
        {
            var source = this.Controls.Find(item.ColumnSourceName, true).FirstOrDefault();
            source.Text = item.SelectItem.Id;

            var destination = this.Controls.Find(item.ColumnDestinationName, true).FirstOrDefault();
            destination.Text = item.SelectItem.Value;

            source.Focus();
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
                      SearchModal = s.All(a => a.Component == ComponentAllowed.SearchModal)
                  })
                  .ToList()
                  .ForEach(f =>
                  {
                      var control = AddControl(tab, f);
                      var pos_x = 20;
                      var position = 20;
                      if (f.SearchModal)
                      {
                          var source = f.ConfigurationColumns.OrderBy(o => o.Index).FirstOrDefault(fi => !fi.ReadOnly);
                          var config_fill = _configurationColumnFillService.GetColumnsFillByColumnSource(source.Id).FirstOrDefault();
                          AddTextBox(control, f.ConfigurationColumns.FirstOrDefault(fi => fi.Id == config_fill?.ConfigurationColumnSourceId), ref position, ref pos_x);
                          position -= 40;
                          AddTextBox(control, f.ConfigurationColumns.FirstOrDefault(fi => fi.Id == config_fill.ConfigurationColumnDestinationId), ref position, ref pos_x);
                          position -= 40;
                          AddButtonSearch(control, f, config_fill, ref position, ref pos_x);
                      }
                      else
                      {
                          f.ConfigurationColumns.ToList().ForEach(fo =>
                          {
                              switch (fo.Component)
                              {
                                  case ComponentAllowed.TextBox:
                                      AddTextBox(control, fo, ref position, ref pos_x);
                                      pos_x = 20;
                                      break;
                                  case ComponentAllowed.RadioButton:
                                      position = RadioButonFormService.GetComponent(fo, control, position);
                                      break;
                                  case ComponentAllowed.CheckBox:
                                      position = CheckBoxFormService.GetComponent(fo, control, position);
                                      break;
                                  case ComponentAllowed.DropDownList:
                                      position = AddComboBox(control, fo, position);
                                      break;
                                  default:
                                      break;
                              }
                          });
                      }

                      control.ResumeLayout(false);
                  });

            foreach (var item in config.ConfigurationRow)
            {
                if (item.ConfigurationValue == null)
                    item.ConfigurationValue = new List<ConfigurationValueDto>();

                item.ConfigurationValue.AddRange(_configurationValueService.GetValuesByRow(item.Id));
            }

            DataGridViewFormService.GetComponent(config.ConfigurationColumn.ToList(), config.ConfigurationRow.ToList(), tab);
        }

        private void AddButtonSearch(Control control, ComponentItemDto componentDto, ConfigurationColumnFillDto config_fill, ref int position_y, ref int position_x)
        {
            Button btn = new Button();
            btn.Parent = control;
            btn.Name = $"btn_search_{componentDto.Group}";
            btn.Text = "...";
            btn.Location = new System.Drawing.Point(position_x + 20, position_y);

            var code = componentDto.ConfigurationColumns.FirstOrDefault(fi => fi.Id == config_fill.ConfigurationColumnSourceId);
            var val = componentDto.ConfigurationColumns.FirstOrDefault(fi => fi.Id == config_fill.ConfigurationColumnDestinationId);
            var search = new SearchDto()
            {
                LabelDescriptionName = val.Title,
                LabelIdName = code.Title,
                SearchItems = code.EnableValues,
                ColumnSourceName = $"{code.Name}_{code.Id}",
                ColumnDestinationName = $"{val.Name}_{val.Id}",
            };

            btn.Click += (object sender, EventArgs e) =>
            {
                var form = new GenericSearch(search, this);
                form.Show();
            };
            position_y += 40;
            position_x += btn.Width;
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
                grp.Height = 50 * (f.SearchModal? 1 : f.ConfigurationColumns.Count);
                tab.Controls.Add(grp);
                return grp;
            }

            return AddPanel(tab, f.Index, f.ConfigurationColumns.Count);
        }

        private static Control AddPanel(TabPage tab, int index, int count)
        {
            var panel = new Panel();
            panel.SuspendLayout();
            panel.Name = $"pnl_{index}_{tab.Name}";
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Dock = DockStyle.Top;
            panel.Height = 45 * count;
            tab.Controls.Add(panel);
            return panel;
        }

        private static void AddTextBox(Control control, ConfigurationColumnDto fo, ref int position_y, ref int position_x)
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
            txt.ReadOnly = fo.ReadOnly;

            lbl.Location = new System.Drawing.Point(position_x, position_y);
            position_x += lbl.Width;
            txt.Location = new System.Drawing.Point(position_x, position_y);
            position_x += txt.Width;
            position_y += 40;
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