using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Archivos
{
    public partial class AltaRegistros : Form
    {
        Entidad ent;
        String[] reg;
        List<List<string>> conjunto;
        int regAct = 0 ;
        int lenght = 0;
        Registros registros;
        //Archivo a;
        public AltaRegistros(Entidad entidad, Registros r)
        {
            InitializeComponent();
            lblNomEntidad.Text = entidad.sNombre; 
            ent = entidad;
            lenght = ent.Atrib.Count;
            reg = new string[lenght];

            registros = r;
            reg.Initialize();
            registros.Show();
        }

        public Entidad Ent { get => ent; /*set => ent = value;*/ }
        public List<string> UltimoReg { get => new List<string>(reg); /*set => reg = value;*/ }
        public List<List<string>> ConjuntoReg { get => conjunto; }

        private void AltaRegistros_Load(object sender, EventArgs e)
        {
            foreach(Atributo a in Ent.Atrib)
            {
                dgEntidad.Columns.Add("clm_" + a.sNombre, a.sNombre);
            }
        }

        private void dgEntidad_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEntidad.CurrentCell == null) return;
            lblDato.Text = dgEntidad.CurrentCell.Value.ToString();
            
            if ( regAct == dgEntidad.CurrentRow.Index)
            { 
                reg[dgEntidad.CurrentCell.ColumnIndex] = dgEntidad.CurrentCell.Value.ToString();
                //reg.Add(dgEntidad.CurrentCell.Value.ToString());
                //regAct = dgEntidad.CurrentRow.Index;
                regAct = (dgEntidad.CurrentCell.ColumnIndex == ent.Atrib.Count-1) ?  -1: regAct; 
                //if (dgEntidad.CurrentCell.ColumnIndex == ent.Atrib.Count) regAct = -1;
            }
            
        }

        private void dgEntidad_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            bool cont = true;

            for (int i = 0; i < lenght && cont; i++)
            {
                cont = ((reg[i] != null) && !(reg[i].Equals(""))) ? true : false;
            }
            if (cont == false)
            {
                MessageBox.Show("Faltan Campos por rellenar", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                cont = false;
            }
            else
            {
                regAct = dgEntidad.CurrentRow.Index;
                registros.Add(UltimoReg); //añade un nuevo registro
                reg = new string[lenght];
                dgEntidad.Rows.Clear();
            }
        }
    }
}
