namespace DesafioMercadoFresh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleQnty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductOrder", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductOrder", "Quantity", c => c.Int(nullable: false));
        }
    }
}
