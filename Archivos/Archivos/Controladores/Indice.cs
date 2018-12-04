﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public abstract class Indice : Archivo
    {
        protected Cajon[] cajoncitos;
        public int index = 0;
        public Entidad ent;

        public Indice(string Nombre, int i) : base(Nombre + ".idx")
        {
            index = i; 
        }

        public Cajon[] Cajoncitos { get => cajoncitos; set => cajoncitos = value; }
    }
}
