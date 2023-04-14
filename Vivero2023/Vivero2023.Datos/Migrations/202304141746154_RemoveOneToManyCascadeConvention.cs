namespace Vivero2023.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOneToManyCascadeConvention : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases");
            AddForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases", "TipoDeEnvaseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases");
            AddForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases", "TipoDeEnvaseId", cascadeDelete: true);
        }
    }
}
