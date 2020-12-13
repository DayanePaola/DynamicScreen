using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Services
{
    public class MethodColumnService
    {
        private readonly IColumnMethod _columnMethod;

        public MethodColumnService()
        {
            _columnMethod = new ColumnMethodHardCode();
        }

        public IEnumerable<ValueDto> ExecuteMethod(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
                return new List<ValueDto>();

            var typeClassMethod = _columnMethod.GetType();
            ConstructorInfo constructor = typeClassMethod.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });

            var methodInfo = typeClassMethod.GetMethod(method);

            var retorno = methodInfo.Invoke(classObject, null);

            return retorno as IEnumerable<ValueDto>;
        }

        //public IEnumerable<Topologia> ExecuteMethodColumnByConfiguration(int idConfiguration)
        //{
        //    var typeClassMethod = _columnMethod.GetType();
        //    ConstructorInfo constructor = typeClassMethod.GetConstructor(Type.EmptyTypes);
        //    object classObject = constructor.Invoke(new object[] { });

        //    var columnModel = GetColumn(idConfiguration);
        //    if (columnModel == null)
        //        return null;

        //    var methodInfo = typeClassMethod.GetMethod(columnModel.Method);

        //    var retorno = methodInfo.Invoke(classObject, null);

        //    return retorno as IEnumerable<Topologia>;
        //}

        //private ConfigurationColumnModel GetColumn(int idConfiguration)
        //{
        //    var columnModel = _configurationColumnRepository.GetAll().FirstOrDefault(a => a.ConfigurationId == idConfiguration && !string.IsNullOrWhiteSpace(a.Method));

        //    return columnModel;
        //}
    }
}
