namespace Vivero2023.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePrecioFieldNameInPlantasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plantas", "PrecioVenta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            Sql("UPDATE Plantas SET PrecioVenta = Precio");
            DropColumn("dbo.Plantas", "Precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plantas", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            Sql("UPDATE Plantas SET Precio = PrecioVenta");
            DropColumn("dbo.Plantas", "PrecioVenta");
        }
    }
}
