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
                dataGridView1.Rows.Add(p.prim.Ind[i].ToString(), p.prim.Ap[i].ToString());
            }  
        }
    }
}
