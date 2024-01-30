using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula05Exercicio.Entities
{
    public class Funcionario
    {
        #region Atributos

        private Guid? _id;
        private string? _nome;
        private string? _matricula;
        private string? _cpf;

        #endregion

        #region Propriedades

        public Guid? Id { get => _id; set => _id = value; }

        public string? Nome
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe o nome.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{10,150}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 10 a 150 caracteres, contendo apenas letras e espaços.");

                _nome = value;
            }
            get => _nome;
        }

        public string? Matricula
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A matrícula é obrigatória.");

                var regexMatricula = new Regex("^\\d{6}$");
                if (!regexMatricula.IsMatch(value))
                    throw new ArgumentException("A matrícula deve conter exatamente 6 dígitos numéricos.");

                _matricula = value;
            }
            get => _matricula;
        }

        public string? Cpf
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O CPF é obrigatório.");

                var regexCpf = new Regex("^\\d{11}$");
                if (!regexCpf.IsMatch(value))
                    throw new ArgumentException("O CPF deve conter exatamente 11 dígitos numéricos.");

                _cpf = value;
            }
            get => _cpf;
        }

        #endregion
    }
}