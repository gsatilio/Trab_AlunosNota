using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AlunosNota
{
    internal class PilhaAluno
    {
        Aluno topo;
        int matricula = 0;
        public PilhaAluno()
        {
            this.topo = null;
        }
        bool vazia()
        {
            if (topo == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void push(Aluno aux)
        {
            if (vazia() == true)
            {
                topo = aux;
            }
            else
            {
                aux.setAnterior(topo);
                topo = aux;
            }
            matricula++;
            aux.setNumero(matricula);
        }
        public void pop()
        {
            if (!vazia())
            {
                topo = topo.getAnterior();
                matricula--;
            }
        }
        public string print()
        {
            Aluno aux = topo;
            string texto = "";
            do
            {
                texto += $"{aux.ToString()}\n";
                aux = aux.getAnterior();
            } while (aux != null);
            return texto;
        }
        public int getContador()
        {
            int contador = 0;
            Aluno aux = topo;
            if (!vazia())
            {
                do
                {
                    contador++;
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            return contador;
        }
    }
}
