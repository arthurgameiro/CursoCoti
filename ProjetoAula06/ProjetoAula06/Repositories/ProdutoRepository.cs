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
    public class ProdutoRepository : IRepository<Produto>
    {
        public void Inserir(Produto obj)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute(
                @"
                    INSERT INTO PRODUTO(ID, NOME, PRECO, QUANTIDADE, CATEGORIA_ID)
                    VALUES(@ID, @NOME, @PRECO, @QUANTIDADE, @CATEGORIA_ID)
                ", new
                {
                    @ID = obj.Id,
                    @NOME = obj.Nome,
                    @PRECO = obj.Preco,
                    @QUANTIDADE = obj.Quantidade,
                    @CATEGORIA_ID = obj.Categoria?.Id
                });
            }
        }

        public void Alterar(Produto obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto obj)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Produto? ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
