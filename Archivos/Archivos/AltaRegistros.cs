using System; 
using System.Windows.Forms;

namespace Archivos
{
    public partial class AltaRegistros : Form
    {
        Entidad ent;
        Archivo a;
        public AltaRegistros(Entidad entidad)
        {
            InitializeComponent();
            lblNomEntidad.Text = entidad.sNombre; 
            ent = entidad;
            a = new ArchivoRegistros(ent.sNombre + ".dat");
        }

        private void AltaRegistros_Load(object sender, EventArgs e)
        {
            foreach(Atributo a in ent.Atrib)
            {
                dgEntidad.Columns.Add("clm_" + a.sNombre, a.sNombre);
            }
        }

    }
}
