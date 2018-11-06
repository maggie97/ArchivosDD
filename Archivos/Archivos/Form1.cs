using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivos
{
    public partial class Form1 : Form
    {
        VistaRegistros VistReg;
        VistaIndice VistaIndice;
        Principal VistaDDD;
        public Form1()
        {
            InitializeComponent();
            VistaDDD = new Principal();
            panelContedor.Controls.Add(VistaDDD);
            VistaDDD.Show();
            //VistaIndice = new VistaIndice();
            //VistReg = new Registros();
        }

        private void lblDD_Click(object sender, EventArgs e)
        {
            VistaDDD.Visible = true;
        }

        private void lblIndices_Click(object sender, EventArgs e)
        {

        }

        private void lblReg_Click(object sender, EventArgs e)
        {

        }
    }
}
