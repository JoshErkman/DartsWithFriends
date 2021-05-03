namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerOneRoundPlayerTwoRoundAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "PlayerOneRound", c => c.Int(nullable: false));
            AddColumn("dbo.Match", "PlayerTwoRound", c => c.Int(nullable: false));
            DropColumn("dbo.Match", "Rounds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Match", "Rounds", c => c.Int(nullable: false));
            DropColumn("dbo.Match", "PlayerTwoRound");
            DropColumn("dbo.Match", "PlayerOneRound");
        }
    }
}
