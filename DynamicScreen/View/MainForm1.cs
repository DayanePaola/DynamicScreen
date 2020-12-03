using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                var query = context.Configurationn.Include(i => i.ConfigurationColumn).Include(i => i.ConfigurationRow).ToList();

                query.ForEach(f =>
                {
                    var tab = AddTab(f.Name, f.Title);
                    AddComponents(f.ConfigurationColumn.ToList(), tab);
                });
            }
        }

        private TabPage AddTab(string name, string text)
        {
            TabPage tbp = new TabPage();
            tbp.Name = name;
            tbp.Text = text;
            tabControl.TabPages.Add(tbp);
            return tbp;
        }

        private void AddComponents(List<ConfigurationColumnModel> configurationColumns, TabPage tab)
        {
            configurationColumns.ForEach(f=>
            {
                f.Component == 
            });
        }
    }
}