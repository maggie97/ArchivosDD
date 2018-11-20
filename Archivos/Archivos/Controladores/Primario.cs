using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public class Primario : Indice
    {
        List<Cajon> subCajones;
        Cajon primario;
        int Long_CB;
        Atributo atrib;
        
        public Primario(Atributo a, bool letras, string Nombre, int i, int long_CB) : base(Nombre, i)
        {
            nuevoArch();
            int inicia = (letras) ? 49 : 65;
            primario = new Cajon(0);
            Long_CB = long_CB;
            atrib = a;
            escribePrimario();
        }
        public Primario(Atributo a, int i ): base(a.sNombre , i)
        {
            atrib = a;
            if (File.Exists(Fullname))
            {
                //lee el cajon primario de la A a la Z
                leePrimario();
                //lee los cajones   
                for(int j = 0; j < prim.Longitud; j++)
                {
                    if (prim.Ap[j] != -1)
                        leeCajon(prim.Ap[j]);
                }
            }
            else
                nuevoArch();
            Long_CB = a.Longitud;

        }
        public Cajon prim { get => primario; set => primario = value; }
        public List<Cajon> SubCajones { get => subCajones; set => subCajones = value; }
        internal void inserta(string claveBusq, long apuntador)
        {
            for(int i = 0; i < prim.Longitud; i++)
            {
                if(prim.Ind[i] == char.ToUpper(claveBusq[0]))
                {
                    if (prim.Ap[i] == -1)
                    {
                        //crea nueva caja tipo primaria 2 (1)
                        //agregaremos la clave de busqueda y el apuntador al registro el tamaño del archivo sera igual a
                        //prim.Ap[i]
                        Cajon c = new Cajon(claveBusq, apuntador, Long_CB);
                        if (subCajones == null) subCajones = new List<Cajon>();
                        subCajones.Add(c);
                        if (subCajones.Count > 0)
                            subCajones = subCajones.OrderBy(o => o.Cb[0]).ToList();
                        prim.Ap[i] = Longitud;
                        escribePrimario_Cajon(c);
                    }
                    else
                    {
                        var c = ElCajon(prim.Ap[i]);
                        var ind = subCajones.FindIndex(o => o.c == claveBusq[0]);
                        c.inserta(claveBusq, apuntador);
                        escribePrimario_Cajon(prim.Ap[i], c );
                    }
                    //sobreescribePrimario();
                    
                    i = prim.Longitud;
                }
            }
            
        }
        public void escribePrimario()
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            { 
                for(int i= 0; i< primario.Longitud; i++)
                {
                    b.Write(primario.Ind[i]);
                    b.Write(primario.Ap[i]);
                }
            }
        }
        public void leePrimario()
        {
            using (BinaryReader r = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            { 
                Console.WriteLine(r.PeekChar());
                if (r.PeekChar() == 65)
                {
                    prim = new Cajon(0);//26;
                    for (int i = 0; i < prim.Longitud; i++)
                    {
                        Console.WriteLine(r.ReadChar());
                        long ap = r.ReadInt64();
                        Console.WriteLine(ap);
                        if (ap != -1)
                            prim.Ap[i] = ap;
                    }
                }
            }
        }
        private void leeCajon(long ind)
        {
            if (subCajones == null) subCajones = new List<Cajon>();
            subCajones.Add(ElCajon(ind));
            /*Cajon c = new Cajon(atrib);
            /*using (BinaryReader r = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                r.BaseStream.Seek(ind, SeekOrigin.Begin);
                int i = 0;
                char[] var; long d = 0;
                while(i < 50 && d >= 0)
                {
                    var = r.ReadChars(c.Cb.First().Length);
                    string a = "";
                    while (a.Length < c.Cb.First().Length) a += var[a.Length];
                    Console.WriteLine(var);
                    d = r.ReadInt64();
                    Console.WriteLine(d);
                    if (!a.Contains("aux"))
                    {
                        c.inserta(a, d);
                    }
                    i++;
                }
                
            }*/
            //return c;
        }
        public Cajon ElCajon(long ind)
        {
            
            Cajon c = new Cajon(atrib);
            using (BinaryReader r = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                r.BaseStream.Seek(ind, SeekOrigin.Begin);
                int i = 0;
                char[] var; long d = 0;
                while (i < 50 && d >= 0)
                {
                    var = r.ReadChars(c.Cb.First().Length);
                    string a = "";
                    while (a.Length < c.Cb.First().Length) a += var[a.Length];
                    Console.WriteLine(var);
                    d = r.ReadInt64();
                    Console.WriteLine(d);
                    if (!a.Contains("aux"))
                    {
                        c.inserta(a, d);
                    }
                    i++;
                }
            }
            return c;
        }
        public void escribePrimario_Cajon(Cajon cajon)
        {
            using(BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Append)))
            {
                for(int i= 0; i < cajon.Longitud; i++)
                {
                    b.Write(cajon.Cb[i].ToCharArray(), 0, atrib.Longitud);
                    b.Write(cajon.Ap[i]);
                }
            }
        }

        public void escribePrimario_Cajon(long l, int indC)
        {
            var cajon = subCajones[indC];
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                b.Seek((int)l, SeekOrigin.Begin);
                for (int i = 0; i < cajon.Longitud; i++)
                {
                    b.Write(cajon.Cb[i]);
                    b.Write(cajon.Ap[i]);
                }
            }
        }

        public void escribePrimario_Cajon(long l, Cajon C)
        { 
            using (BinaryWriter b = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                b.Seek((int)l, SeekOrigin.Begin);
                for (int i = 0; i < C.Longitud; i++)
                {
                    b.Write(C.Cb[i]);
                    b.Write(C.Ap[i]);
                }
            }
        }
    }
}
