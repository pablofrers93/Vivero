using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero2023.Entidades;

namespace Vivero2023.Datos.EntityTypeConfiguration
{
    public class PlantaEntityTypeConfiguration:EntityTypeConfiguration<Planta>
    {
        public PlantaEntityTypeConfiguration()
        {
            ToTable("Plantas");
            HasKey(p => p.PlantaId);
            Property(p => p.Descripcion).IsRequired().HasMaxLength(100);
        }
    }
}
