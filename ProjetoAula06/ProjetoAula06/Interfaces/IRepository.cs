using ProjetoAula06.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Interfaces
{
    //interface genérica
    public interface IRepository<T>
    {
        void Inserir(T obj);

        void Alterar(T obj);

        void Excluir(T obj);

        List<T> ObterTodos();

        T? ObterPorId(Guid id);
    }
}