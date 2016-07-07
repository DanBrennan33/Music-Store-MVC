namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedrichtextvariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Description", c => c.String(maxLength: 1000));
            AddColumn("dbo.Artists", "Profile", c => c.String(maxLength: 1000));
            DropColumn("dbo.Albums", "Profile");
            DropColumn("dbo.Artists", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Description", c => c.String(maxLength: 200));
            AddColumn("dbo.Albums", "Profile", c => c.String(maxLength: 200));
            DropColumn("dbo.Artists", "Profile");
            DropColumn("dbo.Albums", "Description");
        }
    }
}
