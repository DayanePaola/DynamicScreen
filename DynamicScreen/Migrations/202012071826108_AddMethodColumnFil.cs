namespace DynamicScreen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMethodColumnFil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConfigurationColumn", "Name", c => c.String(maxLength: 8000));
            AddColumn("dbo.ConfigurationColumnFill", "Method", c => c.String(maxLength: 8000));
            DropColumn("dbo.ConfigurationColumnFill", "DestinationIndex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConfigurationColumnFill", "DestinationIndex", c => c.Int(nullable: false));
            DropColumn("dbo.ConfigurationColumnFill", "Method");
            DropColumn("dbo.ConfigurationColumn", "Name");
        }
    }
}
