using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.View
{
    public partial class CheckboxForm : Form
    {
        private readonly IConfigurationColumnService _configurationColumnService;
        public CheckboxForm(Context context, int idConfiguration, int idColumn)
        {
            InitializeComponent();
            _configurationColumnService = new ConfigurationColumnService(context);

            var columns = _configurationColumnService.GetColumnsByConfigurationDto(idConfiguration);

            var column = columns.FirstOrDefault(a => a.Id == idColumn);

            if (column != null)
            {

            }
        }
        private CheckBox CreateCheckbox(string strName, string strText, Control ctrlParent, EventHandler handlerCheckChanged)
        {
            CheckBox cb = new CheckBox
            {
                Name = strName,
                Text = strText,
                Dock = DockStyle.Top,                                      
                Parent = ctrlParent
            };
            cb.CheckedChanged += handlerCheckChanged;

            return cb;
        }
    }
}
