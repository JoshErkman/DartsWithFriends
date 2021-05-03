namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsStarredToPlayers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatchSetup", "PlayerOneIsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.MatchSetup", "PlayerTwoIsStarred", c => c.Boolean(nullable: false));
            DropColumn("dbo.MatchSetup", "IsStarred");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchSetup", "IsStarred", c => c.Boolean(nullable: false));
            DropColumn("dbo.MatchSetup", "PlayerTwoIsStarred");
            DropColumn("dbo.MatchSetup", "PlayerOneIsStarred");
        }
    }
}
