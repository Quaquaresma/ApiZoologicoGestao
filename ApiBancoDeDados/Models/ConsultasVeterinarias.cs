using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class ConsultasVeterinarias
    {
        public int Id { get; set; }
        public int? IdAnimal { get; set; }
        public int? IdFuncionario { get; set; }
        public DateOnly? DataConsulta { get; set; }
        public string? Diagnostico { get; set; }
        public string? Prognostico { get; set; }
        public string? Tratamento { get; set; }

        public virtual Animais? IdAnimalNavigation { get; set; }
        public virtual Funcionarios? IdFuncionarioNavigation { get; set; }
    }
}
