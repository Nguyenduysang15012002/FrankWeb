namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaac : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Quantity", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Quantity", c => c.String());
        }
    }
}
