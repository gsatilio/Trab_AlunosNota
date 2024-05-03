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
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Nota");
            Console.WriteLine("3 - Cadastrar Média");
            Console.WriteLine("4 - Listar Alunos sem Nota");
            Console.WriteLine("5 - Excluir Aluno");
            Console.WriteLine("6 - Excluir Nota");
            Console.WriteLine("7 - Sair");
            opc = int.Parse(Console.ReadLine());
            switch(opc)
            {
                case 1:
                    pilha.push(cadastrarAluno());
                    break;
                case 2:
                    fila.push(cadastrarNota());
                    break;
                case 3:
                    cadastrarMedia(pilha);
                    break;
                case 4:
                    Console.WriteLine(pilha.print());
                    Console.WriteLine("Informe a matricula para saber a nota");
                    Console.WriteLine(fila.getValores(int.Parse(Console.ReadLine())));
                    break;
                case 5:
                    pilha.pop();
                    break;
                case 6:
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
    static Nota cadastrarNota()
    {
        int matricula;
        float nota;
        Console.WriteLine("Informe a matrícula do aluno:");
        matricula = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe a nota do aluno:");
        nota = float.Parse(Console.ReadLine());

        Nota temp = new Nota(matricula, nota);
        return temp;
    }
    static void cadastrarMedia(PilhaAluno pilha)
    {
        Console.WriteLine(pilha.print());
        Console.WriteLine("Informe a matrícula do aluno que deseja cadastrar a média.");

    }
}