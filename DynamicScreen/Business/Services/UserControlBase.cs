using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.Business.Services
{
    public abstract class UserControlBase<TControl> : UserControl where TControl : Control
    {
        protected virtual void CarregarAtributos(TControl control, List<ConfiugurationAtribute> atributos)
        {
            throw new NotImplementedException();
        }

        protected virtual TControl MontarControle(ConfigurationColumnDto columnDto)
        {
            throw new NotImplementedException();
        }
    }
}
