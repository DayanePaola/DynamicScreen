using DynamicScreen.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicScreen.View
{
    public partial class GenericSearch : Form
    {
        public List<ValueDto> BaseListSearch { get; set; }
        public SearchDto SearchDtoBase { get; set; }
        public GenericSearch(SearchDto searchDto)
        {
            InitializeComponent();
            BaseListSearch = searchDto.SearchItems;
            SearchDtoBase = searchDto;
            SetLabelsName(searchDto);
            BindingGrid(searchDto);
        }

        private void SetLabelsName(SearchDto searchDto)
        {
            lbl_id.Text = searchDto.LabelIdName;
            lbl_description.Text = searchDto.LabelDescriptionName;
        }

        private void BindingGrid(SearchDto searchDto)
        {
            var bindingSource = new BindingSource();
            dgv_search.AutoGenerateColumns = true;
            dgv_search.DataSource = searchDto.SearchItems;
            dgv_search.AutoResizeColumns();
            dgv_search.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_search.AutoSize = true;
            this.AutoSize = true;
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            dgv_search.DataSource = BaseListSearch.Where(w=> (string.IsNullOrWhiteSpace(txt_id.Text) 
                                                             || w.Id.ToUpper().Contains(txt_id.Text.ToUpper())) 
                                                          && (string.IsNullOrWhiteSpace(txt_description.Text) 
                                                             ||  w.Value.ToUpper().Contains(txt_description.Text.ToUpper()))).ToList();
        }

        private void dgv_search_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            SearchDtoBase = null;
            this.Close();
        }
        private void btn_Selecionar_Click(object sender, EventArgs e)
        {
            var teste = dgv_search.SelectedRows;
            var teste1 = teste[1].DataBoundItem.ToString();
            //SearchDtoBase.SelectItem = 
            this.Close();
        }
    }
}