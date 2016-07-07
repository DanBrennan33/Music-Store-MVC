namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedURLsize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "UrlArtist", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "UrlArtist", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
