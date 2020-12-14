using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.Business.Forms
{
    public static class RadioButonFormService
    {
        public static int GetComponent(ConfigurationColumnDto column, Control control, int position)
        {
            if (column.Component == ComponentAllowed.RadioButton)
            {
                var group = AddGroupBox(control, column);
                group.SuspendLayout();
                int i = 20;
                foreach (var item in column.EnableValues.OrderByDescending(a => a.Id))
                {
                    var radio = new RadioButton
                    {
                        Name = $"{column.Name}_{item.Id}",
                        Text = item.Value,
                        Dock = DockStyle.Top,
                        Parent = group
                    };
                    radio.Location = new Point(i, 20);
                    position += 40;
                    i += radio.Width;
                }
                group.ResumeLayout();
            }

            return position;
        }

        private static GroupBox AddGroupBox(Control control, ConfigurationColumnDto column)
        {
            GroupBox grp = new GroupBox
            {
                Text = column.Title,
                Dock = DockStyle.Top,
                Name = $"grp_{column.Group}",
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            control.Controls.Add(grp);
            return grp;
        }
    }
}
