using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula04.Entities
{
    /// <summary>
    /// Classe de modelo de entidade
    /// </summary>
    public class Produto
    {
        #region Atributos

        private Guid? _id;
        private string? _nome;
        private decimal? _preco;
        private int? _quantidade;
        private DateTime? _dataHoraCadastro;

        #endregion

        #region Propriedades

        public Guid? Id
        {
            set => _id = value;
            get => _id;
        }

        public string? Nome
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe o nome do produto.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü0-9\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 8 a 100 caracteres.");

                _nome = value;
            }
            get => _nome;
        }

        public decimal? Preco
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Por favor, informe um preço maior que zero.");
                _preco = value;
            }
            get => _preco;
        }

        public int? Quantidade
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Por favor, informe uma quantidade maior ou igual a zero.");
                _quantidade = value;
            }
            get => _quantidade;
        }

        public DateTime? DataHoraCadastro 
        { 
            set => _dataHoraCadastro = value;
            get => _dataHoraCadastro;
        }

        #endregion
    }
}