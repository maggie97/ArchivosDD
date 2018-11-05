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
        Registros VistReg;
        Indices VistaIndice;
        Principal VistaDDD;
        public Form1()
        {
            InitializeComponent();
            VistaDDD = new Principal();
            VistaIndice = new Indices();
            //VistReg = new Registros();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
