namespace iTunesSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoIdAddedIntoInteractionModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Interactions", new[] { "UserId" });
            DropPrimaryKey("dbo.Interactions");
            AddColumn("dbo.Interactions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Interactions", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Interactions", "Id");
            CreateIndex("dbo.Interactions", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Interactions", new[] { "UserId" });
            DropPrimaryKey("dbo.Interactions");
            AlterColumn("dbo.Interactions", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Interactions", "Id");
            AddPrimaryKey("dbo.Interactions", "UserId");
            CreateIndex("dbo.Interactions", "UserId");
        }
    }
}
