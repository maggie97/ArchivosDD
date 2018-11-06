using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public abstract class Indice :Archivo
    {
        protected Cajon[] cajoncitos;

        public Indice(string Nombre) : base(Nombre + ".idx")
        {

        }

        public Cajon[] Cajoncitos { get => cajoncitos; set => cajoncitos = value; }
    }
}
