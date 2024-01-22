using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//localização da classe dentro do  projeto
namespace ProjetoAula01Exercicios.Entities
{
    //definição da classe
    public class Funcionario
    {
        //Atributos
        private Guid? _idFuncionario;
        private string? _nome;
        private string? _cpf;
        private string? _matricula;
        private DateTime? _dataAdmissao;
        private string? _cargo;
        private decimal? _salario;

        public Guid? IdFuncionario { get => _idFuncionario; set => _idFuncionario = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Matricula { get => _matricula; set => _matricula = value; }
        public DateTime? DataAdmissao { get => _dataAdmissao; set => _dataAdmissao = value; }
        public string? Cargo { get => _cargo; set => _cargo = value; }
        public decimal? Salario { get => _salario; set => _salario = value; }
    }
}