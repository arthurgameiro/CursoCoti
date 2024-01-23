using ProjetoAula03.Entities;
using ProjetoAula03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Controllers
{
    public class ProfissionalController
    {
        public void CadastrarProfissional()
        {
			try
			{
				Console.WriteLine("\n CADASTRO DE PROFISSIONAL\n");
				var profissional = new Profissional();
				profissional.Id = Guid.NewGuid();

                Console.Write("INFORME O NOME................: ");
				profissional.Nome = Console.ReadLine();

                Console.Write("INFORME O CPF................: ");
                profissional.Cpf = Console.ReadLine();

                Console.Write("INFORME O Nº REGISTRO........: ");
                profissional.NumRegistro = Console.ReadLine();

                Console.Write("INFORME O SALÁRIO............: ");
                profissional.Salario = decimal.Parse(Console.ReadLine());

                #region Atribuindo dados da empresa

                profissional.Empresa = new Empresa();
                profissional.Empresa.Id = Guid.NewGuid();

                Console.Write("INFORME O RAZAO SOCIAL........: ");
                profissional.Empresa.RazaoSocial = Console.ReadLine();

                Console.Write("INFORME O NOME FANTASIA.......: ");
                profissional.Empresa.NomeFantasia = Console.ReadLine();

                Console.Write("INFORME O CNPJ................: ");
                profissional.Empresa.Cnpj = Console.ReadLine();

                #endregion

                //Gerar os dados em XML.
                var profissionalRepositoryXml = new ProfissionalRepositoryXml();
                profissionalRepositoryXml.Exportar(profissional);

                //Gerar os dados em Json.
                var profissionalRepositoryJson = new ProfissionalRepositoryJsonApi();
                profissionalRepositoryJson.Exportar(profissional);

                //Gerar os dados em Json.
                var profissionalRepositoryJson2 = new ProfissionalRepositoryJsonSemApi();
                profissionalRepositoryJson2.Exportar(profissional);

                Console.WriteLine("\nDADOS GRAVADOS COM SUCESSO.");

            }
            catch (Exception e)
			{
                Console.WriteLine("\n FALHA AO CADASTRAR ");
                Console.WriteLine(e.Message);
			}
        }
    }
}