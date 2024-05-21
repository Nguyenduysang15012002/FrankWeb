namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablexxx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attribute_Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Size = c.Long(nullable: false),
                        Price = c.Long(nullable: false),
                        Sale_Price = c.Long(nullable: false),
                        Amount = c.Long(nullable: false),
                        Product_Id = c.Long(),
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
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
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
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url_Image = c.String(),
                        Title = c.String(),
                        Product_Id = c.Long(),
                        User_Id = c.Long(),
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
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Total = c.Long(nullable: false),
                        Customer_Name = c.String(),
                        Customer_Email = c.String(),
                        Customer_Address = c.String(),
                        Customer_Phone = c.String(),
                        Processing_Status = c.Int(nullable: false),
                        User_Id = c.Long(),
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
                "dbo.Order_Detail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Long(nullable: false),
                        Price = c.Long(nullable: false),
                        Attribute_Product_Id = c.Long(),
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
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PermissionName = c.String(),
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
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Brand = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        ExpiredYear = c.Int(nullable: false),
                        Quantity = c.String(),
                        Category_Id = c.Long(),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Status = c.String(),
                        Permission_Id = c.Long(),
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
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Permissions");
            DropTable("dbo.Order_Detail");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Attribute_Product");
        }
    }
}
