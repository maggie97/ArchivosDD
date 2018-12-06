using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    class HashDinamico : Indice
    {
        int bit = 1;
        List<Elemento> principal;

        public HashDinamico(Atributo a, string nomb, int ind): base (nomb, ind, a)
        {
            principal = new List<Elemento>();
            for(int i =0; i<64; i++)
            {
                var dato = Convert.ToString(i, 2);
                while (dato.Length < 6) dato = '0' + dato;
                principal.Add(new Elemento(dato, -1));
            }
            if (!File.Exists(nomb + ".idx"))
            {
                nuevoArch();
                a.DirIndice = 0;
                escribePrincipal((int)a.DirIndice);
            }
            else if (a.DirIndice == -1) //no existe hash y/o el arch 
            {
                a.DirIndice = Longitud;
                escribePrincipal((int)a.DirIndice);
            }
            else //existe hash y existe el archivo 
            {
                //hay que leerlo 
                leePrincipal(a.DirIndice);

            }
        }

        public void inserta(int cb, long reg)
        {
            var sCB = Convert.ToString(cb, 2);
            while (sCB.Length < 6) sCB = '0' + sCB;
            
            var nuevos = sCB.Substring(0, bit);
            long dir = -1;
            Cajon_Secundario c =null;

            if (c.Tope < c.Capacidad)
            {
                var a = principal.Find(o => o.Cb.Substring(0, bit)== nuevos);
                if (a != null)
                {
                    //Lee el cajon
                    c = leeCajon(a.Ap);
                    dir = a.Ap;
                    int ind = c.Ap.FindIndex(o => o == -1);
                    if (c.Ap.FindIndex(o => o == reg) < 0)
                    {
                        c.Ap[ind] = reg;
                        c.Tope++;
                    }
                }
                else
                {
                    //principal[tope] = new Elemento(cb, Longitud);
                    c = new Cajon_Secundario(atrib);
                    dir = Longitud;
                    c.Elementos[0] = new Elemento(cb.ToString(), reg);
                    c.Tope++;
                }
            }

             
            for(int i = 0; i< principal.Count; i++)
            {
                var bits = principal[i].Cb.Substring(0, bit);
                if(bits == nuevos)
                {
                    principal[i].Ap = Longitud;
                }
            }
            escribePrincipal((int)atrib.DirIndice);
            escribeCajon((int)dir, c);

        }

        public void escribePrincipal(int l)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                b.Seek(l, SeekOrigin.Begin);
                for (int i = 0; i < principal.Count; i++)
                {
                    b.Write(principal[i].Cb.ToArray(), 0, 6);
                    b.Write(principal[i].Ap);
                }
            }
        }

        public void escribeCajon(int l, Cajon_Secundario c)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                b.Seek(l, SeekOrigin.Begin);
                for (int i = 0; i < principal.Count; i++)
                {
                    for (int j = 0; j < c.Capacidad; j++)
                    {
                        b.Write(c.Elementos[i].Cb.ToArray(), 0, atrib.Longitud);
                        b.Write(c.Elementos[i].Ap);
                    }
                    b.Write(c.Sig);
                }
            }
        }
        public void leePrincipal(long l)
        {
            principal = new List<Elemento>();
            for (int i = 0; i < 64; i++)
            {
                var dato = Convert.ToString(i, 2);
                while (dato.Length < 6) dato = '0' + dato;
                principal.Add(new Elemento(dato, -1));
            }

            using (BinaryReader r = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                r.BaseStream.Seek(l, SeekOrigin.Begin);
                Console.WriteLine(r.PeekChar());
                for (int i = 0; i < principal.Count; i++)
                {
                    char[] cb = r.ReadChars(6);
                    Console.WriteLine(cb.ToArray());
                    string s = "";
                    while (s.Length < cb.Length) s += cb[s.Length];
                    long ap = r.ReadInt64();
                    Console.WriteLine(ap);
                    if (ap != -1)
                    {
                        principal[i].Cb = s;
                        principal[i].Ap = ap;
                    }
                }
            }
        }
        public Cajon_Secundario leeCajon(long l)
        {
            Cajon_Secundario c = null;
            using (BinaryReader r = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                r.BaseStream.Seek(l, SeekOrigin.Begin);
                Console.WriteLine(r.PeekChar());  
                for (int i = 0; i < c.Capacidad; i++)
                {
                    char[] cb = r.ReadChars(atrib.Longitud );
                    Console.WriteLine(cb.ToArray());
                    string s = "";
                    while (s.Length < cb.Length) s += cb[s.Length];
                    long ap = r.ReadInt64();
                    Console.WriteLine(ap);
                    if (ap != -1)
                    {
                        //inserta(s, ap);
                        if (i == 0) c = new Cajon_Secundario(atrib); 
                        c.Elementos[i].Cb = s;
                        c.Elementos[i].Ap = ap;
                        c.Tope++;
                    }
                }
            }
            return c;
        }
    }
}
