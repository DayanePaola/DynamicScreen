using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class ParaRaiosHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Pararaios",
                Title = "Para-raios",
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
                    Title = "Topologia",
                    Component = "DropDownList",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Tensão",
                    Component = "DropDownList",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Title = "Limite",
                    Component = "DropDownList",
                    Index = 2,
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