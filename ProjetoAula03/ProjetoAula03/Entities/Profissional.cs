using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Entities
{
    public class Profissional: Pessoa
    {
        #region Atributos
        private string? _numRegistro;
        private Decimal? _salario;
        private Empresa? _empresa;
        #endregion

        #region Propriedades
        public string? NumRegistro { get => _numRegistro; set => _numRegistro = value; }
        public Decimal? Salario { get => _salario; set => _salario = value; }
        public Empresa? Empresa { get => _empresa; set => _empresa = value; }
        #endregion
    }
}
