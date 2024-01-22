using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02Exercicio01.Entities
{
    /// <summary>
    /// Classe de modelo de dados da Conta Bancaria
    /// </summary>
    public class ContaBancaria
    {
        #region Atributos

        private Guid? _id;
        private string? _nomeTitular;
        private string? _numeroConta;
        private decimal? _saldo;

        #endregion

        #region Propriedades

        public Guid? Id
        {
            set { _id = value; }
            get => _id;
        }

        public string? NomeTitular
        {
            set
            {
                //Não permitir valor vazio ou somente espaços
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe o nome do titular.");

                //Criando um REGEX para validar o conteúdo do nome
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,50}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um nome válido de 8 a 50 caracteres.");

                _nomeTitular = value;
            }
            get => _nomeTitular;
        }

        public string? NumeroConta
        {
            set
            {
                //Não permitir valor vazio ou somente espaços
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe o numero da conta.");

                //Criando um REGEX para validar o conteúdo do nome
                var regex = new Regex("^[0-9]{12}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um numero de conta válido de 12 caracteres.");

                _numeroConta = value;
            }
            get => _numeroConta;
        }

        public decimal? Saldo
        {
            set
            {
                // Garantir que o saldo seja maior ou igual a zero
                if (value < 0)
                    throw new ArgumentException("O saldo não pode ser negativo.");

                _saldo = value;
            }
            get => _saldo;
        }

        #endregion
    }
}