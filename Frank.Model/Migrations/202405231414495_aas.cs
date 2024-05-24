namespace Frank.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attribute_Product", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attribute_Product", "Amount", c => c.Long(nullable: false));
        }
    }
}
