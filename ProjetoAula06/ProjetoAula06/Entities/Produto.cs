using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Entities
{
    public class Produto
    {
        #region Atributos
        private Guid? _id;
        private string? _nome;
        private decimal _preco;
        private int? _quantidade;
        private Categoria? _categoria;

        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public decimal Preco { get => _preco; set => _preco = value; }
        public int? Quantidade { get => _quantidade; set => _quantidade = value; }
        internal Categoria? Categoria { get => _categoria; set => _categoria = value; }
        #endregion
    }
}
