namespace DynamicScreen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexConfigurationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuration", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configuration", "Index");
        }
    }
}
