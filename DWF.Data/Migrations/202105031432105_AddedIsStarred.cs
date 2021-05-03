namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsStarred : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchSetup", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MatchSetup", "IsStarred");
        }
    }
}
