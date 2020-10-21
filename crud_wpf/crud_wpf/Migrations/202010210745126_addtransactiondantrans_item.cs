namespace crud_wpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtransactiondantrans_item : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_m_TransactionItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        Transaction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.tb_m_Transaction", t => t.Transaction_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.tb_m_Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_m_TransactionItem", "Transaction_Id", "dbo.tb_m_Transaction");
            DropForeignKey("dbo.tb_m_TransactionItem", "Item_Id", "dbo.Items");
            DropIndex("dbo.tb_m_TransactionItem", new[] { "Transaction_Id" });
            DropIndex("dbo.tb_m_TransactionItem", new[] { "Item_Id" });
            DropTable("dbo.tb_m_Transaction");
            DropTable("dbo.tb_m_TransactionItem");
        }
    }
}
