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
                    Name = "Codigo",
                    Title = "Código",
                    Component = "SearchModal",
                    Index = 0,
                    ReadOnly = false,
                    Group = "Material A",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Condutor",
                    Title = "Condutor",
                    Component = "SearchModal",
                    Index = 1,
                    ReadOnly = false,
                    Group = "Material A",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Codigo",
                    Title = "Código",
                    Component = "SearchModal",
                    Index = 2,
                    ReadOnly = false,
                    Group = "Material B",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Condutor",
                    Title = "Condutor",
                    Component = "SearchModal",
                    Index = 3,
                    ReadOnly = false,
                    Group = "Material B",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Codigo",
                    Title = "Código",
                    Component = "SearchModal",
                    Index = 4,
                    ReadOnly = false,
                    Group = "Material C",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Condutor",
                    Title = "Condutor",
                    Component = "SearchModal",
                    Index = 5,
                    ReadOnly = false,
                    Group = "Material C",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Codigo",
                    Title = "Código",
                    Component = "SearchModal",
                    Index = 6,
                    ReadOnly = false,
                    Group = "Material Neutro",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Condutor",
                    Title = "Condutor",
                    Component = "SearchModal",
                    Index = 7,
                    ReadOnly = false,
                    Group = "Material Neutro",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "LimiteDoVao",
                    Title = "Limite do Vão",
                    Component = "TextBox",
                    Index = 8,
                    ReadOnly = false,
                    Group = "Limite do Vão",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "LimiteDoTramo",
                    Title = "Limite do Tramo",
                    Component = "TextBox",
                    Index = 9,
                    ReadOnly = false,
                    Group = "Limite do Tramo",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "TipoDaFase",
                    Title = "Tipo da Fase",
                    Component = "DropDownList",
                    Index = 10,
                    ReadOnly = false,
                    Group = "Tipo da Fase",
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