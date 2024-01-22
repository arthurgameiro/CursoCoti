namespace ProjetoAula02Exercicio01.Entities
{
    /// <summary>
    /// Classe de modelo de dados da ContaCorrente
    /// </summary>
    public class ContaCorrente : ContaBancaria
    {
        #region Atributos

        private decimal? _taxaManutencao;
        private decimal? _limiteChequeEspecial;

        #endregion

        #region Propriedades

        public decimal? TaxaManutencao
        {
            set
            {
                // Garantir que a taxa de manutenção seja maior ou igual a zero
                if (value < 0)
                    throw new ArgumentException("A taxa de manutenção não pode ser negativa.");

                _taxaManutencao = value;
            }
            get => _taxaManutencao;
        }

        public decimal? LimiteChequeEspecial
        {
            set
            {
                // Garantir que o limite do cheque especial seja maior ou igual a zero
                if (value < 0)
                    throw new ArgumentException("O limite do cheque especial não pode ser negativo.");

                _limiteChequeEspecial = value;
            }
            get => _limiteChequeEspecial;
        }

        #endregion
    }
}
