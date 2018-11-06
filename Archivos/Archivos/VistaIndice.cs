using Archivos.Controladores;
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
    public partial class VistaIndice : Form
    {
        Indice indice;
        Primario p;
        public VistaIndice(Primario ind)
        {
            InitializeComponent();
            p = ind;
        }

        private void carga()
        {
            //Primario.indice; 
            foreach(var fila in p.prim.Ind )
            {
                dataGridView1.Rows.Add(fila);
            }
        }
    }
}
