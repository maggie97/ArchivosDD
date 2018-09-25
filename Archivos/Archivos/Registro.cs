using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Registro : Archivo
    {
        public Registro(string fullname) : base(fullname)
        {
        }

        public Registro(string filename, string extencion, string direccion) : base(filename, extencion, direccion)
        {
        }
    }
}
