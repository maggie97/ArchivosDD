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
    public partial class VistaRegistros : Form
    {
        public event Actualiza actualizado;
        public delegate void Actualiza();
        Entidad entidad;
        ArchivoRegistros archivo;
        public VistaRegistros(Entidad e)
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
            actualizaindices();
        }
        public void actualizaindices()
        {
            if(entidad.Prim != null)
            {
                entidad.Prim.escribePrimario();
                var p = entidad.Prim;
                /*for (int i = 0, j = 0 ; i < p.prim.Longitud; i++)
                {
                    if(p.prim.Ap[i] != (long)-1)
                    {
                        p.escribePrimario_Cajon(p.prim.Ap[i], j);
                        j++;
                    }
                }*/
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
            if (entidad.Registros == null ||  entidad.Registros.Count == 0) return;
            var regElim = entidad.Registros[dgVReg.CurrentCell.RowIndex];
            if (dgVReg.CurrentCell.RowIndex == 0 && dgVReg.CurrentCell.RowIndex == entidad.Registros.Count)
            {
                //primer reg y unico reg 
                entidad.Dir_Datos = -1;
                archivo.elimina();
            }
            else if(dgVReg.CurrentCell.RowIndex == 0)
            {
                entidad.Dir_Datos = Convert.ToInt64(regElim[entidad.Registros[0].Count - 1]);
            }
            else if(entidad.Registros.Count > 1)
            {
                 //registro a eliminar 
                var regAnt = entidad.Registros[dgVReg.CurrentCell.RowIndex - 1]; //reg anterior al eliminado 
                regAnt[entidad.Registros[0].Count - 1] = regElim[entidad.Registros[0].Count - 1];
            }
            regElim[entidad.Registros[0].Count - 1] = "-1";
            //entidad.ordenaReg();
            entidad.Registros.Remove(regElim);
            archivo.sobreescribirArch();
            //entidad.Registros.RemoveAt(dgVReg.CurrentCell.RowIndex);
            archivo.leerArch(entidad.Dir_Datos);
            actualiza();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgVReg.CurrentCell.Value.ToString() != "")
            {
                int i = dgVReg.CurrentCell.RowIndex;
                var CurrentReg = entidad.Registros[i];
                AltaRegistros a = new AltaRegistros(entidad, archivo, CurrentReg);
                a.actualizado += new AltaRegistros.Actualiza(actualiza);
                a.ShowDialog();
            } 
        }

        private void indicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaIndice vInd = new VistaIndice(entidad);
            vInd.Show();
        }
    }
}
