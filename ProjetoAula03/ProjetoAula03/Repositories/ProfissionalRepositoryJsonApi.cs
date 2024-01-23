using Newtonsoft.Json;
using ProjetoAula03.Entities;

namespace ProjetoAula03.Repositories
{
    public class ProfissionalRepositoryJsonApi : ProfissionalRepository
    {
        public override void Exportar(Profissional profissional)
        {
            var json = JsonConvert.SerializeObject(profissional, Formatting.Indented);

            // Nome do arquivo JSON para exportar os dados do profissional
            string nomeArquivo = "c:\\temp\\profissional.json";

            //gravar em arquivo
            var streamWrite = new StreamWriter(nomeArquivo);
            streamWrite.Write(json);
            streamWrite.Close();

            Console.WriteLine($"Dados do profissional exportados para {nomeArquivo}");
        }
    }
}