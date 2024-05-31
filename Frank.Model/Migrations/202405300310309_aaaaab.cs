namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Product_Id", c => c.Long());
            DropColumn("dbo.Orders", "Customer_Name");
            DropColumn("dbo.Orders", "Customer_Email");
            DropColumn("dbo.Orders", "Customer_Address");
            DropColumn("dbo.Orders", "Customer_Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Customer_Phone", c => c.String());
            AddColumn("dbo.Orders", "Customer_Address", c => c.String());
            AddColumn("dbo.Orders", "Customer_Email", c => c.String());
            AddColumn("dbo.Orders", "Customer_Name", c => c.String());
            DropColumn("dbo.Orders", "Product_Id");
        }
    }
}
