using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    class Secundario : Indice
    {
        Cajon_Secundario principal;
        int capacidad = 100;
        int lng_Campo;
        public Secundario(Atributo a, string nombre, int i): base (nombre, i, a)
        {
            if(!File.Exists(nombre + ".idx"))
            {
                nuevoArch();
                a.DirIndice = 0;
            }
            principal = new Cajon_Secundario(a);
            escribeSecundario((int)a.DirIndice);
        }

        internal Cajon_Secundario Principal { get => principal; set => principal = value; }

        public void escribeSecundario(int l)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                b.Seek(l, SeekOrigin.Begin);
                for (int i = 0; i < principal.Capacidad; i++)
                {
                    b.Write(principal.Elementos[i].Cb);
                    b.Write(principal.Elementos[i].Ap);
                }
            }
        }
    }
}
