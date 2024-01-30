using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using ProjetoAula05.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    public class ClienteController
    {
        public void CadastrarCliente()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE CLIENTE:\n");

                Console.Write("INFORME O CPF...............: ");
                var cpf = Console.ReadLine();

                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorCpf(cpf);

                //verificar se o cliente já existe
                if (cliente != null)
                {
                    Console.WriteLine("\nJÁ EXISTE UM CLIENTE CADASTRADO COM O CPF INFORMADO:");
                    Console.WriteLine("ID.....: " + cliente.Id);
                    Console.WriteLine("NOME...: " + cliente.Nome);
                    Console.WriteLine("CPF....: " + cliente.Cpf);
                }
                else
                {
                    cliente = new Cliente();
                    cliente.Endereco = new Endereco();
                    cliente.Cpf = cpf;

                    Console.Write("INFORME O NOME..............: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("INFORME O CEP...............: ");
                    var cep = Console.ReadLine();

                    //buscar o endereço baseado no CEP:
                    var viaCepService = new ViaCepService();
                    var enderecoDto = viaCepService.ObterEndereco(cep);

                    //capturar o endereço
                    cliente.Endereco.Logradouro = enderecoDto?.logradouro;
                    cliente.Endereco.Bairro = enderecoDto?.bairro;
                    cliente.Endereco.Cidade = enderecoDto?.localidade;
                    cliente.Endereco.Estado = enderecoDto?.uf;
                    cliente.Endereco.Cep = enderecoDto?.cep;

                    Console.Write("INFORME O NUMERO............: ");
                    cliente.Endereco.Numero = Console.ReadLine();

                    Console.Write("INFORME O COMPLEMENTO.......: ");
                    cliente.Endereco.Complemento = Console.ReadLine();

                    //gravar no banco de dados
                    clienteRepository.Inserir(cliente);

                    Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERRO: " + e.Message);
            }
        }
    }
}