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
        List<Secundario> s;
        public VistaIndice(Entidad e)
        {
            InitializeComponent();
            entidad = e;
            p = e.Prim;
            s = e.Sec;
            /*
            foreach(var a in e.Atrib)
            {
                switch (a.TipoIndice)
                {
                    case 2:
                        indice = a.Ind;
                        p = (Primario)indice;
                        break;
                    case 3:
                        indice = a.Ind;
                        if (s == null)
                             s = new List<Secundario>();
                        s.Add((Secundario)indice);
                        break;
                }
            }*/
            if(p!= null)
                carga();
            if(s!= null)
            {
                cargaSec();
            }
        }
        private void carga()
        {
            if (p == null) return;
            for(int i = 0; p.prim.Ind != null && i < p.prim.Longitud; i++)
            {
                dGVPrimario1.Rows.Add(p.prim.Ind[i].ToString(), p.prim.Ap[i].ToString());
            }
        }

        private void cargaSec( )
        {
            foreach(Secundario sec in s)
            {
                comboBox1.Items.Add(sec.Atributo.sNombre);
            }
            comboBox1.SelectedIndex = 0;
            muestra(0);
        }
        private void muestra(int j)
        {
            
            for (int i = 0; s[j].Principal != null && i < s[j].Principal.Capacidad; i++)
            {
                var e = s[j].Principal.Elementos[i];
                dgVSecundarios1.Rows.Add(e.Cb, e.Ap);
            }
        }

        public void actualiza()
        {
            if (p != null)
                carga();
            if(s != null)
                muestra(comboBox1.SelectedIndex);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = 0;
            dGVPrimario2.Rows.Clear();
            if ((int)dGVPrimario1.CurrentCell.Value == -1 ){ return; }
            if (!Int32.TryParse(dGVPrimario1.CurrentCell.Value.ToString(), out valor)) return;
            int i = dGVPrimario1.CurrentCell.RowIndex;
            int x = 0;
            var c = p.ElCajon(Convert.ToInt64(dGVPrimario1.CurrentCell.Value));
            for(int j = 0; c != null && j< c.Longitud; j++)
            {
                dGVPrimario2.Rows.Add(c.Cb[j], c.Ap[j]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            muestra(comboBox1.SelectedIndex);
        }

        private void dgVSecundarios1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = 0;
            dGVSecundarios2.Rows.Clear();
            if ((int)dGVSecundarios2.CurrentCell.Value == -1) { return; }
            if (!Int32.TryParse(dGVSecundarios2.CurrentCell.Value.ToString(), out valor)) return;
            int i = dGVSecundarios2.CurrentCell.RowIndex;
            int x = 0;
            Secundario c;
            /*//var c = p.ElCajon(Convert.ToInt64(dGVSecundarios2.CurrentCell.Value));
            for (int j = 0; c != null && j < c.Longitud; j++)
            {
                dGVSecundarios2.Rows.Add(c.Cb[j], c.Ap[j]);
            }*/
        }
    }
}
