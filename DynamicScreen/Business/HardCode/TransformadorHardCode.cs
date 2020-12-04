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
                    Title = "Ativo no PDN",
                    Component = "RadioButton",
                    Index = 7,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
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

        public IEnumerable<ConfigurationRowModel> CreateRows(int idConfiguration, int countRows)
        {
            var listRows = new List<ConfigurationRowModel>();

            for (int i = 0; i < countRows; i++)
            {
                var novaLinha = new ConfigurationRowModel
                {
                    ConfigurationId = idConfiguration,
                    Index = i
                };

                listRows.Add(novaLinha);
            }

            return listRows;
        }
    }
}