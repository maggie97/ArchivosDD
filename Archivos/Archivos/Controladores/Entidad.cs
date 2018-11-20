using Archivos.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Entidad
    {
        char[] nombreEntidad = new char[30];
        long dir_Entidad = -1;
        long dir_Atributos = -1;
        long dir_Datos = -1;
        long dir_sig = -1;
        List<Atributo> atrib;
        List<List<string>> registros;

        int cve_busqeda = -1;
        Primario prim;
        List<Secundario> sec;

        public Entidad(char[] nombreEntidad, long dir_Entidad, long dir_Atributos, long dir_Datos)
        { 
            for (int i = 0; i < 30; i++)
            {
                if (nombreEntidad.Length > i)
                    this.nombreEntidad[i] = nombreEntidad[i];
                else
                    this.nombreEntidad[i] = ' ';
            }

            this.dir_Entidad = dir_Entidad;
            this.dir_Atributos = dir_Atributos;
            this.dir_Datos = dir_Datos;
            atrib = new List<Atributo>();
            registros = new List<List<string>>();
        } 
        public Entidad(char[] nombreEntidad, long dir_Entidad, long dir_Atributos, long dir_Datos, long dir_Sig)
        {
            //this.nombreEntidad = nombreEntidad;
            for (int i = 0; i < 30; i++)
            {
                if (nombreEntidad.Length > i)
                    this.nombreEntidad[i] = nombreEntidad[i];
                else
                    this.nombreEntidad[i] = ' ';
            }

            this.dir_Entidad = dir_Entidad;
            this.dir_Atributos = dir_Atributos;
            this.dir_Datos = dir_Datos;
            dir_sig = dir_Sig;
            atrib = new List<Atributo>();
        }

        public void nuevoA(Atributo a)
        {
            dir_Atributos = (atrib.Count == 0) ? a.DirAtributo : dir_Atributos;
            if(atrib.Count > 0)
                atrib.Last().DirSig = a.DirAtributo;
            atrib.Add(a);
        }

        public char[] NombreEntidad { get => nombreEntidad; set => nombreEntidad = value; }
        public long Dir_Entidad { get => dir_Entidad; set => dir_Entidad = value; }
        public long Dir_Atributos { get => dir_Atributos; set => dir_Atributos = value; }
        public long Dir_Datos { get => dir_Datos; set => dir_Datos = value; }
        public long Dir_sig { get => dir_sig; set => dir_sig = value; }
        public string sNombre
        {
            get
            {
                string nom = "";
                for (int i = 0; i < 30; i++)
                {
                    if (nombreEntidad[i] > -1 )
                        nom += nombreEntidad[i].ToString();
                }
                return nom;
            }
        }

        public List<Atributo> Atrib { get => atrib; set => atrib = value; }
        public List<List<string>> Registros { get => registros; set => registros = value; }
        public Primario Prim { get => prim; set => prim = value; }

        internal void nuevoReg(List<string> atributos)
        {
            if (Registros == null || Registros.Count == 0)
            {
                registros = new List<List<string>>();
                Indice();
            }
            registros.Add(atributos);
            if (prim != null)  prim.inserta(atributos[prim.aux+1], Convert.ToInt64(atributos[0])); 
             ordenaReg();
        }
        public void Indice()
        {
            foreach (var a in Atrib)
            {
                Indice _in = a.creaIndice(Atrib.IndexOf(a));
                if (_in != null)
                {
                    if (_in.GetType() == Type.GetType("Archivos.Controladores.Primario"))
                        prim = (Primario)_in;
                    else if (_in.GetType() == Type.GetType("Archivos.Controladores.Secundario"))
                    {
                        if (sec == null) sec = new List<Secundario>();
                        sec.Add((Secundario)_in);
                    }
                }
            }
        }
        public void ordenaReg()
        {
            if (atrib.Exists(o => o.TipoIndice == 1))
            {
                //ordena 
                int i = atrib.FindIndex(o => o.TipoIndice == 1);
                registros = registros.OrderBy(o => o[i + 1]).ToList();
                //registros.Sort((a, b) => (a[i].CompareTo(b[i])));
            }
            for (int i = 0; registros.Count > 0 && i < registros.Count; i++)
            {
                if (registros.Count - 1 == i)
                {
                    registros[i][atrib.Count + 1] = "-1";
                    break;
                }
                registros[i][atrib.Count + 1] = registros[i + 1].First();
            }
            if(registros.Count != 0) 
                dir_Datos = Convert.ToInt64(registros.First()[0]);
            else
                dir_Datos = -1 ;
        }
    }
}
