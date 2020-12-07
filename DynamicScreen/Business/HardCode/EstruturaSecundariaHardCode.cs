using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class EstruturaSecundariaHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "EstruturaSecundaria",
                Title = "Estrutura Secundária",
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
                    Name = "QuantidadeDeRedesDeBT",
                    Title = "Quantidade de Redes de BT",
                    Component = "DropDownList",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "DeflexaoMaxima",
                    Title = "Deflexão Máxima",
                    Component = "TextBox",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "FimDeRedeDeBT",
                    Title = "Fim de rede de BT",
                    Component = "RadioButtom",
                    Index = 2,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Quantidade",
                    Title = "Quantidade",
                    Component = "TextBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Estrutura",
                    Title = "Estrutura",
                    Component = "TextBox",
                    Index = 4,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "NTC",
                    Title = "NTC",
                    Component = "TextBox",
                    Index = 5,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "TipoDeEstrutura",
                    Title = "Tipo de Estrutura",
                    Component = "DropDownList",
                    Index = 6,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                }
            };

            return listColumns;
        }
    }
}