using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class ChaveHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Chave",
                Title = "Chaves",
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
                    Group = "Material Chave",
                    Method = "ObterListaDeChaves"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Fase",
                    Title = "Fase",
                    Component = "CheckBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = "Fase",
                    Method = "ObterFase"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Descricao",
                    Title = "Descrição",
                    Component = "SearchModal",
                    Index = 1,
                    ReadOnly = true,
                    Group = "Material Chave",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "AtivoNoPDN",
                    Title = "Status",
                    Component = "RadioButton",
                    Index = 3,
                    ReadOnly = false,
                    Group = "Status",
                    Method = "ObterRadioStatus"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Tensao",
                    Title = "Tensão",
                    Component = "DropDownList",
                    Index = 4,
                    ReadOnly = false,
                    Group = "Tensão",
                    Method = "ObterTensao"
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Quantidade",
                    Title = "Quantidade",
                    Component = "TextBox",
                    Index = 5,
                    ReadOnly = false,
                    Group = "Quantidade",
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "PermitidaEmSE",
                    Title = "Permitida em SE",
                    Component = "RadioButton",
                    Index = 6,
                    ReadOnly = false,
                    Group = "Subestação",
                    Method = "ObterRadioSimNão"
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