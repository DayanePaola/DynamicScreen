using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class ValorPadraoHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "TelaGeral",
                Title = "Valores Gerais do Sistema",
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
                    Name = "EstruturaSecundariaIdealDefault",
                    Title = "Estrutura ideal de BT",
                    Component = "TextBox",
                    Index = 0,
                    ReadOnly = true,
                    Group = "EstruturaSecundariaIdealDefault",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "DistanciaTrechoSecundario",
                    Title = "Distância máxima de trecho secundário",
                    Component = "TextBox",
                    Index = 1,
                    ReadOnly = false,
                    Group = "DistanciaTrechoSecundario",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "DistanciaMinimaEntrePostes",
                    Title = "Distância mínima entre postes",
                    Component = "TextBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = "DistanciaMinimaEntrePostes",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "EncurtamentoTrechoBT",
                    Title = "Encurtamento de trecho de BT",
                    Component = "TextBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = "EncurtamentoTrechoBT",
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

        public IEnumerable<ConfigurationValueModel> CreateValues(ICollection<ConfigurationRowModel> rows, ICollection<ConfigurationColumnModel> columns)
        {
            var listValues = new List<ConfigurationValueModel>();
            var valuesDefault = GetListValues();

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    listValues.Add(new ConfigurationValueModel()
                    {
                        ConfigurationRowId = rows.ToList()[i].Id,
                        ConfigurationColumnId = columns.ToList()[j].Id,
                        Value = valuesDefault.FirstOrDefault(a => a.RowPosition == i && a.ColumnPosition == j).Value
                    });
                }
            }

            return listValues;
        }

        private List<ValuesDefault> GetListValues()
        {
            return new List<ValuesDefault>
            {
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 0,
                    Value = "SI-1"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 1,
                    Value = "2,0"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 2,
                    Value = "2"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 3,
                    Value = "1,75"
                }
            };
        }
    }
}