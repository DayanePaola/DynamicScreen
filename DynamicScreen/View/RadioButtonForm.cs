using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using DynamicScreen.Enums;
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
    public partial class RadioButtonForm : Form
    {
        private readonly IConfigurationColumnService _configurationColumnService;
        public RadioButtonForm(Context context)
        {
            InitializeComponent();
            _configurationColumnService = new ConfigurationColumnService(context);
        }

    }
}
