using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Controllers
{
    /// <summary>
    /// Classe de controle para entrada de dados de funcionário
    /// </summary>
    public class FuncionarioController
    {
        /// <summary>
        /// Método para realizar o cadastro de um funcionário
        /// </summary>
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO:\n");

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();

                Console.Write("INFORME O NOME..............: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("INFORME A MATRÍCULA.........: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("INFORME A DATA DE ADMISSÃO..: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("INFORME O SALÁRIO...........: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ExportarDados(funcionario);

                Console.WriteLine("\nDADOS GRAVADOS COM SUCESSO!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro no preenchimento dos dados:");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nOcorreu uma falha:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Write("\nDESEJA REPETIR O PROCESSO? (S,N): ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear(); //limpar o console
                    CadastrarFuncionario(); //recursividade
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }
        }
    }
}
