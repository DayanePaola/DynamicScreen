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
                    Name = "Topologia",
                    Title = "Topologia",
                    Component = "DropDownList",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = "ObterListaDeTopologias"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Tensao",
                    Title = "Tensão",
                    Component = "DropDownList",
                    Index = 1,
                    ReadOnly = false,
                    Group = "Tensao",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Limite",
                    Title = "Limite",
                    Component = "DropDownList",
                    Index = 2,
                    ReadOnly = false,
                    Group = "Limite",
                    Method = null
                }
            };

            return listColumns;
        }
    }
}