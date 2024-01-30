using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06.Settings
{
    public class AppSettings
    {
        /// <summary>
        /// Propriedade estática da classe para retornar
        /// uma connectionstring de banco de dados
        /// </summary>
        public static string ConnectionString
            => @"Data Source=(localdb)\\MSSQLLocalDB;
                Initial Catalog=DBAula06;
                Integrated Security=True;";
    }
}
