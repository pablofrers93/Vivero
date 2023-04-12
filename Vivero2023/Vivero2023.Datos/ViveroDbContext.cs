using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Vivero2023.Datos.EntityTypeConfiguration;
using Vivero2023.Entidades;

namespace Vivero2023.Datos
{
    public class ViveroDbContext : DbContext
    {
        public ViveroDbContext()
            : base("name=ViveroDbContext")
        {
        }

        public virtual DbSet<Planta> Plantas { get; set; }
        public virtual DbSet<TipoDePlanta> TiposDePlantas { get; set; }
        public virtual DbSet<TipoDeEnvase> TiposDeEnvases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TipoDePlantaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PlantaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TipoDeEnvaseEntityTypeConfiguration());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();    
        }
    }
}
