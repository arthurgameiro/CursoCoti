using ProjetoAula02Exercicio01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02Exercicio01.Repositories
{
    public class ContaCorrenteRepository
    {
        private const string CaminhoArquivo = @"c:\temp\contas.txt";

        public void ExportarDados(ContaCorrente contaCorrente)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(CaminhoArquivo, true))
                {
                    writer.WriteLine($"ID: {contaCorrente.Id}");
                    writer.WriteLine($"NomeTitular: {contaCorrente.NomeTitular}");
                    writer.WriteLine($"NumeroConta: {contaCorrente.NumeroConta}");
                    writer.WriteLine($"Saldo: {contaCorrente.Saldo}");
                    writer.WriteLine($"TaxaManutencao: {contaCorrente.TaxaManutencao}");
                    writer.WriteLine($"LimiteChequeEspecial: {contaCorrente.LimiteChequeEspecial}");
                    writer.WriteLine();
                }

                Console.WriteLine("Conta Corrente salva com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao salvar a Conta Corrente: {ex.Message}");
            }
        }
    }
}