namespace crud_wpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_m_Supplier", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Supplier_Id", "dbo.tb_m_Supplier");
            DropIndex("dbo.Items", new[] { "Supplier_Id" });
            DropTable("dbo.Items");
        }
    }
}
