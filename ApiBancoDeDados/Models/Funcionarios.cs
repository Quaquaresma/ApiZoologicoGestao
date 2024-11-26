using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            ConsultasVeterinaria = new HashSet<ConsultasVeterinarias>();
        }

        public int Id { get; set; }
        public int? IdFuncao { get; set; }
        public decimal? Salario { get; set; }
        public string? Escala { get; set; }
        public DateOnly? DataNascimento { get; set; }

        public virtual Funcoes? IdFuncaoNavigation { get; set; }
        public virtual ICollection<ConsultasVeterinarias> ConsultasVeterinaria { get; set; }
    }
}
