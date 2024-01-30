using Dapper;
using ProjetoAula06.Entities;
using ProjetoAula06.Interfaces;
using ProjetoAula06.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Repositories
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        public void Inserir(Categoria obj)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute(
                @"
                    INSERT INTO CATEGORIA(ID, NOME)
                    VALUES(@ID, @NOME)
                ", new
                {
                    @ID = obj.Id,
                    @NOME = obj.Nome
                });
            }
        }

        public void Alterar(Categoria obj)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute(
                @"
                    UPDATE CATEGORIA SET NOME = @NOME
                    WHERE ID = @ID
                ", new
                {
                    @ID = obj.Id,
                    @NOME = obj.Nome
                });
            }
        }

        public void Excluir(Categoria obj)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute(
                @"
                    DELETE FROM CATEGORIA WHERE ID = @ID
                ", new
                {
                    @ID = obj.Id
                });
            }
        }

        public List<Categoria> ObterTodos()
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<Categoria>(
                    @"
                        SELECT ID, NOME FROM CATEGORIA
                        ORDER BY NOME
                    ").ToList();
            }
        }

        public Categoria? ObterPorId(Guid id)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<Categoria>(
                    @"
                        SELECT ID, NOME FROM CATEGORIA
                        WHERE ID = @ID
                    ", new { @ID = id })
                    .FirstOrDefault();
            }
        }
    }
}