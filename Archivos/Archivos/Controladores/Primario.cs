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
        
        public Primario(bool letras, string Nombre, int i) : base(Nombre, i)
        {
            //cajoncitos = new Cajon[100];
            //cajoncitos.Initialize();

            int inicia = (letras) ? 49 : 65;
            primario = new Cajon(0);

            sobreescribePrimario();
        }

        public Cajon prim { get => primario; set => primario = value; }

        internal void inserta(string claveBusq, long apuntador)
        {
            for(int i = 0; i < prim.Longitud; i++)
            {
                if(prim.Ind[i] == char.ToUpper(claveBusq[0]))
                {
                    
                    //crea nueva caja tipo primaria 2 (1)
                    //agregaremos la clave de busqueda y el apuntador al registro el tamaño del archivo sera igual a
                    //prim.Ap[i]
                                          
                    Cajon c = new Cajon(claveBusq, apuntador);
                    if (subCajones == null) subCajones = new List<Cajon>();
                    subCajones.Add(c);
                    prim.Ap[i] = Longitud;

                    sobreescribePrimario();
                    i = prim.Longitud;
                }
            }
            
        }

        public void sobreescribePrimario(/*Cajon primario, List<Cajon> subCajones*/)
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
    }
}
