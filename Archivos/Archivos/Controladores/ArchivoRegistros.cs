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
            registros = new List<List<string>>();
        }
        public void sobreescribirArch()
        {
            foreach(List<string> reg in registros)
            {
                foreach(string val in reg)
                { 
                    long l;
                    int num;

                    if(Int64.TryParse(val, out l))
                    {
                        
                    }
                    else if(Int32.TryParse(val, out num))
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
