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
    public static class TextBoxFormService
    {
        public static void GetComponent(ConfigurationColumnDto column, TabPage tabPage, ref int position)
        {
            if (column.Component == ComponentAllowed.TextBox)
            {
                CreateComponent(column, ref position, tabPage);
            }
        }

        private static void CreateComponent(ConfigurationColumnDto column, ref int position, Control ctrlParent)
        {
            var lbl = new Label
            {
                Text = column.Title,
                AutoSize = true,
                Name = $"lbl_{column.Name}_{column.Id}",
                Parent = ctrlParent
            };

            var txt = new TextBox
            {
                Name = $"{column.Name}_{column.Id}",
                TabIndex = column.Index,
                AutoSize = true,
                Parent = ctrlParent
            };

            lbl.Location = new System.Drawing.Point(20, position);
            txt.Location = new System.Drawing.Point(lbl.Width + 20, position);
            position += 40;
        }
    }
}
