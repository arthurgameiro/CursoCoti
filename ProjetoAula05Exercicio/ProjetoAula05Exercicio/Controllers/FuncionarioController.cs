using ProjetoAula05Exercicio.Entities;
using ProjetoAula05Exercicio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ProjetoAula05Exercicio.Controllers
{
    public class FuncionarioController
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        public void Executar()
        {
            while (true)
            {
                Console.WriteLine("...::: AULA 05 - EXERCICIO:::...\n\n");

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Cadastrar Funcionário");
                Console.WriteLine("2. Consultar Todos Funcionários");
                Console.WriteLine("3. Consultar Funcionário por Nome");
                Console.WriteLine("4. Alterar Funcionário");
                Console.WriteLine("5. Excluir Funcionário");
                Console.WriteLine("6. Sair\n\n");


                Console.Write("Digite a opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarFuncionario();
                        break;
                    case "2":
                        ConsultarTodosFuncionarios();
                        break;
                    case "3":
                        ConsultarFuncionarioPorNome();
                        break;
                    case "4":
                        AlterarFuncionario();
                        break;
                    case "5":
                        ExcluirFuncionario();
                        break;
                    case "6":
                        return; // Encerra o programa
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void CadastrarFuncionario()
        {
            Console.WriteLine("Cadastrar Funcionário");

            // Solicitar informações do usuário
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            // Criar um objeto Funcionario com as informações fornecidas
            var novoFuncionario = new Funcionario
            {
                Nome = nome,
                Matricula = matricula,
                Cpf = cpf
            };

            // Chamar o método Inserir do repository para cadastrar o funcionário
            _funcionarioRepository.Inserir(novoFuncionario);

            Console.WriteLine("\nFuncionário cadastrado com sucesso!");
        }

        private void ConsultarTodosFuncionarios()
        {
            Console.WriteLine("Consultar Todos Funcionários");

            // Chamar o método ConsultarTodos do repository
            var funcionarios = _funcionarioRepository.ConsultarTodos();

            // Exibir os funcionários no console
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"Id: {funcionario.Id}, Nome: {funcionario.Nome}, Matrícula: {funcionario.Matricula}, CPF: {funcionario.Cpf}");
            }
        }

        private void ConsultarFuncionarioPorNome()
        {
            Console.WriteLine("Consultar Funcionário por Nome");

            // Solicitar o nome para pesquisa
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            // Chamar o método ConsultarPorNome do repository
            var funcionarios = _funcionarioRepository.ConsultarPorNome(nome);

            // Exibir os funcionários no console
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"Id: {funcionario.Id}, Nome: {funcionario.Nome}, Matrícula: {funcionario.Matricula}, CPF: {funcionario.Cpf}");
            }
        }

        private void AlterarFuncionario()
        {
            Console.WriteLine("Alterar Funcionário");

            // Solicitar o ID do funcionário a ser alterado
            Console.Write("Digite o ID do funcionário: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                // Chamar o método ConsultarPorId do repository para obter informações atuais do funcionário
                var funcionario = _funcionarioRepository.ConsultarPorId(id);

                if (funcionario != null)
                {
                    // Solicitar novas informações do usuário
                    Console.Write("Novo Nome: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("Nova Matrícula: ");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("Novo CPF: ");
                    funcionario.Cpf = Console.ReadLine();

                    // Chamar o método Alterar do repository para aplicar as alterações
                    _funcionarioRepository.Alterar(funcionario);

                    Console.WriteLine("Funcionário alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void ExcluirFuncionario()
        {
            Console.WriteLine("Excluir Funcionário");

            // Solicitar o ID do funcionário a ser excluído
            Console.Write("Digite o ID do funcionário: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                // Chamar o método ConsultarPorId do repository para obter informações do funcionário
                var funcionario = _funcionarioRepository.ConsultarPorId(id);

                if (funcionario != null)
                {
                    // Confirmar a exclusão
                    Console.WriteLine($"Tem certeza que deseja excluir o funcionário {funcionario.Nome}? (S/N)");
                    if (Console.ReadLine()?.ToUpper() == "S")
                    {
                        // Chamar o método Excluir do repository para excluir o funcionário
                        _funcionarioRepository.Excluir(id);
                        Console.WriteLine("Funcionário excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Operação de exclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}