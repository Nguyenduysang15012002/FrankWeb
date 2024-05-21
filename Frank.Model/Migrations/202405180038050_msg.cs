namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class msg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order_Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NameCustomer = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        User_Id = c.Long(nullable: false),
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
            
            CreateTable(
                "dbo.ShopCarts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Product_Id = c.Long(nullable: false),
                        User_Id = c.Long(nullable: false),
                        Quantity = c.Long(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShopCarts");
            DropTable("dbo.Order_Address");
        }
    }
}
