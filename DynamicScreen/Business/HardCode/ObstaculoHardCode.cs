using DynamicScreen.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.HardCode
{
    public class ObstaculoHardCode
    {
        public ConfigurationModel CreateConfiguration(int index)
        {
            var newConfiguration = new ConfigurationModel
            {
                Name = "Obstaculo",
                Title = "Obstáculo",
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
                    Name = "IdDoObjeto",
                    Title = "Id do Objeto",
                    Component = "TextBox",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "ObstaculoCodigo",
                    Title = "Obstáculo Código",
                    Component = "TextBox",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "ObstaculPosicao",
                    Title = "Obstáculo Posição",
                    Component = "TextBox",
                    Index = 2,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "ObstaculoDistanciaParaInstalarPoste",
                    Title = "Obstáculo Distância para Instalar Poste",
                    Component = "TextBox",
                    Index = 3,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "ObstaculoObservacao",
                    Title = "Obstáculo Observação",
                    Component = "TextArea",
                    Index = 4,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                }
            };

            return listColumns;
        }
    }
}