namespace iTunesSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IpAddressAddedIntoInteractionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interactions", "IpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Interactions", "IpAddress");
        }
    }
}
