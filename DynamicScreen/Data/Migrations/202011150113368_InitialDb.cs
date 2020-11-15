namespace DynamicScreen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfigurationColumn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationId = c.Int(nullable: false),
                        Group = c.String(maxLength: 8000),
                        Title = c.String(maxLength: 8000),
                        Method = c.String(maxLength: 8000),
                        Index = c.Int(nullable: false),
                        ReadOnly = c.Boolean(nullable: false),
                        DataType = c.String(maxLength: 8000),
                        Component = c.String(maxLength: 8000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Configuration", t => t.ConfigurationId)
                .Index(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 8000),
                        Title = c.String(maxLength: 8000),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConfigurationRow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Configuration", t => t.ConfigurationId)
                .Index(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.ConfigurationValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationColumnId = c.Int(nullable: false),
                        ConfigurationRowId = c.Int(nullable: false),
                        Value = c.String(maxLength: 8000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConfigurationColumn", t => t.ConfigurationColumnId)
                .ForeignKey("dbo.ConfigurationRow", t => t.ConfigurationRowId)
                .Index(t => t.ConfigurationColumnId)
                .Index(t => t.ConfigurationRowId);
            
            CreateTable(
                "dbo.ConfigurationColumnFill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationColumnSourceId = c.Int(nullable: false),
                        ConfigurationColumnDestinationId = c.Int(nullable: false),
                        DestinationIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConfigurationColumn", t => t.ConfigurationColumnDestinationId)
                .ForeignKey("dbo.ConfigurationColumn", t => t.ConfigurationColumnSourceId)
                .Index(t => t.ConfigurationColumnSourceId)
                .Index(t => t.ConfigurationColumnDestinationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfigurationColumnFill", "ConfigurationColumnSourceId", "dbo.ConfigurationColumn");
            DropForeignKey("dbo.ConfigurationColumnFill", "ConfigurationColumnDestinationId", "dbo.ConfigurationColumn");
            DropForeignKey("dbo.ConfigurationColumn", "ConfigurationId", "dbo.Configuration");
            DropForeignKey("dbo.ConfigurationValue", "ConfigurationRowId", "dbo.ConfigurationRow");
            DropForeignKey("dbo.ConfigurationValue", "ConfigurationColumnId", "dbo.ConfigurationColumn");
            DropForeignKey("dbo.ConfigurationRow", "ConfigurationId", "dbo.Configuration");
            DropIndex("dbo.ConfigurationColumnFill", new[] { "ConfigurationColumnDestinationId" });
            DropIndex("dbo.ConfigurationColumnFill", new[] { "ConfigurationColumnSourceId" });
            DropIndex("dbo.ConfigurationValue", new[] { "ConfigurationRowId" });
            DropIndex("dbo.ConfigurationValue", new[] { "ConfigurationColumnId" });
            DropIndex("dbo.ConfigurationRow", new[] { "ConfigurationId" });
            DropIndex("dbo.ConfigurationColumn", new[] { "ConfigurationId" });
            DropTable("dbo.ConfigurationColumnFill");
            DropTable("dbo.ConfigurationValue");
            DropTable("dbo.ConfigurationRow");
            DropTable("dbo.Configuration");
            DropTable("dbo.ConfigurationColumn");
        }
    }
}
