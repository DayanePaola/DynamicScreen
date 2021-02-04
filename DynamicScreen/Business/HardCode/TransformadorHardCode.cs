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
                    Group =  "TensaoDeOperacao",
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
                    Group = "TipoDeFaseDeDestino",
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
                    Group = "FaseDeOrigem",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Codigo",
                    Title = "Código",
                    Component = "SearchModal",
                    Index = 3,
                    ReadOnly = false,
                    Group = "Transformador",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Visao",
                    Title = "Visão",
                    Component = "TextBox",
                    Index = 5,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Descricao",
                    Title = "Descrição",
                    Component = "SearchModal",
                    Index = 4,
                    ReadOnly = false,
                    Group = "Transformador",
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
                    Group = "Potencia",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "AtivoNoPDN",
                    Title = "Status",
                    Component = "RadioButton",
                    Index = 7,
                    ReadOnly = false,
                    Group = "Status",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "CodigoDaChave",
                    Title = "Código da Chave",
                    Component = "TextBox",
                    Index = 8,
                    ReadOnly = false,
                    Group =  "CodigoDaChave",
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
                    Group = "CodigoDoElo",
                    Method = null
                }
            };

            return listColumns;
        }

        public IEnumerable<ConfigurationColumnFillModel> CreateFill(List<ConfigurationColumnModel> columns)
        {
            var listFill = new List<ConfigurationColumnFillModel>();

            var col = columns.GroupBy(g => g.Group)
                .Select(s => new { Group = s.Key, Columns = s.ToList() })
                .ToList();
            foreach (var item in col)
            {
                listFill.Add(new ConfigurationColumnFillModel
                {
                    ConfigurationColumnSourceId = item.Columns.FirstOrDefault().Id,
                    ConfigurationColumnDestinationId = item.Columns.LastOrDefault().Id
                });
            }
            return listFill;
        }
    }
}