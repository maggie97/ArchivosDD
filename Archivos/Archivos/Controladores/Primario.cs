using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public class Primario : Indice
    {
        //Cajon[] primario;
        Cajon primario;
        
        public Primario(bool letras, string Nombre, int i) : base(Nombre, i)
        {
            //cajoncitos = new Cajon[100];
            //cajoncitos.Initialize();

            int inicia = (letras) ? 49 : 65;
            primario = new Cajon(0); 
        }

        public Cajon prim { get => primario; set => primario = value; }

        internal void inserta(string claveBusq, long apuntador)
        {
            for(int i = 0; i < prim.Longitud; i++)
            {
                if(prim.Ind[i] == char.ToUpper(claveBusq[0]))
                {
                    prim.Ap[i] = apuntador;
                    //crea nueva caja tipo primaria 2 (1)
                    //agregaremos la clave de busqueda y el apuntador al registro el tamaño del archivo sera igual a
                    //prim.Ap[i]
                    Cajon c = new Cajon( claveBusq, apuntador);
                }
            }
        }
    }
}
