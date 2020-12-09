using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Services
{
    public class MethodColumnService : IMethodColumnService
    {
        private readonly IColumnMethod _columnMethod;
        private readonly IConfigurationColumnRepository _configurationColumnRepository;

        public MethodColumnService(Context db)
        {
            _columnMethod = new ColumnMethodHardCode();
            _configurationColumnRepository = new ConfigurationColumnRepository(db);
        }

        public IEnumerable<Topologia> ExecuteMethodColumnByConfiguration(int idConfiguration)
        {
            var typeClassMethod = _columnMethod.GetType();
            ConstructorInfo constructor = typeClassMethod.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });

            var columnModel = GetColumn(idConfiguration);
            if (columnModel == null)
                return null;

            var methodInfo = typeClassMethod.GetMethod(columnModel.Method);

            var retorno = methodInfo.Invoke(classObject, null);

            return retorno as IEnumerable<Topologia>;
        }

        private ConfigurationColumnModel GetColumn(int idConfiguration)
        {
            var columnModel = _configurationColumnRepository.GetAll().FirstOrDefault(a => a.ConfigurationId == idConfiguration && !string.IsNullOrWhiteSpace(a.Method));

            return columnModel;
        }
    }
}
