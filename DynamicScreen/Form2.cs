using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class Form2 : Form
    {
        private readonly IConfigurationRepository _configurationRepository;
        public Form2(Context db)
        {
            InitializeComponent();

            _configurationRepository = new ConfigurationRepository(db);

            var lista = _configurationRepository.ObterTodos();
            var primeiro = lista.FirstOrDefault();
            if(primeiro != null)
            {
                var objetoAlterar = _configurationRepository.ObterPorId(primeiro.Id);
                objetoAlterar.Name = "Name alterado";
                objetoAlterar.Enable = false;
                _configurationRepository.Atualizar(objetoAlterar);

                var objetoNovo = new ConfigurationModel
                {
                    Name = "Name novo Deletar",
                    Title = "Título novo",
                    Enable = true
                };

                _configurationRepository.Adicionar(objetoNovo);
            }
            else
            {
                var objetoNovo = new ConfigurationModel
                {
                    Name = "Name novo",
                    Title = "Título novo",
                    Enable = true
                };

                _configurationRepository.Adicionar(objetoNovo);
            }

            lista = _configurationRepository.ObterTodos();

            _configurationRepository.Remover(2);

            lista = _configurationRepository.ObterTodos();
        }
    }
}
