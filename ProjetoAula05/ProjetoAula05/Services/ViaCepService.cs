using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Services
{
    public class ViaCepService
    {
        public EnderecoDto? ObterEndereco(string cep)
        {
            //const site = "https://viacep.com.br/ws/"
            var result = new HttpClient().GetAsync("https://viacep.com.br/ws/"+ cep + "/json/").Result;


            return JsonConvert.DeserializeObject<EnderecoDto>
                (result.Content.ReadAsStringAsync().Result);
        }
    }

    public class EnderecoDto
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }
}
