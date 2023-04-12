using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero2023.Entidades;

namespace Vivero2023.Datos.EntityTypeConfiguration
{
    public class TipoDeEnvaseEntityTypeConfiguration:EntityTypeConfiguration<TipoDeEnvase>
    {
        public TipoDeEnvaseEntityTypeConfiguration()
        {
            ToTable("TiposDeEnvases");
            HasKey(te => te.TipoDeEnvaseId);
            Property(te => te.Descripcion).IsRequired().HasMaxLength(50);
            HasIndex(te => te.Descripcion).IsUnique().HasName("IX_TiposDeEnvase_Descripcion");
        }
    }
}
