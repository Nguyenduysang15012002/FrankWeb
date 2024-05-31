namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalPrice", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "TotalPrice");
        }
    }
}
