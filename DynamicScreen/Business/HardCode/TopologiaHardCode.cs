using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class TopologiaHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Topologia",
                Title = "Topologias",
                Index = index,
                Enable = true
            };

            return newConfiguration;
        }

        public IEnumerable<ConfigurationColumnModel> CreateColumns(int idConfiguration)
        {
            var listColumns = new List<ConfigurationColumnModel>()
            {
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Topologia",
                    Title = "Topologia",
                    Component = "DropDownList",
                    Index = 0,
                    ReadOnly = false,
                    Group = "Topologia",
                    Method = "ObterListaDeTopologias"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Familia",
                    Title = "Família",
                    Component = "DropDownList",
                    Index = 1,
                    ReadOnly = false,
                    Group = "Familia",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Instalacao",
                    Title = "Característica de instalação",
                    Component = "DropDownList",
                    Index = 2,
                    ReadOnly = false,
                    Group = "Instalacao",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "VelocidadeVento",
                    Title = "Velocidade do vento",
                    Component = "CheckBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = "VelocidadeVento",
                    Method = "ObterVelocidadeDoVento"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Ativo",
                    Title = "Status: ",
                    Component = "RadioButton",
                    Index = 7,
                    ReadOnly = false,
                    Group = "status",
                    Method = "ObterRadioStatus"
                },
            };

            return listColumns;
        }
    }
}