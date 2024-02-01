using ProjetoAula06.Entities;
using ProjetoAula06.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Controllers
{
    public class ProdutoController
    {
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Categoria = new Categoria()
                };

                Console.Write("NOME DO PRODUTO...........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("PREÇO.....................: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("QUANTIDADE................: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                #region Imprimir as categorias

                var categoriaRepository = new CategoriaRepository();
                var categorias = categoriaRepository.ObterTodos();

                foreach (var item in categorias)
                {
                    Console.WriteLine($"\tID: {item.Id}, NOME: {item.Nome}");
                }

                #endregion

                Console.Write("\nINFORME O ID DA CATEGORIA.: ");
                produto.Categoria.Id = Guid.Parse(Console.ReadLine());

                //gravando o produto no banco de dados
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Inserir(produto);

                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO CADASTRAR PRODUTO:");
                Console.WriteLine(e.Message);
            }
        }

        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\nEDIÇÃO DE PRODUTO:\n");

                Console.Write("INFORME O ID DO PRODUTO...: ");
                var id = Guid.Parse(Console.ReadLine());

                //consultar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                //verificar se o produto foi encontrado
                if (produto != null)
                {
                    Console.Write("NOME DO PRODUTO...........: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("PREÇO.....................: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("QUANTIDADE................: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    //atualizar os dados do produto
                    produtoRepository.Alterar(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nPRODUTO NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO ATUALIZAR PRODUTO:");
                Console.WriteLine(e.Message);
            }
        }

        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

                Console.Write("INFORME O ID DO PRODUTO...: ");
                var id = Guid.Parse(Console.ReadLine());

                //consultar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                //verificar se o produto foi encontrado
                if (produto != null)
                {
                    //excluir o produto
                    produtoRepository.Excluir(produto);

                    Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nPRODUTO NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO EXCLUIR PRODUTO:");
                Console.WriteLine(e.Message);
            }
        }
    }
}