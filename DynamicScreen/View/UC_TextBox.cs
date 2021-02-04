using DynamicScreen.Business.Services;
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
    public partial class UC_TextBox : UserControlBase<TextBox>
    {
        public UC_TextBox()
        {
            InitializeComponent();

            label1.Text = "OMG!!!";
            textBox1.Text = "INSIRA UM TEXTO AQUI";
        }
    }
}
