namespace DesafioMercadoFresh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.OrderProducts", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderProducts", new[] { "Product_ProductId" });
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            DropTable("dbo.OrderProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Product_ProductId });
            
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductOrder", "OrderId", "dbo.Orders");
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropIndex("dbo.ProductOrder", new[] { "OrderId" });
            DropTable("dbo.ProductOrder");
            CreateIndex("dbo.OrderProducts", "Product_ProductId");
            CreateIndex("dbo.OrderProducts", "Order_OrderId");
            AddForeignKey("dbo.OrderProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
