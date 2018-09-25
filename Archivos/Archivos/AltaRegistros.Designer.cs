namespace Archivos
{
    partial class AltaRegistros
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
            this.dgEntidad = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblNomEntidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEntidad
            // 
            this.dgEntidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntidad.Location = new System.Drawing.Point(37, 62);
            this.dgEntidad.Name = "dgEntidad";
            this.dgEntidad.Size = new System.Drawing.Size(658, 80);
            this.dgEntidad.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblNomEntidad
            // 
            this.lblNomEntidad.AutoSize = true;
            this.lblNomEntidad.Location = new System.Drawing.Point(354, 23);
            this.lblNomEntidad.Name = "lblNomEntidad";
            this.lblNomEntidad.Size = new System.Drawing.Size(55, 13);
            this.lblNomEntidad.TabIndex = 3;
            this.lblNomEntidad.Text = "<Entidad>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Registros de la Entidad ";
            // 
            // AltaRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNomEntidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgEntidad);
            this.Name = "AltaRegistros";
            this.Text = "Alta de Registro";
            this.Load += new System.EventHandler(this.AltaRegistros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEntidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEntidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblNomEntidad;
        private System.Windows.Forms.Label label1;
    }
}