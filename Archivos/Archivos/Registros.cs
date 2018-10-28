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
        public event Actualiza actualizado;
        public delegate void Actualiza();
        Entidad entidad;
        ArchivoRegistros archivo;
        public Registros(Entidad e)
        {
            InitializeComponent();
            
            entidad = e;
            archivo = new ArchivoRegistros(entidad.sNombre + ".dat", entidad);

            //define las columnas del datagried de los registros 
            dgVReg.Columns.Add("dir_Reg", "Direccion del registro");
            for (int i = 0; i < e.Atrib.Count; i++)
            {
                dgVReg.Columns.Add(e.Atrib[i].sNombre, e.Atrib[i].sNombre);
            }
            dgVReg.Columns.Add("dir_SigReg", "Direccion del siguiente registro");
            if (entidad.Registros != null)
            {
                foreach (List<string> reg in entidad.Registros)
                {
                    dgVReg.Rows.Add(reg.ToArray());
                }
            }
        }
        
        public void actualiza()
        {
            actualizado();
            dgVReg.Rows.Clear();
            foreach(List<string> reg in entidad.Registros)
            {
                dgVReg.Rows.Add(reg.ToArray()); 
            }
        }

        private void insertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaRegistros alta = new AltaRegistros(entidad, archivo);
            alta.actualizado += new AltaRegistros.Actualiza(actualiza);
            alta.ShowDialog(); 
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgVReg.CurrentCell.RowIndex == 0 && entidad.Atrib.Count > 0)
            {
                //primer reg y unico reg 
                entidad.Dir_Datos = -1;
            }
            else if(dgVReg.CurrentCell.RowIndex == 0)
            {
                //primer reg 
                entidad.Dir_Datos = Convert.ToInt64(entidad.Registros[dgVReg.CurrentCell.RowIndex][0]);
                
            }
        }
    }
}
