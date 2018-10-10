using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class ArchivoRegistros : Archivo
    {
        public long firstReg = 0;
        List<List<Object>> registros;
        public ArchivoRegistros(string fullname) : base(fullname)
        {

        }

    }
}
