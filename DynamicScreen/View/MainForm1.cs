using DynamicScreen.Data;
using DynamicScreen.Data.Models;
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
        public MainForm1()
        {
            InitializeComponent();

            var tab = AddTab("tabTeste", "XABLAU");
            var teste = new List<ComponentItemDto>(){
                new ComponentItemDto() {
                    Components = ComponentAllowed.Text,
                    Group = "xablauzinho",
                    Index = 1,
                    ConfigurationColumns = new List<ConfigurationColumnDto> ()
                    {
                        new ConfigurationColumnDto { Id = 1, Index = 1, Title = "Código", Name = "codigo_xablau"},
                        new ConfigurationColumnDto { Id = 2, Index = 2, Title = "Descrição", Name = "desc_xablau"}
                    }
                }
            };
            AddComponents(teste, tab);
        }

        private TableLayoutPanel AddTab(string name, string text)
        {
            TabPage tbp = new TabPage();
            tbp.Name = name;
            tbp.Text = text;

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Name = $"tlp_{name}";
            tlp.AutoSize = true;
            tlp.ColumnCount = 2;
            tlp.RowCount = 0;
            tlp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tbp.Controls.Add(tlp);
            tabControl.TabPages.Add(tbp);

            return tlp;
        }

        private void AddComponents(List<ComponentItemDto> configurationColumns, TableLayoutPanel tab)
        {
            configurationColumns.OrderBy(o => o.Index).ToList().ForEach(f =>
            {
                switch (f.Components)
                {
                    case ComponentAllowed.Text:
                        if (f.ConfigurationColumns.Count() > 1)
                        {
                            GroupBox grp = new GroupBox();
                            grp.SuspendLayout();
                            grp.Text = f.Group;
                            grp.Name = $"grp_{f.Group}";
                            grp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            AddTextBox(tab, f, grp);
                            tab.Controls.Add(grp);
                            grp.ResumeLayout(false);
                            break;
                        }
                        AddTextBox(tab, f);
                        break;
                    case ComponentAllowed.Radio:
                        break;
                    case ComponentAllowed.Check:
                        break;
                    case ComponentAllowed.SeachModal:
                        break;
                    case ComponentAllowed.List:
                        break;
                    default:
                        break;
                }
            });
        }

        private static void AddTextBox(TableLayoutPanel tab, ComponentItemDto f, GroupBox grp = null)
        {
            var position = 20;
            f.ConfigurationColumns.OrderBy(o => o.Index).ToList().ForEach(fo =>
            {
                tab.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                Label lbl = new Label();
                lbl.Text = fo.Title;
                lbl.AutoSize = true;
                lbl.Name = $"lbl_{fo.Name}";
                lbl.AutoSize = true;
                lbl.Anchor = AnchorStyles.Top
                           | AnchorStyles.Left;
                lbl.Dock = DockStyle.Fill;

                TextBox txt = new TextBox();
                txt.Name = $"txt_{fo.Name}";
                txt.TabIndex = fo.Index;
                txt.Dock = DockStyle.Fill;
                txt.AutoSize = true;
                txt.Anchor = AnchorStyles.Top
                           | AnchorStyles.Right;

                tab.RowCount++;

                if (grp != null)
                {
                    lbl.Location = new System.Drawing.Point(20, position);
                    txt.Location = new System.Drawing.Point(80, position);
                    position += 40;
                    grp.Controls.Add(lbl);
                    grp.Controls.Add(txt);
                }
            });
        }
    }
}