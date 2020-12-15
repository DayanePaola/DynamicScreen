using DynamicScreen.Business.HardCode.Methods;
using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IColumnMethod
    {
        IEnumerable<ValueDto> ObterListaDeTopologias();
        IEnumerable<ValueDto> ObterListaDeChaves();
        IEnumerable<ValueDto> ObterListaDeTransformadores();
        IEnumerable<ValueDto> ObterListaDeCondutores();
    }
}
