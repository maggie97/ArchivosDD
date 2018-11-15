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
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.SecundarioCajon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Secundario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Secundario2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVPrimario1
            // 
            this.dGVPrimario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPrimario1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Primario1,
            this.Primario2});
            this.dGVPrimario1.Location = new System.Drawing.Point(31, 71);
            this.dGVPrimario1.Name = "dGVPrimario1";
            this.dGVPrimario1.Size = new System.Drawing.Size(176, 326);
            this.dGVPrimario1.TabIndex = 0;
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
            this.dGVPrimario2.Location = new System.Drawing.Point(224, 71);
            this.dGVPrimario2.Name = "dGVPrimario2";
            this.dGVPrimario2.Size = new System.Drawing.Size(179, 326);
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
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecundarioCajon1});
            this.dataGridView3.Location = new System.Drawing.Point(657, 71);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(156, 326);
            this.dataGridView3.TabIndex = 3;
            // 
            // SecundarioCajon1
            // 
            this.SecundarioCajon1.HeaderText = "Ap";
            this.SecundarioCajon1.Name = "SecundarioCajon1";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Secundario1,
            this.Secundario2});
            this.dataGridView4.Location = new System.Drawing.Point(439, 71);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(192, 326);
            this.dataGridView4.TabIndex = 2;
            // 
            // Secundario1
            // 
            this.Secundario1.Frozen = true;
            this.Secundario1.HeaderText = "CB";
            this.Secundario1.Name = "Secundario1";
            this.Secundario1.ReadOnly = true;
            this.Secundario1.Width = 70;
            // 
            // Secundario2
            // 
            this.Secundario2.Frozen = true;
            this.Secundario2.HeaderText = "Ap";
            this.Secundario2.Name = "Secundario2";
            this.Secundario2.ReadOnly = true;
            this.Secundario2.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(520, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 57);
            this.label2.TabIndex = 5;
            this.label2.Text = "Secundarios";
            // 
            // VistaIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 423);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dGVPrimario2);
            this.Controls.Add(this.dGVPrimario1);
            this.Name = "VistaIndice";
            this.Text = "Indices";
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVPrimario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primario2;
        private System.Windows.Forms.DataGridView dGVPrimario2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimarioCajon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimarioCajon2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecundarioCajon1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Secundario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Secundario2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}