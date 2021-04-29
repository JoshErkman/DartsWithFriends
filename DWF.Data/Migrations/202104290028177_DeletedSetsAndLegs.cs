namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedSetsAndLegs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Match", "SetScore");
            DropColumn("dbo.Match", "LegScore");
            DropColumn("dbo.MatchSetup", "NumberOfSets");
            DropColumn("dbo.MatchSetup", "NumberOfLegs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchSetup", "NumberOfLegs", c => c.Int(nullable: false));
            AddColumn("dbo.MatchSetup", "NumberOfSets", c => c.Int(nullable: false));
            AddColumn("dbo.Match", "LegScore", c => c.Int(nullable: false));
            AddColumn("dbo.Match", "SetScore", c => c.Int(nullable: false));
        }
    }
}
