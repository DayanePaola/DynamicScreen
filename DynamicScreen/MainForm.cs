using DynamicScreen.Data;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var db = new Context();

            Application.Run(new Form2(db));
        }
    }
}