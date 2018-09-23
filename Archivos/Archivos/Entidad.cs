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


        public Entidad(char[] nombreEntidad, long dir_Entidad, long dir_Atributos, long dir_Datos)
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
            atrib = new List<Atributo>();
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
                    if (nombreEntidad[i] > -1)
                        nom += nombreEntidad[i].ToString();
                }
                return nom;
            }
        }

        public List<Atributo> Atrib { get => atrib; set => atrib = value; }
    }
}
