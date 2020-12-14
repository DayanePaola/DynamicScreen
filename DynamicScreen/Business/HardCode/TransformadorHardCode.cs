using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class TransformadorHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Transformador",
                Title = "Transformadores",
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
                    Name = "TensaoDeOperacao",
                    Title = "Tensão de Operação",
                    Component = "TextBox",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "TipoDeFaseDeDestino",
                    Title = "Tipo de Fase de Destino",
                    Component = "DropDownList",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "FaseDeOrigem",
                    Title = "Fase de Origem",
                    Component = "TextBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Codigo",
                    Title = "Código",
                    Component = "TextBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Visao",
                    Title = "Visão",
                    Component = "TextBox",
                    Index = 4,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Descricao",
                    Title = "Descrição",
                    Component = "TextArea",
                    Index = 5,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Potencia",
                    Title = "Potência",
                    Component = "TextBox",
                    Index = 6,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "AtivoNoPDN",
                    Title = "Status: ",
                    Component = "RadioButton",
                    Index = 7,
                    ReadOnly = false,
                    Group = "status",
                    Method = "ObterRadioStatus"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "CodigoDaChave",
                    Title = "Código da Chave",
                    Component = "TextBox",
                    Index = 8,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "CodigoDoElo",
                    Title = "Código do Elo",
                    Component = "TextBox",
                    Index = 9,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                }
            };

            return listColumns;
        }
    }
}