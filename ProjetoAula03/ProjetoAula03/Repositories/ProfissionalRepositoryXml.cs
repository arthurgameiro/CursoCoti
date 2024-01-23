using ProjetoAula03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula03.Repositories
{
    public class ProfissionalRepositoryXml : ProfissionalRepository
    {
        public override void Exportar(Profissional profissional) 
        { 
            if (profissional == null)
            {
                // Adicione a lógica de tratamento para o caso de profissional ser nulo
                Console.WriteLine("Profissional é nulo. Não é possível exportar.");
                return;
            }

            // Nome do arquivo XML para exportar os dados do profissional
            string nomeArquivo = "c:\\temp\\profissional.xml";

            // Criação de um XmlSerializer para o tipo Profissional
            XmlSerializer serializer = new XmlSerializer(typeof(Profissional));

            // Escreve os dados do profissional em um arquivo XML
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                serializer.Serialize(writer, profissional);
            }

            Console.WriteLine($"Dados do profissional exportados para {nomeArquivo}");
        }
    }
}
