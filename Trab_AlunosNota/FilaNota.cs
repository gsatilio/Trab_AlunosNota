using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AlunosNota
{
    internal class FilaNota
    {
        Nota? inicio;
        Nota? fim;
        public FilaNota()
        {
            this.inicio = null;
            this.fim = null;
        }
        internal bool vazia()
        {
            return inicio == null && fim == null;
        }
        public void push(Nota aux)
        {
            if (vazia())
            {
                this.inicio = this.fim = aux;
            }
            else
            {
                int contador = 0;
                Nota aux2 = inicio;
                do
                {
                    if (aux2.getMatricula() == aux.getMatricula())
                    {
                        contador++;
                    }
                    aux2 = aux2.getProximo();
                } while (aux2 != null);
                if (contador == 2)
                {
                    Console.WriteLine("Não pode inserir mais de 2 notas.");
                }
                else
                {
                    this.fim.setProximo(aux);
                    this.fim = aux;
                }
            }
        }
        public void pop()
        {
            if (!vazia())
            {
                if (fim == inicio) // se cabeca = cauda entao so tem 1 elemento na fila
                {
                    inicio = fim = null;
                }
                else
                {
                    this.inicio = this.inicio.getProximo();
                }
            }
        }
        public float getValores(int matricula)
        {
            float nota1 = -1, nota2 = -1;
            Nota aux = inicio;
            do
            {
                if (aux.getMatricula() == matricula)
                {
                    if (nota1 < 0)
                    {
                        nota1 = aux.getNota(matricula);
                    }
                    else
                    {
                        nota2 = aux.getNota(matricula);
                    }
                }
                aux = aux.getProximo();
            } while (aux != null);
            if (nota1 < 0)
            {
                nota1 = 0;
            }
            return nota1;
        }
    }
}
