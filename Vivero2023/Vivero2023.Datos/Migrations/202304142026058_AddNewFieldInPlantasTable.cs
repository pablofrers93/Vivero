namespace Vivero2023.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldInPlantasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plantas", "PrecioCosto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            Sql("UPDATE Plantas SET PrecioCosto = Precio*0.5");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plantas", "PrecioCosto");
        }
    }
}
