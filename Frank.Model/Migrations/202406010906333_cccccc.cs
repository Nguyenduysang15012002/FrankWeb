namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cccccc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderAddress_Id", c => c.Long());
            DropColumn("dbo.Order_Address", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order_Address", "User_Id", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "OrderAddress_Id");
        }
    }
}
