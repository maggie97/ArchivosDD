using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Registro : Archivo
    {
        public long firstReg = 0;
        public Registro(string fullname) : base(fullname)
        {
        }

    }
}
