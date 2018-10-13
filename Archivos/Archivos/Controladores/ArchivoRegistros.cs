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
        List<List<string>> registros;
        public ArchivoRegistros(string fullname, Entidad e ) : base(fullname)
        {
            nuevoArch();
            

        }

    }
}
