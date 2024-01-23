using ProjetoAula03.Entities;
using System.IO;
using System.Text.Json;

namespace ProjetoAula03.Repositories
{
    public class ProfissionalRepositoryJsonSemApi : ProfissionalRepository
    {
        public override void Exportar(Profissional profissional)
        {
            if (profissional == null)
            {
                // Adicione a lógica de tratamento para o caso de profissional ser nulo
                Console.WriteLine("Profissional é nulo. Não é possível exportar.");
                return;
            }

            // Nome do arquivo JSON para exportar os dados do profissional
            string nomeArquivo = "c:\\temp\\profissional2.json";

            // Serializa o objeto profissional para uma string JSON
            string json = JsonSerializer.Serialize(profissional);

            // Escreve a string JSON em um arquivo
            File.WriteAllText(nomeArquivo, json);

            Console.WriteLine($"Dados do profissional exportados para {nomeArquivo}");
        }
    }
}