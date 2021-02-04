using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.Business.Services
{
    public class UC_TextBox : UserControlBase<TextBox>
    {
        protected override TextBox MontarControle(ConfigurationColumnDto columnDto)
        {
            throw new NotImplementedException();
        }

        protected override void CarregarAtributos(TextBox control, List<ConfiugurationAtribute> atributos)
        {
            throw new NotImplementedException();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }
    }
}
