using AutoMapper;
using DynamicScreen.Business.AutoMapper;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class MainForm1 : Form
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IConfigurationRepository _configurationRepository;
        public MainForm1(Context context)
        {
            _mapper = new Mapper(ConfigurationMapper.MapperConfiguration());
            _context = context;
            _configurationRepository = new ConfigurationRepository(_context);
            InitializeComponent();

            //Exemplo de como fazer o mapping
            var listaConfiguracao = _configurationRepository.GetAll();
            var configurationModel = listaConfiguracao.FirstOrDefault();
            var configurationModel2 = _configurationRepository.GetConfigurationColumnRows(configurationModel.Id);


            //De Model para DTO
            var configurationTabDto = _mapper.Map<ConfigurationTabDto>(configurationModel2);
            //De DTO para Model
            var newConfigurationModel = _mapper.Map<ConfigurationModel>(configurationTabDto);

            var tab = AddTab("tabTeste", "XABLAU");
            tab.SuspendLayout();
            var teste = new List<ComponentItemDto>(){
                new ComponentItemDto() {
                    Components = ComponentAllowed.TextBox,
                    Group = "xablauzinho",
                    Index = 1,
                    ConfigurationColumns = new List<ConfigurationColumnDto> ()
                    {
                        new ConfigurationColumnDto { Id = 1, Index = 1, Title = "Código", Name = "codigo_xablau"},
                        new ConfigurationColumnDto { Id = 2, Index = 2, Title = "Descrição", Name = "desc_xablau"}
                    }
                },
                new ComponentItemDto() {
                   Components = ComponentAllowed.TextBox,
                   Group = "XPTO",
                   Index = 1,
                   ConfigurationColumns = new List<ConfigurationColumnDto> ()
                   {
                       new ConfigurationColumnDto { Id = 1, Index = 1, Title = "CampoXPTO", Name = "codigo_xpto"},
                   }
                },
                new ComponentItemDto() {
                   Components = ComponentAllowed.TextBox,
                   Group = "XPTO",
                   Index = 1,
                   ConfigurationColumns = new List<ConfigurationColumnDto> ()
                   {
                       new ConfigurationColumnDto { Id = 1, Index = 1, Title = "CampoXPTO1", Name = "codigo_xpto1"},
                   }
                }
            };
            AddComponents(teste, tab);
            tab.ResumeLayout();
        }

        private TabPage AddTab(string name, string text)
        {
            TabPage tbp = new TabPage();
            tbp.Name = name;
            tbp.Text = text;

            //TableLayoutPanel tlp = new TableLayoutPanel();
            //tlp.Name = $"tlp_{name}";
            //tlp.AutoSize = true;
            //tlp.Dock = DockStyle.Fill;
            //tlp.ColumnCount = 2;
            //tlp.RowCount = 0;
            //tlp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //tlp.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            //tbp.Controls.Add(tlp);
            tabControl.TabPages.Add(tbp);
            return tbp;
            //return tlp;
        }

        private void AddComponents(List<ComponentItemDto> configurationColumns, TabPage tab)
        {
            configurationColumns.OrderBy(o => o.Index).ToList().ForEach(f =>
            {
                switch (f.Components)
                {
                    case ComponentAllowed.TextBox:
                        if (f.ConfigurationColumns.Count() > 1)
                        {
                            GroupBox grp = AddGroupBox(tab, f);
                            AddTextBox(tab, f, grp);
                            grp.ResumeLayout(false);
                            break;
                        }
                        AddTextBox(tab, f);
                        break;
                    case ComponentAllowed.RadioButton:
                        break;
                    case ComponentAllowed.CheckBox:
                        break;
                    case ComponentAllowed.SeachModal:
                        break;
                    case ComponentAllowed.DropDownList:
                        break;
                    default:
                        break;
                }
            });
        }

        private static GroupBox AddGroupBox(TabPage tab, ComponentItemDto f)
        {
            GroupBox grp = new GroupBox();
            grp.SuspendLayout();
            grp.Text = f.Group;
            grp.Dock = DockStyle.Top;
            grp.Name = $"grp_{f.Group}";
            grp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tab.Controls.Add(grp);
            return grp;
        }

        private static void AddTextBox(TabPage tab, ComponentItemDto f, GroupBox grp = null)
        {
            var position = 20;
            f.ConfigurationColumns.OrderBy(o => o.Index).ToList().ForEach(fo =>
            {
                //tab.RowStyles.Add(new RowStyle(SizeType.Percent));
                Label lbl = new Label();
                lbl.Text = fo.Title;
                lbl.AutoSize = true;
                lbl.Name = $"lbl_{fo.Name}";
                //lbl.AutoSize = true;
                //lbl.Anchor = AnchorStyles.Top
                //           | AnchorStyles.Left;
                lbl.Dock = DockStyle.Top;

                TextBox txt = new TextBox();
                txt.Name = $"txt_{fo.Name}";
                txt.TabIndex = fo.Index;
                txt.Dock = DockStyle.Top;
                txt.AutoSize = true;
                //txt.Anchor = AnchorStyles.Left
                //           | AnchorStyles.Right;

                if (grp != null)
                {
                    lbl.Location = new System.Drawing.Point(20, position);
                    txt.Location = new System.Drawing.Point(80, position);
                    position += 40;
                    grp.Controls.Add(txt);
                    grp.Controls.Add(lbl);
                }
                else
                {
                    tab.Controls.Add(txt);
                    tab.Controls.Add(lbl);
                }
                //tab.RowCount++;
            });
        }
    }
}