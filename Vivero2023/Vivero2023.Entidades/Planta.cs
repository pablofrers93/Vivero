using System;
using System.Collections.Generic;


namespace Vivero2023.Entidades
{
    public class Planta
    {
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }

        public int TipoDePlantaId { get; set; }

        public decimal Precio { get; set; }

        public virtual TipoDePlanta TipoDePlanta { get; set; }
    }
}
