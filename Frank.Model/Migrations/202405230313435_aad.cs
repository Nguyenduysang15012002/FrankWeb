namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Title", c => c.String());
            DropColumn("dbo.Products", "Name");
        }
    }
}
