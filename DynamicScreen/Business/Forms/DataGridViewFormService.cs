using DynamicScreen.Dto;
using DynamicScreen.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data;

namespace DynamicScreen.Business.Forms
{
    public static class DataGridViewFormService
    {
        public static void GetComponent(List<ConfigurationColumnDto> columns, List<ConfigurationRowDto> rows, Control control)
        {

            var myNewGrid = new DataGridView();
            ((ISupportInitialize)(myNewGrid)).BeginInit();
            control.SuspendLayout();
            myNewGrid.Parent = control;
            myNewGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myNewGrid.Location = new Point(20, 350);
            myNewGrid.Name = "myNewGrid";
            myNewGrid.Size = new Size(750, 100);
            myNewGrid.TabIndex = 0;
            myNewGrid.ColumnHeadersVisible = true;
            myNewGrid.RowHeadersVisible = true;
            myNewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            myNewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ((ISupportInitialize)(myNewGrid)).EndInit();

            if (rows.Count > 0)
            {
                myNewGrid.DataSource = JsonConvert.DeserializeObject<DataTable>(RetornoJson(columns, rows));
            }
            else
            {
                foreach (var item in columns)
                {
                    myNewGrid.Columns.Add(item.Name, item.Title);
                }
            }

            control.ResumeLayout(false);
            myNewGrid.Visible = true;
        }

        private static string RetornoJson(List<ConfigurationColumnDto> columns, List<ConfigurationRowDto> rows)
        {
            var retornoJson = "[";

            for (int i = 0; i < rows.Count; i++)
            {
                retornoJson += "{";
                for (int j = 0; j < columns.Count; j++)
                {
                    if(j == columns.Count - 1)
                        retornoJson += $"\"{columns[j].Title}\": \"{rows[i].ConfigurationValue.FirstOrDefault(a => a.ConfigurationColumnId == columns[j].Id && a.ConfigurationRowId == rows[i].Id).Value}\"";
                    else
                        retornoJson += $"\"{columns[j].Title}\": \"{rows[i].ConfigurationValue.FirstOrDefault(a => a.ConfigurationColumnId == columns[j].Id && a.ConfigurationRowId == rows[i].Id).Value}\",";
                }

                if (i == rows.Count - 1)
                    retornoJson += "}";
                else
                    retornoJson += "},";
            }

            retornoJson += "]";

            return retornoJson;
        }
    }
}
