using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class Animais
    {
        public Animais()
        {
            ConsultasVeterinaria = new HashSet<ConsultasVeterinarias>();
        }

        public int Id { get; set; }
        public int? EspecieId { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? HistoricoSaude { get; set; }

        public virtual Especies? Especie { get; set; }
        public virtual ICollection<ConsultasVeterinarias> ConsultasVeterinaria { get; set; }
    }
}
