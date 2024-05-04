/*
6 -) Faça um programa que apresente o seguinte menu de opções:
        I) Cadastrar Aluno
        II) Cadastrar Nota
        III) Cadastrar média
        IV) Listar alunos sem nota
        V) Excluir Aluno
        VI) Excluir Nota
        VII) Sair
    OBS:
    I) Cadastre um aluno com nome e número de cada vez em uma pilha, o número do aluno é dado automaticamente
    (primeiro aluno == nº1)
    II) Cadastre uma nota a qual a estrutura da nota é: número do aluno e Nota. Cadastrando-os em uma fila. Uma
    Nota só pode ser cadastrada se existir o aluno na pilha (cadastrar uma nota por vez, duas notas por aluno)
    III) O usuário deve digitar o número do aluno para mostrar sua média
    IV) Avise o usuário caso não exista o aluno ou nota
    V) Um aluno só pode ser excluído se não possuir notas
    VI) As notas devem ser excluídas respeitando a regras de fila
*/

using System;
using Trab_AlunosNota;

internal class Program
{
    private static void Main(string[] args)
    {
        int opc;
        PilhaAluno pilha = new PilhaAluno();
        FilaNota fila = new FilaNota();
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Nota");
            Console.WriteLine("3 - Cadastrar Média");
            Console.WriteLine("4 - Listar Alunos sem Nota");
            Console.WriteLine("5 - Excluir Aluno");
            Console.WriteLine("6 - Excluir Nota");
            Console.WriteLine("7 - Sair");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    pilha.push(cadastrarAluno());
                    break;
                case 2:
                    int matricula = -1;
                    Console.WriteLine(pilha.print());
                    while (matricula < 0 || matricula > pilha.getContador())
                    {
                        Console.WriteLine("Informe a matrícula do aluno ou digite 0 para voltar:");
                        matricula = int.Parse(Console.ReadLine());
                        if (matricula > pilha.getContador())
                        {
                            Console.WriteLine("Aluno não cadastrado!");
                        }
                    }
                    if (matricula > 0)
                    {
                        fila.push(cadastrarNota(pilha, matricula));
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    Console.WriteLine(pilha.print());
                    cadastrarMedia(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    listarAlunosSemNota(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 5:
                    excluirAluno(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 6:
                    excluirNota(fila);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 7:
                    Console.WriteLine("Adeus");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opc != 7);
    }
    static Aluno cadastrarAluno()
    {
        Console.WriteLine("Informe o nome do aluno:");
        Aluno temp = new Aluno(Console.ReadLine());
        return temp;
    }
    static Nota cadastrarNota(PilhaAluno pilha, int matricula)
    {
        float nota = -1;
        while (nota < 0 || nota > 10)
        {
            Console.WriteLine("Informe a nota do aluno:");
            nota = float.Parse(Console.ReadLine());
        }

        Nota temp = new Nota(matricula, nota);
        return temp;
    }
    static void cadastrarMedia(FilaNota fila, PilhaAluno pilha)
    {
        int matricula;
        int nromatriculas = pilha.getContador();

        Console.WriteLine("Informe a matrícula do aluno que deseja cadastrar a média.");
        matricula = int.Parse(Console.ReadLine());
        if (matricula > nromatriculas)
        {
            Console.WriteLine("Aluno não cadastrado!");
        }
        else
        {
            Console.WriteLine("A média do aluno é: " + fila.getMedia(matricula));
        }
    }
    static void listarAlunosSemNota(FilaNota fila, PilhaAluno pilha)
    {
        int numeroAlunos = pilha.getContador();
        int[] notas = new int[numeroAlunos];
        int[] alunos = new int[numeroAlunos];
        int contador = 0;
        bool insere;
        // POPULAR VETOR ALUNOS COM O CODIGO DOS ALUNOS PELA PILHA ALUNOS
        for (int i = 0; i < numeroAlunos; i++)
        {
            alunos[i] = pilha.getMatriculas(i);
        }
        // POPULAR VETOR NOTAS COM O CODIGO DOS ALUNOS, SEM REPETIR
        for (int i = 0; i < numeroAlunos; i++)
        {
            if (i == 0)
            {
                notas[i] = fila.getNotasMatriculas(i);
                contador++;
            }
            else
            {
                insere = true;
                for (int j = 0; j < numeroAlunos && insere; j++)
                {
                    if (notas[j] == fila.getNotasMatriculas(i))
                    {
                        insere = false;
                    }
                }
                if (insere)
                {
                    notas[contador] = fila.getNotasMatriculas(i);
                    contador++;
                }
            }
        }
        // COMPARO OS DOIS VETORES E ALTERO PARA NEGATIVO OS CODIGOS QUE EXISTEM NOS 2
        for (int i = 0; i < numeroAlunos; i++)
        {
            for (int j = 0; j < numeroAlunos; j++)
            {
                if (alunos[i] == notas[j])
                {
                    alunos[i] = alunos[i] * -1;
                }
            }
        }
        // IMPRIMO SOMENTE OS POSITIVOS (ALUNOS SEM NOTA)
        Console.WriteLine("Matriculas que não possuem notas cadastradas:");
        for (int i = 0; i < numeroAlunos; i++)
        {
            if (alunos[i] > 0)
            {
                Console.Write(pilha.getNomeMatriculas(alunos[i]));
            }
        }
    }
    static void excluirNota(FilaNota fila)
    {
        int opc = 0;
        Console.WriteLine("Notas cadastradas:");
        Console.WriteLine(fila.print());
        Console.WriteLine("Deseja excluir a primeira nota da fila? Digite 1 para sim.");
        opc = int.Parse(Console.ReadLine());
        if (opc == 1)
        {
            fila.pop();
        }
    }
    static void excluirAluno(FilaNota fila, PilhaAluno pilha)
    {
        int opc = 0;
        int topo = 0;
        int numeroAlunos = pilha.getContador();
        int[] notas = new int[numeroAlunos];
        int[] alunos = new int[numeroAlunos];
        bool insere;

        topo = pilha.getContador();
        Console.WriteLine("Alunos cadastrados:");
        Console.WriteLine(pilha.print());
        Console.WriteLine("Deseja excluir o aluino do topo da pilha? Digite 1 para sim.");
        opc = int.Parse(Console.ReadLine());
        if (opc == 1)
        {
            if (!fila.possuiNotas(topo))
            {
                pilha.pop();
            } else
            {
                Console.WriteLine("Atenção:");
                Console.WriteLine(pilha.getNomeMatriculas(topo));
                Console.WriteLine("Possui notas e não pode ser excluído.");
            }
        }
    }
}