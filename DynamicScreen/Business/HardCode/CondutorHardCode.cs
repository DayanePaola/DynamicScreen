using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class CondutorHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Condutor",
                Title = "Condutores",
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
                    ReadOnly = false,
                    Group = "Material A",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Condutor",
                    Component = "TextBox",
                    Index = 1,
                    ReadOnly = false,
                    Group = "Material A",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Código",
                    Component = "TextBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = "Material B",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Condutor",
                    Component = "TextBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = "Material B",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Código",
                    Component = "TextBox",
                    Index = 4,
                    ReadOnly = false,
                    Group = "Material C",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Condutor",
                    Component = "TextBox",
                    Index = 5,
                    ReadOnly = false,
                    Group = "Material C",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Código",
                    Component = "TextBox",
                    Index = 6,
                    ReadOnly = false,
                    Group = "Material Neutro",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Condutor",
                    Component = "TextBox",
                    Index = 7,
                    ReadOnly = false,
                    Group = "Material Neutro",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Limite do Vão",
                    Component = "TextBox",
                    Index = 8,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Limite do Tramo",
                    Component = "TextBox",
                    Index = 9,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Tipo da Fase",
                    Component = "DropDownList",
                    Index = 10,
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

        public IEnumerable<ConfigurationColumnFillModel> CreateFill(List<ConfigurationColumnModel> columns)
        {
            var listFill = new List<ConfigurationColumnFillModel>();

            columns = columns.Where(a => a.Group != null).ToList();

            for (int i = 0; i < columns.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listFill.Add(new ConfigurationColumnFillModel
                    {
                        ConfigurationColumnSourceId = columns[i].Id,
                        ConfigurationColumnDestinationId = columns[i + 1].Id,
                        DestinationIndex = columns[i + 1].Index
                    });
                }
            }

            return listFill;
        }
    }
}