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
    public partial class Registros : Form
    {
        Entidad entidad;
        public Registros(Entidad e)
        {
            InitializeComponent();
            entidad = e;
            //dgVReg.Columns.Add("dirReg", "Direccion del Registro");
            //define las columnas del datagried de los registros 
            dgVReg.Columns.Add("dir_Reg", "Direccion del registro");
            for (int i = 0; i < e.Atrib.Count; i++)
            {
                dgVReg.Columns.Add(e.Atrib[i].sNombre, e.Atrib[i].sNombre);
            }
            dgVReg.Columns.Add("dir_SigReg", "Direccion del siguiente registro");
        }

        internal void Add(List<string> reg)
        {
            //entidad.Registros.Add(reg);
            entidad.nuevoReg(reg);
            actualiza();
        }

        private void actualiza()
        {
            dgVReg.Rows.Clear();
            foreach(List<string> reg in entidad.Registros)
            {
                dgVReg.Rows.Add(reg.ToArray()); 
            }
        }

        private void insertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaRegistros alta = new AltaRegistros(entidad, this, 0);
            if(alta.ShowDialog() == DialogResult.OK)
            {
                actualiza();
            } 
        }
    }
}
