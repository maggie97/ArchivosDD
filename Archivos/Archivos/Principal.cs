using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Archivos
{
    public partial class Principal : Form
    {
        DDD ddd;
        //List<Archivo> datos;
        public Principal()
        {
            InitializeComponent();
            MaximizeBox = true;
            pEntidades.ClientSize = new Size(pEntidades.Size.Width, ClientSize.Height/2) ;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoDD();
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirDD();
        }

        private void nuevoDD()
        {
            using (nuevoArchivo n = new nuevoArchivo())
            {
                if (n.ShowDialog() == DialogResult.OK)
                {
                    ddd = new DDD(n.name, ".dd", n.direccion);
                    using (BinaryWriter writer = new BinaryWriter(File.Open(ddd.Fullname, FileMode.Create)))
                    {
                        writer.Write(ddd.Cab);
                        txtCab.Text = ddd.Cab.ToString();
                    }
                }
            }
        }
        private void abrirDD()
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    ddd = new DDD(open.FileName);
                    ddd.lee();
                    //Actualiza DataGrid
                    actualizaEnt();
                }
            }
        }

        private void nuevaEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevaEnt();
        }

        private void nuevaEnt()
        {
            NuevaEntidad nueva_ent = new NuevaEntidad();
            if (nueva_ent.ShowDialog() == DialogResult.OK)
            {
                ddd.nuevaEntidad(nueva_ent.Nombre_Entidad.ToString());
                actualizaEnt();
            }
        }
        private void actualizaEnt()
        {
            dgEntidades.Rows.Clear();
            
            foreach(Entidad e in ddd.RefreshGrid())//ddd.Entidades)
            {
                dgEntidades.Rows.Add(e.sNombre, e.Dir_Entidad, e.Dir_Atributos, e.Dir_Datos, e.Dir_sig);
            }
        }

        private void dgEntidades_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Entidad eMod = ddd.Entidades[e.RowIndex];//list_entidades[e.RowIndex];
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Modifica la entidad : " + eMod.sNombre + " " + e.RowIndex, "Modificar", eMod.sNombre, -1, -1);
            eMod.NombreEntidad = (newName == "" ) ? eMod.NombreEntidad : newName.ToCharArray(0, 30);
            ddd.sobreescribEntidades();
            actualizaEnt();
        }

        private void eliminaEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgEntidades.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    int i = dgEntidades.Rows.IndexOf(r);
                    ddd.eliminaEntidad(i);
                    actualizaEnt();
                }
            }
        }

        private void nuevoAtributoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoAtributo nuevo = new NuevoAtributo(ddd.EntidadesOrden);
            if (nuevo.ShowDialog() == DialogResult.OK)
            {
                
                //Cabecera = atrb.nuevoAtrib(vEnt.List_entidades[nuevo.Index].Atrib.Last(), Convert.ToInt64(txtLong.Text));
                AtribEnt(ddd.nuevoAtributo(nuevo.Nombre_atributo, nuevo.Tipo, nuevo.Long, nuevo.Index));
            }
        }
        private void AtribEnt(Entidad e)
        {
            dgAtributos.Rows.Clear();

            foreach (Atributo a in e.Atrib)//ddd.Entidades)
            {
                dgAtributos.Rows.Add(a.sNombre, a.DirAtributo, a.Tipo, a.Longitud, a.TipoIndice, a.DirIndice, a.DirSig);
            }
        }
    }
}

