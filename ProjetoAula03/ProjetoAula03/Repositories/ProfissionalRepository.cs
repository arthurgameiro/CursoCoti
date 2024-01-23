using ProjetoAula03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Repositories
{
    public abstract class ProfissionalRepository
    {
        public abstract void Exportar(Profissional profissional);
    }
}