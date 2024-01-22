//Importação
using ProjetoAula01Exercicios.Entities;
using ProjetoAula01Exercicios.Repositories;
using System.Globalization;

//Definindo a localização da classe dentro do projeto
namespace ProjetoAula01Exercicios
{
    //Declaração da Classe
    public class Program
    {
        //Método 'main': executando quando rodamos o projeto
        public static void Main(string[] args)
        {
            //Imprimir mensagem no terminal (console)
            Console.WriteLine("SISTEMA PARA CADASTRO DE FUNCIONARIOS");

            var funcionario = new Funcionario();

            funcionario.IdFuncionario = Guid.NewGuid();

            Console.Write("Insira seu nome.: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Insira seu Cpf..: ");
            funcionario.Cpf = Console.ReadLine();

            Console.Write("Insira seu Matricula: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("Insira seu Matricula: ");
            var DataAdmissao = Console.ReadLine();

            if (!String.IsNullOrEmpty(DataAdmissao))
                funcionario.DataAdmissao = DateTime.Parse(DataAdmissao, new CultureInfo("pt-BR"));
            else
                funcionario.DataAdmissao = null;

            Console.Write("Insira seu Cargo: ");
            funcionario.Cargo = Console.ReadLine();

            Console.Write("Insira seu Salario: ");
            var Salario = Console.ReadLine();

            if (!String.IsNullOrEmpty(Salario))
                funcionario.Salario = Decimal.Parse(Salario, new CultureInfo("pt-BR"));
            else
                funcionario.Salario = null;


            //Imprimindo 
            Console.WriteLine("\nDADOS DO FUNCIONARIOS:");
            Console.WriteLine("ID............:" + funcionario.IdFuncionario);
            Console.WriteLine("NOME..........:" + funcionario.Nome);
            Console.WriteLine("CPF...........:" + funcionario.Cpf);
            Console.WriteLine("MATRICULA.....:" + funcionario.Matricula);
            Console.WriteLine("DATA ADMISSAO.:" + funcionario.DataAdmissao);
            Console.WriteLine("CARGO.........:" + funcionario.Cargo);
            Console.WriteLine("SALARIO.......:" + funcionario.Salario);

            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.ExpotarDados(funcionario);

            //pausa o terminal
            Console.ReadKey();
        }
    }
}