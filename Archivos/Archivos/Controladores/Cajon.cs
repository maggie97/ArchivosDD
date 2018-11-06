using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    public class Cajon
    {
        char[] ind;
        int op;
        public Cajon(int op)
        {
            this.op = op;
            int o = (op == 0) ? 26 : (op == 1)? 9: 0;
            this.ind =  new char[o];//new indPrim[o];
            int inicia = (op == 1) ? 49 : 65;
            for (int i = 0;i< o; i ++)
            {
                ind[i] = Convert.ToChar(inicia);
            } 
            
        }

        public char[] Ind { get => ind; set => ind = value; }
    }
}
