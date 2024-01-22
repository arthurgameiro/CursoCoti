using ProjetoAula01Exercicios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula01Exercicios.Repositories
{
    public class FuncionarioRepository
    {
        //Método para gravar os dados de um funcionario em arquivo
        public void ExpotarDados(Funcionario funcionario) 
        {
            var write = new StreamWriter("c:\\temp\\funcionario.txt", true);
            write.WriteLine("\nFuncionario:");
            write.WriteLine(funcionario.IdFuncionario);
            write.WriteLine(funcionario.Cpf);
            write.WriteLine(funcionario.Matricula);
            write.WriteLine(funcionario.DataAdmissao);
            write.WriteLine(funcionario.Cargo);
            write.WriteLine(funcionario.Salario);
            write.Close();
        }
    }
}
