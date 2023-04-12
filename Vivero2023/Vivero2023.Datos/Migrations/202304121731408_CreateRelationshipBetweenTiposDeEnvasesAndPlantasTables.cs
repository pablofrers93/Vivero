namespace Vivero2023.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenTiposDeEnvasesAndPlantasTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plantas", "TipoDeEnvaseId", c => c.Int(nullable: false));
            Sql("UPDATE Plantas set TipoDeEnvaseId = 1");
            CreateIndex("dbo.Plantas", "TipoDeEnvaseId");
            AddForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases", "TipoDeEnvaseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantas", "TipoDeEnvaseId", "dbo.TiposDeEnvases");
            DropIndex("dbo.Plantas", new[] { "TipoDeEnvaseId" });
            DropColumn("dbo.Plantas", "TipoDeEnvaseId");
        }
    }
}
