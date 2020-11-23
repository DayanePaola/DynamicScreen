using DynamicScreen.Data;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class MainForm : Form
    {
        public MainForm(string connString)
        {
            InitializeComponent();

            using (var context = new Context(connString))
            {

            }
        }
    }
}