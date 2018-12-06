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

        internal List<Elemento> Principal { get => principal; set => principal = value; }

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

        public void inserta(string cb, long reg)
        {
            var s =  cb[0];
            var sCB = Convert.ToString(Int32.Parse(s.ToString()), 2);
            while (sCB.Length < 4) sCB = '0' + sCB;
            if (bit < 4)
            {
                while (sCB.Length < 6) sCB += '0';
            }
            else
            {
                s = cb[1];
                var s2 = Convert.ToString(Int32.Parse(s.ToString()), 2);
                sCB += s2.Substring(0, 2);
            }
            var nuevos = sCB.Substring(0, bit);
            long dir = -1;
            Cajon_Secundario c =null;

            //if (c.Tope < c.Capacidad)
            
            var a = principal.Find(o => o.Cb.Substring(0, bit)== nuevos);
            if (a.Ap != -1)
            {
                //Lee el cajon
                c = leeCajon(a.Ap);
                dir = a.Ap;
                if (c != null)
                {
                    int ind = c.Elementos.FindIndex(o => o.Ap == -1);
                    //if (c.Elementos.FindIndex(o => o.Cb == reg) < 0)
                    if(c.Tope < c.Capacidad)
                    {
                        c.Elementos[c.Tope] = new Elemento(cb, reg);
                        c.Tope++;
                    }
                    else if(bit <= 6)
                    {
                        bit++;
                        //duplicamos el cajon y dividimos valores segun correspondan 
                        dir = Longitud;
                    }
                }
            }
            else
            {
                //principal[tope] = new Elemento(cb, Longitud);
                c = new Cajon_Secundario(atrib, 0);
                dir = Longitud;
                c.Elementos[0] = new Elemento(cb, reg);
                c.Tope++;
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
                for (int j = 0; j < c.Capacidad; j++)
                {
                    b.Write(Int32.Parse(c.Elementos[j].Cb));
                    b.Write(c.Elementos[j].Ap);
                }
                b.Write(c.Sig);
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
                for (int i = 0; i < 100; i++)
                {
                    //char[] cb =//r.ReadChars(atrib.Longitud );
                    int cb = r.ReadInt32();
                    Console.WriteLine(cb);
                   // string s = "";
                   // while (s.Length < cb.Length) c;
                    long ap = r.ReadInt64();
                    Console.WriteLine(ap);
                    if (ap != -1)
                    {
                        //inserta(s, ap);
                        if (i == 0) c = new Cajon_Secundario(atrib, 0); 
                        c.Elementos[i].Ap = ap;
                        c.Tope++;
                    }
                }
            }
            return c;
        }
    }
}
