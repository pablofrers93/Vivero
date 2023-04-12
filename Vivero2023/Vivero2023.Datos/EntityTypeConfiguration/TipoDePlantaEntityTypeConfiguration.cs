 using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero2023.Entidades;

namespace Vivero2023.Datos.EntityTypeConfiguration
{
    public class TipoDePlantaEntityTypeConfiguration:EntityTypeConfiguration<TipoDePlanta>
    {
        public TipoDePlantaEntityTypeConfiguration()
        {
            ToTable("TiposDePlantas");
            HasKey(tp => tp.TipoDePlantaId);
            Property(tp => tp.Descripcion).IsRequired().HasMaxLength(50);
            HasMany(e => e.Plantas)
              .WithRequired(e => e.TipoDePlanta)
              .WillCascadeOnDelete(false); 
        }
    }
}
