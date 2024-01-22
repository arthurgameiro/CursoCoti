using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//localização da classe dentro do  projeto
namespace ProjetoAula01.Entities
{
    //definição da classe
    public class Cliente
    {
        //Atributos
        private Guid? _id;
        private string? _nome;
        private string? _cpf;
        private string? _email;

        public Guid? Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public string? Nome { get => _nome; set => _nome = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Email { get => _email; set => _email = value; }
    }
}