using Newtonsoft.Json;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Classe para implementar um repositorio de produto em arquivo JSON
    /// </summary>
    public class ProdutoRepositoryJson : IProdutoRepository
    {
        public void Exportar(Produto produto)
        {
            //serializar os dados do produto em JSON
            var json = JsonConvert.SerializeObject(produto, Formatting.Indented);

            //gravar os dados em um arquivo
            using (var streamWriter = new StreamWriter("c:\\temp\\produtos.json", true))
            {
                streamWriter.WriteLine(json);
            }
        }
    }
}
