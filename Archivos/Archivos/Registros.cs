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
            archivo.sobreescribirArch();
        }

        private void insertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaRegistros alta = new AltaRegistros(entidad, archivo);
            alta.actualizado += new AltaRegistros.Actualiza(actualiza);
            alta.ShowDialog(); 
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgVReg.CurrentCell.RowIndex == entidad.Dir_Datos && dgVReg.CurrentCell.RowIndex == entidad.Registros.Count)
            {
                //primer reg y unico reg 
                entidad.Dir_Datos = -1;
                //entidad.Registros.RemoveAt(dgVReg.CurrentCell.RowIndex);
                archivo.elimina();
            }
            else if(dgVReg.CurrentCell.RowIndex == entidad.Dir_Datos)
            {
                //primer reg 
                var reg = entidad.Registros[dgVReg.CurrentCell.RowIndex];
                entidad.Dir_Datos = Convert.ToInt64(reg[entidad.Registros[0].Count - 1]);
                reg[entidad.Registros[0].Count - 1] = "-1";
                //entidad.Registros.RemoveAt(dgVReg.CurrentCell.RowIndex);
            }
            else if(entidad.Registros.Count > 2)
            {
                var regElim = entidad.Registros[dgVReg.CurrentCell.RowIndex]; //registro a eliminar 
                var regAnt = entidad.Registros[dgVReg.CurrentCell.RowIndex - 1]; //reg anterior al eliminado 
                //var regSig = entidad.Registros[dgVReg.CurrentCell.RowIndex + 1]; // reg siguiente al eliminado 
                regAnt[entidad.Registros[0].Count - 1] = regElim[entidad.Registros[0].Count - 1];
                regElim[entidad.Registros[0].Count - 1] = "-1";
               
            } 
            archivo.sobreescribirArch();
            entidad.Registros.RemoveAt(dgVReg.CurrentCell.RowIndex);
            actualiza();
        }
    }
}
