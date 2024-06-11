namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "RecievePhone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "RecievePhone", c => c.Int(nullable: false));
        }
    }
}
