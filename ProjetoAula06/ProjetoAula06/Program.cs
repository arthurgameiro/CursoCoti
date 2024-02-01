using ProjetoAula06.Controllers;

namespace ProjetoAula06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE PRODUTOS:\n");
            Console.WriteLine("(1) CADASTRAR PRODUTO");
            Console.WriteLine("(2) ATUALIZAR PRODUTO");
            Console.WriteLine("(3) EXCLUIR PRODUTO");
            Console.WriteLine("(4) CONSULTAR PRODUTOS");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = Console.ReadLine();

            var produtoController = new ProdutoController();

            switch (opcao)
            {
                case "1":
                    produtoController.CadastrarProduto();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;
            }
        }
    }
}