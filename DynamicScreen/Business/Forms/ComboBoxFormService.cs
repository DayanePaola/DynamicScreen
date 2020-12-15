using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicScreen.Business.Util;

namespace DynamicScreen.Business.Forms
{
    public static class ComboBoxFormService
    {
        public static void GetComponent(ConfigurationColumnDto column, TabPage tabPage)
        {
            if (column.Component == ComponentAllowed.DropDownList)
            {
                CreateComponent(column.Name, column.Title, column.EnableValues, tabPage);
            }
        }

        private static void CreateComponent(string name, string title, List<ValueDto> dataSource, Control ctrlParent)
        {
            new Label
            {
                Text = title,
                AutoSize = true,
                Name = $"lbl_{name}",
                Parent = ctrlParent
            };

            new ComboBox
            {
                Name = name,
                Text = title,
                Dock = DockStyle.Top,
                Parent = ctrlParent,
                DataSource = dataSource,
                ValueMember = "Id",
                DisplayMember = "Value"
            };
        }
    }
}
