//Importação
using ProjetoAula01.Entities;
using ProjetoAula01.Repositories;

//Definindo a localização da classe dentro do projeto
namespace ProjetoAula01
{
    //Declaração da Classe
    public class Program
    {
        //Método 'main': executando quando rodamos o projeto
        public static void Main(string[] args)
        {
            //Imprimir mensagem no terminal (console)
            Console.WriteLine("SISTEMA PARA CADASTRO DE CLIENTES");

            var cliente = new Cliente();

            cliente.Id = Guid.NewGuid();
            //cliente.nome = "Arthur Gameiro";
            //cliente.email = "arthurGameiro@gmail.com";
            //cliente.cpf = "123.456.789.00";

            Console.Write("Insira seu nome.: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Insira seu Cpf..: ");
            cliente.Cpf = Console.ReadLine();

            Console.Write("Insira seu Email: ");
            cliente.Email = Console.ReadLine();

            //Imprimindo 
            Console.WriteLine("\nDADOS DO CLIENTE:");
            Console.WriteLine("ID.......:" + cliente.Id);
            Console.WriteLine("NOME.....:" + cliente.Nome);
            Console.WriteLine("CPF......:" + cliente.Cpf);
            Console.WriteLine("EMAIL....:" + cliente.Email);

            var clienteRepository = new ClienteRepository();
            clienteRepository.ExpotarDados(cliente);

            //pausa o terminal
            Console.ReadKey();
        }
    }
}