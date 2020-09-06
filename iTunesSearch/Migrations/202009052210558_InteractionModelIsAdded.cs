namespace iTunesSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InteractionModelIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interactions",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClickedAdUrl = c.String(),
                        InteractionTime = c.DateTime(nullable: false),
                        DeviceName = c.String(),
                        ScreenSize = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interactions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Interactions", new[] { "UserId" });
            DropTable("dbo.Interactions");
        }
    }
}
