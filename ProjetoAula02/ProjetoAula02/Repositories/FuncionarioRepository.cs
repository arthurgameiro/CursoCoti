using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para funcionário
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar os dados do funcionário em arquivo
        /// </summary>
        public void ExportarDados(Funcionario funcionario)
        {
            //abrindo um arquivo para escrita, e se o arquivo já existir então
            //o programa irá adicionar o conteudo ao final do arquivo, sem sobrescrev-lo
            var streamWriter = new StreamWriter("c:\\temp\\funcionarios.txt", true);

            //escrever os dados no arquivo
            streamWriter.WriteLine($"ID DO FUNCIONÁRIO....: {funcionario.Id}");
            streamWriter.WriteLine($"NOME.................: {funcionario.Nome}");
            streamWriter.WriteLine($"MATRICULA............: {funcionario.Matricula}");
            streamWriter.WriteLine($"DATA DE ADMISSÃO.....: {funcionario.DataAdmissao}");
            streamWriter.WriteLine($"SALÁRIO..............: {funcionario.Salario}");

            //fechando o arquivo
            streamWriter.Close();
        }
    }
}

