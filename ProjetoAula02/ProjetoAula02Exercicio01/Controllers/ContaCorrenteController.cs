using ProjetoAula02Exercicio01.Entities;
using ProjetoAula02Exercicio01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02Exercicio01.Controllers
{
    public class ContaCorrenteController
    {
        public void CadastrarContaCorrente()
        {
            try
            {
                Console.WriteLine("Cadastro de Conta Corrente");

                ContaCorrente contaCorrente = new ContaCorrente();
                contaCorrente.Id = Guid.NewGuid();

                // Entrada de dados
                Console.Write("Informe o nome do titular: ");
                contaCorrente.NomeTitular = Console.ReadLine();

                Console.Write("Informe o número da conta: ");
                contaCorrente.NumeroConta = Console.ReadLine();

                Console.Write("Informe o saldo: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal saldo))
                {
                    contaCorrente.Saldo = saldo;
                }
                else
                {
                    Console.WriteLine("Valor inválido para o saldo.");
                    return;
                }

                Console.Write("Informe a taxa de manutenção: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal taxaManutencao))
                {
                    contaCorrente.TaxaManutencao = taxaManutencao;
                }
                else
                {
                    Console.WriteLine("Valor inválido para a taxa de manutenção.");
                    return;
                }

                Console.Write("Informe o limite do cheque especial: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal limiteChequeEspecial))
                {
                    contaCorrente.LimiteChequeEspecial = limiteChequeEspecial;
                }
                else
                {
                    Console.WriteLine("Valor inválido para o limite do cheque especial.");
                    return;
                }

                // Exibindo informações
                Console.WriteLine("\nInformações da Conta Corrente:");
                Console.WriteLine($"ID da Conta: {contaCorrente.Id}");
                Console.WriteLine($"Nome do Titular: {contaCorrente.NomeTitular}");
                Console.WriteLine($"Número da Conta: {contaCorrente.NumeroConta}");
                Console.WriteLine($"Saldo: {contaCorrente.Saldo:C}");
                Console.WriteLine($"Taxa de Manutenção: {contaCorrente.TaxaManutencao:C}");
                Console.WriteLine($"Limite do Cheque Especial: {contaCorrente.LimiteChequeEspecial:C}");

                var contaCorrenteRepository = new ContaCorrenteRepository();
                contaCorrenteRepository.ExportarDados(contaCorrente);

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
                    CadastrarContaCorrente(); //recursividade
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }
        }
    }
}
