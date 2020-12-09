using DynamicScreen.Business.HardCode.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Business.Interfaces
{
    public interface IMethodColumnService
    {
        IEnumerable<Topologia> ExecuteMethodColumnByConfiguration(int idConfiguration);
    }
}
