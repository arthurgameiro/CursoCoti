using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    public interface IProdutoRepository
    {
        void Exportar(Produto produto);
    }
}