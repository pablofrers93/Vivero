using System;
using System.Collections.Generic;

namespace Vivero2023.Entidades
{
    public class TipoDePlanta
    {
        public TipoDePlanta()
        {
            Plantas = new HashSet<Planta>();
        }
        public int TipoDePlantaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Planta> Plantas { get; set; }
    }
}
