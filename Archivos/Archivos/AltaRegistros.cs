using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Archivos
{
    public partial class AltaRegistros : Form
    {
        public event Actualiza actualizado;
        public delegate void Actualiza();

        Entidad ent;
        String[] reg;

        //List<string> reg;
        //List<List<string>> conjunto;
        int regAct = 0 ;
        int lenght = 0;
        long DirReg;
        //Registros registros;
        //Archivo a;
        public AltaRegistros(Entidad entidad, Archivo r)
        {
            InitializeComponent();
            lblNomEntidad.Text = entidad.sNombre; 
            ent = entidad;
            lenght = ent.Atrib.Count;
            reg =  new string[lenght + 2];
            DirReg = 0;


            foreach (Atributo a in Ent.Atrib)
            {
                dgEntidad.Columns.Add("clm_" + a.sNombre, a.sNombre);
            }
            
        }

        public Entidad Ent { get => ent; /*set => ent = value;*/ }
        public List<string> UltimoReg { get => new List<string>(reg); /*set => reg = value;*/ }
        private int longitud
        {
            get
            {
                int longReg = 0;
                foreach (Atributo a in ent.Atrib)
                {
                    longReg += a.Longitud;
                }

                return longReg;
            }
        }

        //public List<List<string>> ConjuntoReg { get => conjunto; }

        private void AltaRegistros_Load(object sender, EventArgs e)

        {
            //dgEntidad.Columns.Add("clm_DirReg", "Direccion del Registro");
            for (int i = 1; i < lenght; i++)
            {
                for (int j = 0; j < ent.Atrib[i].Longitud; j++)
                    switch (ent.Atrib[i].Tipo)
                    {
                        case 'C':
                            reg[i] += " ";
                            break;
                        case 'E':
                            reg[i] += "0";
                            break;
                    }
            }
            dgEntidad.Rows.Add();
            //dgEntidad.CurrentCell.Value = reg[0];
            //dgEntidad.Columns.Add("clm_DirSig", "Direccion del Sig Reg");
        }

        private void dgEntidad_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEntidad.CurrentCell == null) return;
            lblDato.Text = dgEntidad.CurrentCell.Value.ToString(); 
            if ( regAct == dgEntidad.CurrentRow.Index)
            { 
                reg[dgEntidad.CurrentCell.ColumnIndex+1] = dgEntidad.CurrentCell.Value.ToString();
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

            for (int i = 1; i < lenght && cont; i++)
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
                DirReg = (ent.Registros == null) ? 0 : ent.Registros.Count * longitud + 16;
                regAct = dgEntidad.CurrentRow.Index;
                reg[lenght + 1] = "-1" ;
                reg[0] = DirReg.ToString();
                ent.nuevoReg(UltimoReg);
                //DirReg += ent.Peso;
                //registros.Add(UltimoReg); //añade un nuevo registro
                reg = new string[lenght + 2];
                dgEntidad.Rows.Clear();
                actualizado();
            }
        }
    }
}
