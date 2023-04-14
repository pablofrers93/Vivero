using System;
using System.Collections.Generic;


namespace Vivero2023.Entidades
{
    public class Planta
    {
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }

        public int TipoDePlantaId { get; set; }

        public decimal PrecioVenta { get; set; }
        public decimal PrecioCosto { get; set; }

        public int TipoDeEnvaseId { get; set; }
        public virtual TipoDeEnvase  TipoDeEnvase { get; set; }
        public virtual TipoDePlanta TipoDePlanta { get; set; }
    }
}
