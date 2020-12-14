using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.Business.Forms
{
    public static class CheckBoxFormService
    {
        public static void GetComponent(ConfigurationColumnDto column, TabPage tabPage)
        {
            if (column.Component == ComponentAllowed.CheckBox)
            {
                var group = AddGroupBox(tabPage, column);
                foreach (var item in column.EnableValues)
                {
                    CreateComponent($"cb_{column.Name}_{item.Id}", item.Value, group);
                }
                group.ResumeLayout();
            }
        }

        private static void CreateComponent(string strName, string strText, Control ctrlParent)
        {
            new CheckBox
            {
                Name = strName,
                Text = strText,
                Dock = DockStyle.Top,
                Parent = ctrlParent
            };
        }

        private static GroupBox AddGroupBox(TabPage tab, ConfigurationColumnDto column)
        {
            GroupBox grp = new GroupBox();
            grp.SuspendLayout();
            grp.Text = column.Title;
            grp.Dock = DockStyle.Top;
            grp.Name = $"grp_{column.Group}";
            grp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tab.Controls.Add(grp);
            return grp;
        }
    }
}
