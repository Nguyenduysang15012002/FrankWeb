namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order_Detail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Price = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Long(nullable: false),
                        Product_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "RecieveName", c => c.String());
            AddColumn("dbo.Orders", "RecieveAddress", c => c.String());
            AddColumn("dbo.Orders", "RecievePhone", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "Product_Id");        
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Order_Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NameCustomer = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Order_Id = c.Long(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedID = c.Long(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedID = c.Long(),
                        IsDelete = c.Boolean(),
                        DeleteTime = c.DateTime(),
                        DeleteId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Product_Id", c => c.Long());
            AddColumn("dbo.Orders", "Quantity", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "RecievePhone");
            DropColumn("dbo.Orders", "RecieveAddress");
            DropColumn("dbo.Orders", "RecieveName");
            DropTable("dbo.Order_Detail");
        }
    }
}
