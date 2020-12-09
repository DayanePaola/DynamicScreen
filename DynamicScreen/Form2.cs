using DynamicScreen.Business.HardCode;
using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Business.Services;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class Form2 : Form
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMethodColumnService _methodColumnService;

        public Form2(Context db)
        {
            InitializeComponent();

            _configurationRepository = new ConfigurationRepository(db);
            _methodColumnService = new MethodColumnService(db);

            new InitialDataBase(db);

            var configurations = _configurationRepository.GetAll();

            var retornoTopologia = "Lista de Topologia";

            foreach (var item in configurations)
            {
                var configuration = _configurationRepository.GetConfigurationColumnRows(item.Id);

                var objeto = _methodColumnService.ExecuteMethodColumnByConfiguration(item.Id);

                if (objeto != null && objeto.Count() > 0)
                {
                    foreach (var item2 in objeto)
                    {
                        retornoTopologia += $"\nTopologia: {item2.Codigo} - {item2.Descricao}";
                    }
                }
            }


            MessageBox.Show(retornoTopologia, "Método do Column", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
