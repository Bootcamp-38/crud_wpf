namespace crud_wpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelsupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_m_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_m_Supplier");
        }
    }
}
