namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Richtextstringsadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Profile", c => c.String(maxLength: 200));
            AddColumn("dbo.Artists", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Description");
            DropColumn("dbo.Albums", "Profile");
        }
    }
}
