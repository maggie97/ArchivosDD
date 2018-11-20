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
        private const string Nada = "-1";
        Indice indice;
        Primario p;
        Entidad entidad;
        public VistaIndice(Entidad e)
        {
            InitializeComponent();
            entidad = e;
            foreach(var a in e.Atrib)
            {
                switch (a.TipoIndice)
                {
                    case 2:
                        indice = a.Ind;
                        p = (Primario)indice;
                        break;
                }
            }
            carga();
        }
        private void carga()
        {
            if (p == null) return;
            for(int i = 0; p.prim.Ind != null && i < p.prim.Longitud; i++)
            {
                dGVPrimario1.Rows.Add(p.prim.Ind[i].ToString(), p.prim.Ap[i].ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dGVPrimario2.Rows.Clear();
            if (dGVPrimario1.CurrentCell.Value == null || 
                dGVPrimario1.CurrentCell.Value == Nada )
                { return; }

            int i = dGVPrimario1.CurrentCell.RowIndex;
            var caracter = p.prim.Ind[i];
            //MessageBox.Show("Celda de Caracter " + caracter);
            int x = 0;
            var c = p.SubCajones.Find(o => o.Cb[0][0] == caracter);
            c = p.ElCajon(Convert.ToInt64(dGVPrimario1.CurrentCell.Value));
            for(int j = 0; c != null && j< c.Longitud; j++)
            {
                dGVPrimario2.Rows.Add(c.Cb[j], c.Ap[j]);
            }
            
        }
    }
}
