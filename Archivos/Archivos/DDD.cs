using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Archivos
{
    class DDD : Archivo
    { 
        List<Object> obj = new List<object>();
        List<Entidad> list_insercion = new List<Entidad>();
        List<Entidad> list_entidades = new List<Entidad>();
        long cab = -1;

        public List<Entidad> Entidades { get => list_insercion; set => list_insercion = value; }
        public List<Entidad> EntidadesOrden { get => list_entidades; set => list_entidades = value; }
        public long Cab { get => cab; set => cab = value; }

        public DDD(string filename, string extencion, string direccion) 
            : base(filename, extencion, direccion)
        {

        }

        public DDD(string fullname) : base (fullname)
        {

        }

        public void abreArchivo()
        {
            List<Object> obj = new List<object>();
            List<Entidad> entidades = new List<Entidad>();
            List<Entidad> entidadesOrden = new List<Entidad>();
            //long Cab = -1;

            lee();
        }
        public new void lee()
        {
            long cab;
            using (BinaryReader reader = new BinaryReader(File.Open(base.Fullname, FileMode.Open)))
            {
                cab = reader.ReadInt64();
                Console.WriteLine(cab);
                //int i = 0;
                try
                {
                    while (reader.PeekChar() >= -1)
                    {
                        string nomb = "";
                        long dir_ent;//, dir_atr, dir_dat, dir_sig;
                        char[] nombre = reader.ReadChars(30);
                        foreach (char n in nombre)
                        {
                            nomb += n;
                        }
                        
                        dir_ent = reader.ReadInt64();
                        Console.WriteLine(reader.PeekChar().GetType());
                        list_insercion.Add(leeEntidad(reader, nomb, dir_ent));
                        list_entidades.Add(list_insercion.Last());
                    }
                }
                catch { }
            }
        }
        public List<Entidad> RefreshGrid()
        {
            List<Entidad> e= new List<Entidad>();
            using (BinaryReader reader = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                long cab = reader.ReadInt64();
                Console.WriteLine(cab);
                //int i = 0;
                try
                {
                    while (reader.PeekChar() >= -1)
                    {
                        string nomb = "", dir_ent, dir_atr, dir_dat, dir_sig;
                        char[] nombre = reader.ReadChars(30);
                        foreach (char c in nombre)
                        {
                            nomb += c;
                        }
                        dir_ent = reader.ReadInt64().ToString();
                        dir_atr = reader.ReadInt64().ToString();
                        dir_dat = reader.ReadInt64().ToString();
                        dir_sig = reader.ReadInt64().ToString();
                        Entidad n = new Entidad(nombre, Convert.ToInt64(dir_ent), Convert.ToInt64( dir_atr), Convert.ToInt64(dir_dat), Convert.ToInt64(dir_sig));
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", nomb, dir_ent, dir_atr, dir_dat, dir_sig);
                        e.Add(n);
                    }
                }
                catch { }
            }
            return e;
        }
        public void sobreescribeCab()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                writer.Seek(0, SeekOrigin.Begin);
                writer.Write(cab);
            }
        }

        public void leeCab()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Fullname, FileMode.Open)))
            {
                cab = reader.ReadInt64();
                Console.WriteLine("Cabecera: " + cab);
            }/**/
        }

        #region entidades

        public Entidad leeEntidad(BinaryReader reader, string name, long dir)
        {
            long dir_atr, dir_dat, dir_sig;
            dir_atr = reader.ReadInt64();
            dir_dat = reader.ReadInt64();
            dir_sig = reader.ReadInt64();
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, dir, dir_atr, dir_dat, dir_sig);
            return (new Entidad(name.ToCharArray(), dir, dir_atr, dir_dat, dir_sig));
        }

        public void nuevaEntidad(string nomb)
        {
            try
            {
                long sig_ent = -1;
                if (list_insercion.Count != 0)
                {
                    list_insercion.Last().Dir_sig = Longitud;
                }
                Entidad entidad = new Entidad(nomb.ToCharArray(), Longitud, -1, sig_ent);
                Console.WriteLine(nomb + entidad.Dir_Entidad.ToString() + entidad.Dir_sig.ToString());
                list_insercion.Add(entidad);
                list_entidades.Add(entidad);
                //Ordena las entidades
                list_entidades = list_entidades.OrderBy(o => o.sNombre).ToList();

                cab = list_entidades[0].Dir_Entidad; //Asigna el valor de la primera entidad a la cabecera 
                sobreescribeCab(); //Se sobreescribe la cabecera

                guardaEntidad(entidad); //Se guarda la nueva entidad.
                ordena();
                sobreescribEntidades();
            }
            catch (Exception e)
            {
                Console.WriteLine("causo una excepcion: ", e);
            }
        }
        public void eliminaEntidad(int i)
        {
            long ds = list_insercion[i].Dir_sig;
            for(int j = 0; j< list_entidades.Count; j++)
            {
                if(list_entidades[j].Dir_sig == list_insercion[i].Dir_Entidad)
                {
                    list_insercion[i].Dir_sig = -1;
                    list_entidades[j].Dir_sig = ds;
                    list_entidades.Remove(list_insercion[i]);
                }
            }
            sobreescribEntidades();
            
        }

        public void guardaEntidad(Entidad e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(base.Fullname, FileMode.Append)))
            {
                writer.Write(e.NombreEntidad);
                writer.Write(e.Dir_Entidad);
                writer.Write(e.Dir_Atributos);
                writer.Write(e.Dir_Datos);
                writer.Write(e.Dir_sig);
            }
        }
        public void ordena()
        {
            list_entidades = list_entidades.OrderBy(o => o.sNombre).ToList();
            for (int i = 0; i < list_entidades.Count - 1; i++)
            {
                list_entidades[i].Dir_sig = list_entidades[i + 1].Dir_Entidad;
            }
            list_entidades.Last().Dir_sig = -1;
            foreach (Entidad e in list_entidades)
            {
                int i = list_insercion.IndexOf(e);
                list_insercion[i] = e;
            }
        }

        public void sobreescribEntidades()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                writer.Seek(8, SeekOrigin.Begin);
                foreach (Entidad e in list_insercion)
                {
                    writer.Write(e.NombreEntidad);
                    writer.Write(e.Dir_Entidad);
                    writer.Write(e.Dir_Atributos);
                    writer.Write(e.Dir_Datos);
                    writer.Write(e.Dir_sig);
                }
            }
        }
        #endregion

        #region atributos
        public Entidad nuevoAtributo(string nombre, int tipo, int longi, int iEnt)
        {
            Atributo nuevo = new Atributo(nombre, Longitud, tipo, longi, 0, -1, -1);
            list_entidades[iEnt].nuevoA(nuevo);
            guardaAtrib(nuevo);
            sobreescribAtributos(list_entidades[iEnt]);
            return list_entidades[iEnt];
        }
        public void guardaAtrib(Atributo a)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Fullname, FileMode.Append)))
            {
                writer.Write(a.Nombre);
                writer.Write(a.DirAtributo);
                writer.Write(a.Tipo);
                writer.Write(a.Longitud);
                writer.Write(a.TipoIndice);
                writer.Write(a.DirIndice);
                writer.Write(a.DirSig);
            }
        }
        public void sobreescribAtributos(Entidad e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Fullname, FileMode.Open)))
            {
                writer.Seek(Convert.ToInt32(e.Atrib.First().DirAtributo), SeekOrigin.Begin);
                foreach (Atributo a in e.Atrib)
                {
                    writer.Write(a.Nombre);
                    writer.Write(a.DirAtributo);
                    writer.Write(a.Tipo);
                    writer.Write(a.Longitud);
                    writer.Write(a.TipoIndice);
                    writer.Write(a.DirIndice);
                    writer.Write(a.DirSig);
                }
            }
        }
        public void leeAtributo()
        {

        }

        #endregion

        
    }
}
