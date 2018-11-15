using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    class Secundario : Indice
    {
        public Secundario(string nombre, int i): base (nombre, i)
        {
            cajoncitos = new Cajon[50];
        }
    }
}
