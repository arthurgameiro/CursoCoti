using ProjetoAula01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula01.Repositories
{
    public class ClienteRepository
    {
        //Método para gravar os dados de um cliente em arquivo
        public void ExpotarDados(Cliente cliente) 
        {
            var write = new StreamWriter("c:\\temp\\clientes.txt", true);
            write.WriteLine("\nCLIENTE:");
            write.WriteLine(cliente.Id);
            write.WriteLine(cliente.Nome);
            write.WriteLine(cliente.Cpf);
            write.WriteLine(cliente.Email);
            write.Close();
        }
    }
}
