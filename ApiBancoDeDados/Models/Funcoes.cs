using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class Funcoes
    {
        public Funcoes()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
