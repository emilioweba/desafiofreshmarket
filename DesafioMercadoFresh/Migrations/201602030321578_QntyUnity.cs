namespace DesafioMercadoFresh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QntyUnity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrder", "QntyUnity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrder", "QntyUnity");
        }
    }
}
