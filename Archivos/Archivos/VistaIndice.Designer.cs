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
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVPrimario1
            // 
            this.dGVPrimario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPrimario1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Primario1,
            this.Primario2});
            this.dGVPrimario1.Location = new System.Drawing.Point(12, 71);
            this.dGVPrimario1.Name = "dGVPrimario1";
            this.dGVPrimario1.Size = new System.Drawing.Size(206, 421);
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
            this.dGVPrimario2.Location = new System.Drawing.Point(224, 71);
            this.dGVPrimario2.Name = "dGVPrimario2";
            this.dGVPrimario2.Size = new System.Drawing.Size(202, 421);
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
            this.label1.Location = new System.Drawing.Point(119, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primarios";
            // 
            // VistaIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGVPrimario2);
            this.Controls.Add(this.dGVPrimario1);
            this.Name = "VistaIndice";
            this.Text = "Indices";
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPrimario2)).EndInit();
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
        private System.Windows.Forms.Label label1;
    }
}