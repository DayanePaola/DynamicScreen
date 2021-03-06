﻿using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicScreen.Business.HardCode
{
    public class InitialDataBase
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IConfigurationColumnRepository _configurationColumnRepository;
        private readonly IConfigurationColumnFillRepository _configurationColumnFillRepository;
        private readonly IConfigurationRowRepository _configurationRowRepository;
        private readonly IConfigurationValueRepository _configurationValueRepository;
        private readonly ParaRaiosHardCode ParaRaiosHardCode;
        private readonly ChaveHardCode ChaveHardCode;
        private readonly CondutorHardCode CondutorHardCode;
        private readonly EstruturaSecundariaHardCode EstruturaSecundariaHardCode;
        private readonly ObstaculoHardCode ObstaculoHardCode;
        private readonly TransformadorHardCode TransformadorHardCode;
        private readonly TopologiaHardCode TopologiaHardCode;
        private readonly ValorPadraoHardCode ValorPadraoHardCode;
        public InitialDataBase(Context context)
        {
            _configurationRepository = new ConfigurationRepository(context);
            _configurationRowRepository = new ConfigurationRowRepository(context);
            _configurationValueRepository = new ConfigurationValueRepository(context);
            _configurationColumnRepository = new ConfigurationColumnRepository(context);
            _configurationColumnFillRepository = new ConfigurationColumnFillRepository(context);
            ParaRaiosHardCode = new ParaRaiosHardCode();
            ChaveHardCode = new ChaveHardCode();
            CondutorHardCode = new CondutorHardCode();
            EstruturaSecundariaHardCode = new EstruturaSecundariaHardCode();
            ObstaculoHardCode = new ObstaculoHardCode();
            TransformadorHardCode = new TransformadorHardCode();
            TopologiaHardCode = new TopologiaHardCode();
            ValorPadraoHardCode = new ValorPadraoHardCode();

            ClearDataBase();

            if (_configurationRepository.GetAll().Count() == 0)
            {
                var listConfiguration = CreateConfiguration();
                Console.WriteLine($"Quantidade de configurações criadas: {listConfiguration.Count()}");
                
                var listConfigurationColumn = CreateConfigurationColumn();
                Console.WriteLine($"Quantidade de colunas criadas: {listConfigurationColumn.Count()}");
                
                var listConfigurationColumnFill = CreateConfigurationColumnFill();
                Console.WriteLine($"Quantidade de preenchimentos criados: {listConfigurationColumnFill.Count()}");
                
                var listConfigurationRow = CreateConfigurationRows();
                Console.WriteLine($"Quantidade de linhas criadas: {listConfigurationRow.Count()}");
                
                var listConfigurationValue = CreateConfigurationValues();
                Console.WriteLine($"Quantidade de valores criadas: {listConfigurationValue.Count()}");
            }
        }

        private IEnumerable<ConfigurationModel> CreateConfiguration()
        {
            var listConfiguration = new List<ConfigurationModel>()
            {
                ParaRaiosHardCode.CreateConfiguration(0),
                ChaveHardCode.CreateConfiguration(1),
                CondutorHardCode.CreateConfiguration(2),
                EstruturaSecundariaHardCode.CreateConfiguration(3),
                ObstaculoHardCode.CreateConfiguration(4),
                TransformadorHardCode.CreateConfiguration(5),
                TopologiaHardCode.CreateConfiguration(5),
                ValorPadraoHardCode.CreateConfiguration(7)
            };

            _configurationRepository.InsertRange(listConfiguration);

            return _configurationRepository.GetAll();
        }

        private IEnumerable<ConfigurationColumnModel> CreateConfigurationColumn()
        {
            var listConfiguration = _configurationRepository.GetAll();
            var listColumns = new List<ConfigurationColumnModel>();
            listColumns.AddRange(ParaRaiosHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Pararaios")).Id));
            listColumns.AddRange(ChaveHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Chave")).Id));
            listColumns.AddRange(CondutorHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Condutor")).Id));
            listColumns.AddRange(EstruturaSecundariaHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("EstruturaSecundaria")).Id));
            listColumns.AddRange(ObstaculoHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Obstaculo")).Id));
            listColumns.AddRange(TransformadorHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Transformador")).Id));
            listColumns.AddRange(TopologiaHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("Topologia")).Id));
            listColumns.AddRange(ValorPadraoHardCode.CreateColumns(listConfiguration.FirstOrDefault(a => a.Name.Equals("TelaGeral")).Id));

            _configurationColumnRepository.InsertRange(listColumns);

            return _configurationColumnRepository.GetAll();
        }

        private IEnumerable<ConfigurationColumnFillModel> CreateConfigurationColumnFill()
        {
            var listConfiguration = _configurationRepository.GetAll();
            var listFill = new List<ConfigurationColumnFillModel>();
            listFill.AddRange(CondutorHardCode.CreateFill(_configurationRepository.GetConfigurationColumnRows(listConfiguration.FirstOrDefault(a => a.Name.Equals("Condutor")).Id).ConfigurationColumn.ToList()));
            listFill.AddRange(TransformadorHardCode.CreateFill(_configurationRepository.GetConfigurationColumnRows(listConfiguration.FirstOrDefault(a => a.Name.Equals("Transformador")).Id).ConfigurationColumn.ToList()));
            listFill.AddRange(ChaveHardCode.CreateFill(_configurationRepository.GetConfigurationColumnRows(listConfiguration.FirstOrDefault(a => a.Name.Equals("Chave")).Id).ConfigurationColumn.ToList()));

            _configurationColumnFillRepository.InsertRange(listFill);

            return _configurationColumnFillRepository.GetAll();
        }

        private IEnumerable<ConfigurationRowModel> CreateConfigurationRows()
        {
            var listConfiguration = _configurationRepository.GetAll();
            var listRows = new List<ConfigurationRowModel>();
            
            listRows.AddRange(ValorPadraoHardCode.CreateRows(listConfiguration.FirstOrDefault(a => a.Name.Equals("TelaGeral")).Id, 1));

            _configurationRowRepository.InsertRange(listRows);

            return _configurationRowRepository.GetAll();
        }

        private IEnumerable<ConfigurationValueModel> CreateConfigurationValues()
        {
            var listConfiguration = _configurationRepository.GetAll();
            var configuration = _configurationRepository.GetConfigurationColumnRows(listConfiguration.FirstOrDefault(a => a.Name.Equals("TelaGeral")).Id);

            var listValues = new List<ConfigurationValueModel>();
            listValues.AddRange(ValorPadraoHardCode.CreateValues(configuration.ConfigurationRow, configuration.ConfigurationColumn));

            _configurationValueRepository.InsertRange(listValues);

            return _configurationValueRepository.GetAll();
        }

        private void ClearDataBase()
        {
            var listaValue = _configurationValueRepository.GetAll();
            foreach (var item in listaValue)
            {
                _configurationValueRepository.Remove(item.Id);
            }

            var listaPreenchimento = _configurationColumnFillRepository.GetAll();
            foreach (var item in listaPreenchimento)
            {
                _configurationColumnFillRepository.Remove(item.Id);
            }

            var listaLinhas = _configurationRowRepository.GetAll();
            foreach (var item in listaLinhas)
            {
                _configurationRowRepository.Remove(item.Id);
            }

            var listaColunas = _configurationColumnRepository.GetAll();
            foreach (var item in listaColunas)
            {
                _configurationColumnRepository.Remove(item.Id);
            }

            var listaConfiguracoes = _configurationRepository.GetAll();
            foreach (var item in listaConfiguracoes)
            {
                _configurationRepository.Remove(item.Id);
            }
        }
    }
}
