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
    public partial class NuevoAtributo : Form
    {
        
        public NuevoAtributo(List<Entidad> entidades)
        {
            InitializeComponent();
            foreach (Entidad e in entidades)
                cmb_Entidad.Items.Add(e.sNombre);

            //cmbTipo.Items.AddRange(new object[] {"int", "float", "char","string" });
        }

        public string Nombre_atributo { get => txt_Nombre.Text; }
        public int Long { get => Convert.ToInt32(txt_Long.Text); }
        public string Tipo { get => cmbTipo.SelectedItem.ToString(); }
        public string Entidad { get => cmb_Entidad.SelectedItem.ToString(); }
        public int Index { get => cmb_Entidad.SelectedIndex; }
    }
}
