namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cccccca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order_Address", "Order_Id", c => c.Long());
            DropColumn("dbo.Orders", "OrderAddress_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderAddress_Id", c => c.Long());
            DropColumn("dbo.Order_Address", "Order_Id");
        }
    }
}
