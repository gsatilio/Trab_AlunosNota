﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AlunosNota
{
    internal class Aluno
    {
        string nome;
        Aluno anterior;
        int matricula;

        public Aluno(string nome)
        {
            this.nome = nome;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return this.nome;
        }
        public void setNumero(int numero)
        {
            this.matricula = numero;
        }
        public void setAnterior(Aluno aux)
        {
            this.anterior = aux;
        }
        public Aluno getAnterior()
        {
            return this.anterior;
        }
        public override string? ToString()
        {
            return "Aluno: " + nome + " numero: " + matricula;
        }
    }
}
