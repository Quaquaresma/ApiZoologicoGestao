using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class Habitats
    {
        public Habitats()
        {
            Especies = new HashSet<Especies>();
        }

        public int Id { get; set; }
        public string? TipoAmbiente { get; set; }
        public int? Temperatura { get; set; }
        public decimal? FrequenciaLimpezaEmDias { get; set; }
        public string? CondicoesClimaticas { get; set; }

        public virtual ICollection<Especies> Especies { get; set; }
    }
}
