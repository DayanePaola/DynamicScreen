﻿using DynamicScreen.Data.Models;
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
                    Component = "TextBox",
                    Index = 0,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Fase",
                    Title = "Fase",
                    Component = "DropDownList",
                    Index = 1,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Descricao",
                    Title = "Descrição",
                    Component = "TextArea",
                    Index = 2,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "AtivoNoPDN",
                    Title = "Ativo no PDN",
                    Component = "RadioButton",
                    Index = 3,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Tensao",
                    Title = "Tensão",
                    Component = "DropDownList",
                    Index = 4,
                    ReadOnly = false,
                    Group = null,
                    Method = null
                },
                new ConfigurationColumnModel
                {
                    ConfigurationId = idConfiguration,
                    Name = "Quantidade",
                    Title = "Quantidade",
                    Component = "TextBox",
                    Index = 5,
                    ReadOnly = false,
                    Group = null,
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
                    Group = null,
                    Method = null
                }
            };

            return listColumns;
        }
    }
}