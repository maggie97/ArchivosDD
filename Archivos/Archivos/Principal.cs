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
            txtCab.Text = ddd.Cab.ToString();
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
                    dgAtributos.Rows.Clear();
                }
            }
        }

        private void nuevaEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevaEnt();
            txtCab.Text = ddd.Cab.ToString();
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
            if(newName != "")
            {
                while (newName.Length < 30) newName += ' ';
                eMod.NombreEntidad = newName.ToCharArray(0, 30);
            }
            ddd.ordena();
            ddd.sobreescribEntidad(eMod);
            ddd.sobreescribe_archivo();
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
                Entidad ent = ddd.nuevoAtributo(nuevo.Nombre_atributo, nuevo.Tipo, nuevo.Long, nuevo.Index);
                //Cabecera = atrb.nuevoAtrib(vEnt.List_entidades[nuevo.Index].Atrib.Last(), Convert.ToInt64(txtLong.Text));
                AtribEnt(ent);
                lblEntidad.Text = ent.sNombre;
                actualizaEnt();
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
        private void AtribEnt(string ent)
        {
            dgAtributos.Rows.Clear();
            Entidad e = ddd.Entidades.Find(o => o.sNombre.Contains(ent));
            foreach (Atributo a in e.Atrib)
            {
                dgAtributos.Rows.Add(a.sNombre, a.DirAtributo, a.Tipo, a.Longitud, a.TipoIndice, a.DirIndice, a.DirSig);
            }
        }
        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Principal_Paint(object sender, PaintEventArgs e)
        {
            Longitud();
        }
        private void Longitud()
        {
            if (ddd != null)
                txtLong.Text = ddd.Longitud.ToString();
        }

        private void dgEntidades_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Entidad ent = ddd.Entidades[e.RowIndex];
            AtribEnt(ent);
            lblEntidad.Text = ent.sNombre;
        }

        /// <summary>
        /// Modifica atributo al darle doble click en el datagrid de atributos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAtributos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Entidad ent = null;
            for (int i = 0; i < ddd.Entidades.Count && (ent = ddd.Entidades[i]).sNombre != lblEntidad.Text; i++) ;
            //Entidad eMod = ent;//list_entidades[e.RowIndex];
            if (ent != null)
            {
                Atributo aMod = ent.Atrib[e.RowIndex];
                //string newName = Microsoft.VisualBasic.Interaction.InputBox("Modifica la entidad : " + aMod.sNombre + " " + e.RowIndex, "Modificar", aMod.sNombre, -1, -1);
                using (NuevoAtributo n = new NuevoAtributo(aMod.sNombre, aMod.Tipo, aMod.Longitud, aMod.TipoIndice, ent))
                {
                    if(n.ShowDialog() == DialogResult.OK)
                    {
                        string nomb = n.Nombre_atributo;
                        if (nomb != "")
                        {
                            while (nomb.Length < 30) nomb += ' ';
                            aMod.Nombre = nomb.ToCharArray(0, 30);
                        }
                        aMod.Tipo = (n.Tipo==0)? 'C': 'E';
                        aMod.Longitud = n.Long;
                        ddd.sobreescribAtributo(aMod);
                        AtribEnt(ent);
                    }
                }
                    
                //ddd.sobreescribEntidad(ent);
                //actualizaEnt();

            }
        }

        private void eliminaAtributoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgAtributos.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    int i = dgAtributos.Rows.IndexOf(r);
                    ddd.eliminaAtributo(lblEntidad.Text, i);
                    actualizaEnt();
                    AtribEnt(lblEntidad.Text);
                }
            }
        }
    }
}

