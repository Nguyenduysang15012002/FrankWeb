namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Long(nullable: false));
            AddColumn("dbo.ShopCarts", "Total", c => c.Long(nullable: false));
            DropTable("dbo.Order_Detail");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.ShopCarts", "Total");
            DropColumn("dbo.Orders", "Quantity");
        }
    }
}
