using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.Controladores
{
    enum Index { Primario_Principal, Primario_Cajon,Secundario_Principal, Secundario_Cajon, HashD, Multilistas}
    public class Cajon
    {
        char[] ind;
        List<List<char>> cv;
        string[] cb;
        long[] ap;
        int longitud = 0;
        public char c = '\0';
        Index op;

        public Cajon(int op)
        {
            this.op = Index.Primario_Principal;
            longitud = (op == 0) ? 26 : (op == 1)? 9: 0;
            ind =  new char[longitud]; 
            ap = new long[longitud];
            int inicia = (op == 1) ? 49 : 65;
            for (int i = 0;i< longitud; i ++)
            {
                ind[i] = Convert.ToChar(inicia);
                ap[i] = -1;
                inicia++;
            }  
        }
        public Cajon(Atributo a)
        {
            if(a.TipoIndice == 2)
            {
                creaBloqPrimario(a.Longitud);
            }
        }
        public Cajon(string claveBusq, long apuntador, int long_clave)
        {
            creaBloqPrimario(long_clave);
            inserta(claveBusq, apuntador);
        }
        public void creaBloqPrimario(int long_clave)
        {
            this.op = Index.Primario_Cajon;
            longitud = 50;
            cv = new List<List<char>>();
            cb = new string[longitud];
            ap = new long[longitud];
            for (int i = 0; i < longitud; i++)
            {
                string s = "";//"aux" + i;
                while (s.Length < long_clave - 1 ) s += " ";
                cb[i] = s;
                ap[i] = -1;
            }
        }
        public void inserta(string claveBusq, long apuntador)
        {
            int i = 0;
            while (i < longitud)
            {
                if (ap[i] == -1)//cb[i].Contains("aux" ))
                {
                    string s = claveBusq;
                    while (s.Length < cb[i].Length) s += " ";
                    cb[i] = s;
                    ap[i] = apuntador;
                    break;
                }
                i++;
            }
        }
        public char[] Ind { get => ind; set => ind = value; }
        public long[] Ap { get => ap; set => ap = value; }
        public int Longitud { get => longitud; set => longitud = value; }
        public string[] Cb { get => cb; set => cb = value; }
    }
}
