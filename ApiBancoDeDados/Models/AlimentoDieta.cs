using System;
using System.Collections.Generic;

namespace ApiBancoDeDados.Models
{
    public partial class AlimentoDieta
    {
        public int? IdDieta { get; set; }
        public int? IdAlimento { get; set; }

        public virtual Alimentos? IdAlimentoNavigation { get; set; }
        public virtual Dieta? IdDietaNavigation { get; set; }
    }
}
