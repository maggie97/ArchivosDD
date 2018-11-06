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
        public Primario(bool letras, string Nombre) : base(Nombre)
        {
            cajoncitos = new Cajon[100];
            cajoncitos.Initialize();
            int inicia = (letras) ? 49 : 65;
            primario = new Cajon(0); 
        }

        public Cajon prim { get => primario; set => primario = value; }
    }
}
