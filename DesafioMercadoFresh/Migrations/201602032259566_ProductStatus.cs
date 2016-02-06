namespace DesafioMercadoFresh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrder", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrder", "Status");
        }
    }
}
