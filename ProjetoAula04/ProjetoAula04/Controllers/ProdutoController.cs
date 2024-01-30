using ProjetoAula04.Entities;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    public class ProdutoController
    {
		public void CadastrarProduto()
		{
            try
            {
                Console.WriteLine("\nCADASTRO DE PRODUTO\n");

                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    DataHoraCadastro = DateTime.Now
                };

                Console.Write("\nINFORME O NOME DO PRODUTO..: ");
                produto.Nome = Console.ReadLine();

                Console.Write("\nINFORME O PREÇO DO PRODUTO..: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("\nINFORME A QUANTIDADE DO PRODUTO..: ");
                produto.Quantidade = int.Parse(Console.ReadLine());


                Console.WriteLine("\nONDE DESEJA GRAVAR OS DADOS? ");
                Console.Write("INFORME (1)SQL OU (2)JSON ou (3)AMBOS:");

                var opcao = int.Parse(Console.ReadLine());

                var produtoRepositorySql = new ProdutoRepositorySql();
                var produtoRepositoryJson = new ProdutoRepositoryJson();

                switch (opcao)
                {
                    case 1:
                        //var produtoRepositorySql = new ProdutoRepositorySql();
                        produtoRepositorySql.Exportar(produto);
                        Console.WriteLine("DADOS GRAVADOS COM SUCESSO EM BANCO DE DADOS.");
                        break;
                    case 2:
                        //var produtoRepositoryJson = new ProdutoRepositoryJson();
                        produtoRepositoryJson.Exportar(produto);
                        Console.WriteLine("DADOS GRAVADOS COM SUCESSO EM JSON.");
                        break;
                    case 3:
                        produtoRepositorySql.Exportar(produto);
                        Console.WriteLine("DADOS GRAVADOS COM SUCESSO EM BANCO DE DADOS.");
                        produtoRepositoryJson.Exportar(produto);
                        Console.WriteLine("DADOS GRAVADOS COM SUCESSO EM JSON.");
                        break;
                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nOCORREU UM ERRO DE VALIDAÇÃO:");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO CADASTRAR PRODUTO:");
                Console.WriteLine(e.Message);
            }
        }
    }
}