using AutoMapper;
using DynamicScreen.Business.Interfaces;
using DynamicScreen.Data;
using DynamicScreen.Data.Models;
using DynamicScreen.Data.Respository;
using DynamicScreen.Dto;
using DynamicScreen.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen
{
    public partial class Form1 : Form
    {
        public Form1(Context context)
        {
            InitializeComponent();
            AddTab();
        }

        void AddTab()
        {
            TabPage tbp = new TabPage();
            tbp.Name = "tb_cabo";
            tbp.Text = "Condutores";

            TextBox cnt = new TextBox();
            cnt.Name = "Cnt" + tbp.Name;
            cnt.Width = 50;
            tbp.Controls.Add(cnt);

            Button btn = new Button();
            btn.Name = "btn_search";
            btn.Text = "...";

            //var search = new SearchDto()
            //{
            //    LabelDescriptionName = "Descrição",
            //    LabelIdName = "Código",
            //    SearchItems = new List<BaseSearchDto>
            //    {
            //        new BaseSearchDto(){ Id = "15002640", Description= "CHAVE FUS. DSTB,TIPO C,15KV C/PF. PORCELANA" },
            //        new BaseSearchDto(){ Id = "20009773", Description= "SECCIONADORA DE FACA UNIP 15KV 630A" },
            //        new BaseSearchDto(){ Id = "20015404", Description= "Religador Aut.Monof.Simplif.25kV;1 relig" },
            //        new BaseSearchDto(){ Id = "20015405", Description= "Religador Aut.Monof.Simplif.25KV-3 RELIG" }
            //    }
            ////};

            //btn.Click += (object sender, EventArgs e) =>
            //{
            //    var form = new GenericSearch(search);
            //    form.Show();
            //};
            tbp.Controls.Add(btn);

        }

        private void ReturnClickMethod(object sender, EventArgs e)
        {
            SearchDto searchDto = (SearchDto)sender;
            //var form = new GenericSearch(searchDto, this);
            //form.Show();
        }
    }
}
