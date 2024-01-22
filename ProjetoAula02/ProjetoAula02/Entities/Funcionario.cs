using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados de Funcionario
    /// </summary>
    public class Funcionario: Pessoa
    {
        #region Atributos
        private string? _matricula;
        private DateTime? _dataAdmissao;
        private decimal? _salario;

        #endregion

        #region Propriedades
        public string? Matricula 
        {
            set
            {
                //Não permitir valor vazio ou somente espaços
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe a matricula.");

                var regex = new Regex("^[A-Z0-9]{4,10}$");

                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma matricula válida de 4 a 10 caracteres.");

                _matricula = value;
            }
            get => _matricula;

        }
        public DateTime? DataAdmissao { get => _dataAdmissao; set => _dataAdmissao = value; }

        public decimal? Salario
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O salário deve ser maior do que zero.");

                _salario = value;
            }
            get => _salario;
        }

        #endregion
    }
}
