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
                Name = "ValorPadrao",
                Title = "Valores Padrões do Sistema",
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
                    Title = "Código",
                    Component = "TextBox",
                    Index = 0,
                    ReadOnly = true,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Chave",
                    Component = "TextBox",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Valor",
                    Component = "TextBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Descrição",
                    Component = "TextArea",
                    Index = 3,
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
                    Value = "1"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 1,
                    Value = "EstruturaSecundariaIdealDefault"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 2,
                    Value = "SI-1"
                },
                new ValuesDefault()
                {
                    RowPosition = 0,
                    ColumnPosition = 3,
                    Value = "Define qual deve ser a estrutura secundária ideal que o sistema deve retornar."
                },
                new ValuesDefault()
                {
                    RowPosition = 1,
                    ColumnPosition = 0,
                    Value = "2"
                },
                new ValuesDefault()
                {
                    RowPosition = 1,
                    ColumnPosition = 1,
                    Value = "DistanciaTrechoSecundario"
                },
                new ValuesDefault()
                {
                    RowPosition = 1,
                    ColumnPosition = 2,
                    Value = "2,0"
                },
                new ValuesDefault()
                {
                    RowPosition = 1,
                    ColumnPosition = 3,
                    Value = "Define qual deve ser a distância entre um trecho primário e secundário, para que o trecho secundário não seja desenhado por cima do primário."
                },
                new ValuesDefault()
                {
                    RowPosition = 2,
                    ColumnPosition = 0,
                    Value = "3"
                },
                new ValuesDefault()
                {
                    RowPosition = 2,
                    ColumnPosition = 1,
                    Value = "DistanciaMinimaEntrePostes"
                },
                new ValuesDefault()
                {
                    RowPosition = 2,
                    ColumnPosition = 2,
                    Value = "2"
                },
                new ValuesDefault()
                {
                    RowPosition = 2,
                    ColumnPosition = 3,
                    Value = "Define qual deve ser a distância mínima entre postes."
                },
                new ValuesDefault()
                {
                    RowPosition = 3,
                    ColumnPosition = 0,
                    Value = "4"
                },
                new ValuesDefault()
                {
                    RowPosition = 3,
                    ColumnPosition = 1,
                    Value = "EncurtamentoTrechoBT"
                },
                new ValuesDefault()
                {
                    RowPosition = 3,
                    ColumnPosition = 2,
                    Value = "1,75"
                },
                new ValuesDefault()
                {
                    RowPosition = 3,
                    ColumnPosition = 3,
                    Value = "Define o encurtamento (metros) de ambos os lados do trecho secundário em relação ao vão dos postes."
                }
            };
        }
    }
}