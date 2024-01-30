using Dapper;
using Newtonsoft.Json;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Classe para implementar um repositorio de produto em arquivo JSON
    /// </summary>
    public class ProdutoRepositorySql : IProdutoRepository
    {
        public void Exportar(Produto produto)
        {
            var Conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBAula04;Integrated Security=True;";
            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(Conn))
            {
                //executando uma query SQL para gravar um produto na tabela
                connection.Execute(@"
                    INSERT INTO PRODUTO(ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO)
                    VALUES(@Id, @Nome, @Preco, @Quantidade, @DataHoraCadastro)
                ", new
                {
                    @Id = produto.Id,
                    @Nome = produto.Nome,
                    @Preco = produto.Preco,
                    @Quantidade= produto.Quantidade,
                    @DataHoraCadastro = produto.DataHoraCadastro
                });
            }
        }
    }
}
