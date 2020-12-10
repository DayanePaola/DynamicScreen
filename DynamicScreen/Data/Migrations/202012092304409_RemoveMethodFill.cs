namespace DynamicScreen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMethodFill : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ConfigurationColumnFill", "Method");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConfigurationColumnFill", "Method", c => c.String(maxLength: 8000));
        }
    }
}
