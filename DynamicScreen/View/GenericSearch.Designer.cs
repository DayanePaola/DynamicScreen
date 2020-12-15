using System.Windows.Forms;
namespace DynamicScreen.View
{
    partial class GenericSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_search = new System.Windows.Forms.DataGridView();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_search)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_search
            // 
            this.dgv_search.AllowUserToAddRows = false;
            this.dgv_search.AllowUserToDeleteRows = false;
            this.dgv_search.AllowUserToOrderColumns = true;
            this.dgv_search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_search.Location = new System.Drawing.Point(12, 60);
            this.dgv_search.Name = "dgv_search";
            this.dgv_search.ReadOnly = true;
            this.dgv_search.Size = new System.Drawing.Size(394, 351);
            this.dgv_search.TabIndex = 0;
            this.dgv_search.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_search_MouseDoubleClick);
            // 
            // btn_search
            // 
            this.btn_search.Image = global::DynamicScreen.Properties.Resources.Pesquisar16x16;
            this.btn_search.Location = new System.Drawing.Point(383, 31);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(23, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(13, 32);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(101, 20);
            this.txt_id.TabIndex = 2;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(120, 32);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(257, 20);
            this.txt_description.TabIndex = 3;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(12, 17);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(40, 13);
            this.lbl_id.TabIndex = 4;
            this.lbl_id.Text = "Código";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(120, 17);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(55, 13);
            this.lbl_description.TabIndex = 5;
            this.lbl_description.Text = "Descrição";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Selecionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 417);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // GenericSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dgv_search);
            this.Name = "GenericSearch";
            this.Text = "GenericSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_search;
        private Button btn_search;
        private TextBox txt_id;
        private TextBox txt_description;
        private Label lbl_id;
        private Label lbl_description;
        private Button button1;
        private Button button2;
    }
}