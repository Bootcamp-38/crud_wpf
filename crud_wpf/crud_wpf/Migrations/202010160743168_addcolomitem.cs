namespace crud_wpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolomitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Price");
            DropColumn("dbo.Items", "Stock");
        }
    }
}
