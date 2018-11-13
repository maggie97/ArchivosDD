using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public abstract class Indice : Archivo
    {
        protected Cajon[] cajoncitos;
        public int aux = 0;

        public Indice(string Nombre, int i) : base(Nombre + ".idx")
        {
            nuevoArch();
            aux = i;
        }

        public Cajon[] Cajoncitos { get => cajoncitos; set => cajoncitos = value; }
    }
}
