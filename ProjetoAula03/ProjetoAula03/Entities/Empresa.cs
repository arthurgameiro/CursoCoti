using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Entities
{
    public class Empresa
    {
        #region Atributos

        private Guid? _id;
        private string? _nomeFantasia;
        private string? _razaoSocial;
        private string? _cnpj;

        #endregion

        #region Propriedades

        public Guid? Id { get => _id; set => _id = value; }
        public string? NomeFantasia { get => _nomeFantasia; set => _nomeFantasia = value; }
        public string? RazaoSocial { get => _razaoSocial; set => _razaoSocial = value; }
        public string? Cnpj { get => _cnpj; set => _cnpj = value; }

        #endregion
    }
}

