using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Entities
{
    public class Categoria
    {
        #region Atributos
        private Guid? _id;
        private string? _nome;
        private List<Produto>? _produtos;
        #endregion

        #region Metodos
        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public List<Produto>? Produtos { get => _produtos; set => _produtos = value; }
        #endregion
    }
}
