namespace Archivos
{
    partial class VistaIndice
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
            this.dGVPrimario1 = new System.Windows.Forms.DataGridView();
            this.Primario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Primario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVPrimario2 = new System.Windows.Forms.DataGridView();
            this.PrimarioCajon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimarioCajon2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCIndices = new System.Windows.Forms.TabControl();
            this.tPPrimarios = new System.Windows.Forms.TabPage();
            this.tPSecundarios = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dGVSecundarios1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).BeginInit();
            this.tabCIndices.SuspendLayout();
            this.tPPrimarios.SuspendLayout();
            this.tPSecundarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSecundarios1)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVPrimario1
            // 
            this.dGVPrimario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPrimario1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Primario1,
            this.Primario2});
            this.dGVPrimario1.Location = new System.Drawing.Point(8, 74);
            this.dGVPrimario1.Name = "dGVPrimario1";
            this.dGVPrimario1.Size = new System.Drawing.Size(206, 389);
            this.dGVPrimario1.TabIndex = 0;
            this.dGVPrimario1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dGVPrimario1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Primario1
            // 
            this.Primario1.Frozen = true;
            this.Primario1.HeaderText = "Letra/Num";
            this.Primario1.Name = "Primario1";
            this.Primario1.ReadOnly = true;
            this.Primario1.Width = 70;
            // 
            // Primario2
            // 
            this.Primario2.Frozen = true;
            this.Primario2.HeaderText = "Apuntador";
            this.Primario2.Name = "Primario2";
            this.Primario2.ReadOnly = true;
            this.Primario2.Width = 60;
            // 
            // dGVPrimario2
            // 
            this.dGVPrimario2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPrimario2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrimarioCajon1,
            this.PrimarioCajon2});
            this.dGVPrimario2.Location = new System.Drawing.Point(220, 74);
            this.dGVPrimario2.Name = "dGVPrimario2";
            this.dGVPrimario2.Size = new System.Drawing.Size(202, 389);
            this.dGVPrimario2.TabIndex = 1;
            // 
            // PrimarioCajon1
            // 
            this.PrimarioCajon1.HeaderText = "CB";
            this.PrimarioCajon1.Name = "PrimarioCajon1";
            this.PrimarioCajon1.Width = 60;
            // 
            // PrimarioCajon2
            // 
            this.PrimarioCajon2.HeaderText = "Ap";
            this.PrimarioCajon2.Name = "PrimarioCajon2";
            this.PrimarioCajon2.ReadOnly = true;
            this.PrimarioCajon2.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primarios";
            // 
            // tabCIndices
            // 
            this.tabCIndices.Controls.Add(this.tPPrimarios);
            this.tabCIndices.Controls.Add(this.tPSecundarios);
            this.tabCIndices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCIndices.Location = new System.Drawing.Point(0, 0);
            this.tabCIndices.Multiline = true;
            this.tabCIndices.Name = "tabCIndices";
            this.tabCIndices.SelectedIndex = 0;
            this.tabCIndices.Size = new System.Drawing.Size(438, 504);
            this.tabCIndices.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCIndices.TabIndex = 5;
            // 
            // tPPrimarios
            // 
            this.tPPrimarios.BackColor = System.Drawing.SystemColors.Control;
            this.tPPrimarios.Controls.Add(this.dGVPrimario2);
            this.tPPrimarios.Controls.Add(this.label1);
            this.tPPrimarios.Controls.Add(this.dGVPrimario1);
            this.tPPrimarios.Location = new System.Drawing.Point(4, 22);
            this.tPPrimarios.Name = "tPPrimarios";
            this.tPPrimarios.Padding = new System.Windows.Forms.Padding(3);
            this.tPPrimarios.Size = new System.Drawing.Size(430, 478);
            this.tPPrimarios.TabIndex = 0;
            this.tPPrimarios.Text = "Indices Primarios";
            // 
            // tPSecundarios
            // 
            this.tPSecundarios.BackColor = System.Drawing.SystemColors.Control;
            this.tPSecundarios.Controls.Add(this.comboBox1);
            this.tPSecundarios.Controls.Add(this.label2);
            this.tPSecundarios.Controls.Add(this.dataGridView1);
            this.tPSecundarios.Controls.Add(this.dGVSecundarios1);
            this.tPSecundarios.Location = new System.Drawing.Point(4, 22);
            this.tPSecundarios.Name = "tPSecundarios";
            this.tPSecundarios.Padding = new System.Windows.Forms.Padding(3);
            this.tPSecundarios.Size = new System.Drawing.Size(430, 478);
            this.tPSecundarios.TabIndex = 1;
            this.tPSecundarios.Text = "Indices Secundarios";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.Location = new System.Drawing.Point(10, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(260, 407);
            this.dataGridView1.TabIndex = 3;
            // 
            // dGVSecundarios1
            // 
            this.dGVSecundarios1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSecundarios1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.dGVSecundarios1.Location = new System.Drawing.Point(276, 63);
            this.dGVSecundarios1.Name = "dGVSecundarios1";
            this.dGVSecundarios1.Size = new System.Drawing.Size(148, 407);
            this.dGVSecundarios1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 57);
            this.label2.TabIndex = 5;
            this.label2.Text = "Secundario de";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CB";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ap";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Apuntador al registro";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(276, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 32);
            this.comboBox1.TabIndex = 6;
            // 
            // VistaIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 504);
            this.Controls.Add(this.tabCIndices);
            this.Name = "VistaIndice";
            this.Text = "Indices";
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).EndInit();
            this.tabCIndices.ResumeLayout(false);
            this.tPPrimarios.ResumeLayout(false);
            this.tPPrimarios.PerformLayout();
            this.tPSecundarios.ResumeLayout(false);
            this.tPSecundarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSecundarios1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVPrimario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primario2;
        private System.Windows.Forms.DataGridView dGVPrimario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimarioCajon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimarioCajon2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabCIndices;
        private System.Windows.Forms.TabPage tPPrimarios;
        private System.Windows.Forms.TabPage tPSecundarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dGVSecundarios1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}