namespace Vivero2023.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTiposDeEnvaseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposDeEnvases",
                c => new
                    {
                        TipoDeEnvaseId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TipoDeEnvaseId)
                .Index(t => t.Descripcion, unique: true, name: "IX_TiposDeEnvase_Descripcion");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Maseta Chica')");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Maseta Mediana')");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Maseta Grande')");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Caja')");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Bolsa')");
            Sql("INSERT INTO TiposDeEnvases VALUES ('Borrame')");

        }

        public override void Down()
        {
            DropIndex("dbo.TiposDeEnvases", "IX_TiposDeEnvase_Descripcion");
            DropTable("dbo.TiposDeEnvases");
        }
    }
}
