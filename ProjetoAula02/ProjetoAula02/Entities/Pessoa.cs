using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados de Pessoa
    /// </summary>
    public class Pessoa
    {
        #region Atributos

        private Guid? _id;
        private string? _nome;

        #endregion

        #region Propriedades

        public Guid? Id
        {
            set { _id = value; }
            get => _id;
        }

        public string? Nome
        {
            set
            {
                //Não permitir valor vazio ou somente espaços
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Por favor, informe o nome.");

                //Criando um REGEX para validar o conteúdo do nome
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um nome válido de 8 a 100 caracteres.");

                _nome = value;
            }
            get => _nome;
        }

        #endregion
    }
}
