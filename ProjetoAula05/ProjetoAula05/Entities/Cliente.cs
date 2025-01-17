﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Entities
{
    public class Cliente
    {
        #region Atributos
        private Guid? _id;
        private string? _nome;
        private string? _cpf;
        private Endereco? _endereco;
        #endregion

        #region Propriedades
        public Guid? Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public Endereco Endereco { get => _endereco; set => _endereco = value; }
        #endregion
    }
}