using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAula05Exercicio.Entities;
using Dapper;

namespace ProjetoAula05Exercicio.Repositories
{
    public class FuncionarioRepository
    {
        private string _connectionString => "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = DBAula05Exercicio; Integrated Security = True;";

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Execute("SP_InserirFuncionario", new
                    {
                        @NOME = funcionario.Nome,
                        @MATRICULA = funcionario.Matricula,
                        @CPF = funcionario.Cpf
                    },
                    commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir funcionário: {ex.Message}");
                throw;
            }
        }


        public void Alterar(Funcionario funcionario)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Execute("SP_AlterarFuncionario", new
                    {
                        Id = funcionario.Id,
                        Nome = funcionario.Nome,
                        Matricula = funcionario.Matricula,
                        Cpf = funcionario.Cpf
                    },
                    commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alterar funcionário: {ex.Message}");
                throw;
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Execute("SP_ExcluirFuncionario", new { Id = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir funcionário: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Funcionario> ConsultarTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>("SELECT * FROM Funcionario");
            }
        }

        public IEnumerable<Funcionario> ConsultarPorNome(string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>("SELECT * FROM Funcionario WHERE Nome LIKE @Nome", new { Nome = $"%{nome}%" });
            }
        }

        public Funcionario ConsultarPorId(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Funcionario>("SELECT * FROM Funcionario WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
