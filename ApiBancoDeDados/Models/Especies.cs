using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class Especies
    {
        public Especies()
        {
            Animais = new HashSet<Animais>();
        }

        public int Id { get; set; }
        public int? IdHabitat { get; set; }
        public string? NomeCientifico { get; set; }
        public string? Alimentacao { get; set; }
        public decimal? ExpectativaDeVidaEmMeses { get; set; }

        public virtual Habitats? IdHabitatNavigation { get; set; }
        public virtual ICollection<Animais> Animais { get; set; }
    }
}
