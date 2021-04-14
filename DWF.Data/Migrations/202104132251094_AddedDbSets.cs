namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchSetupId = c.Int(nullable: false),
                        NeededScore = c.Int(nullable: false),
                        SetScore = c.Int(nullable: false),
                        LegScore = c.Int(nullable: false),
                        AvgRoundScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.MatchSetup", t => t.MatchSetupId, cascadeDelete: true)
                .Index(t => t.MatchSetupId);
            
            CreateTable(
                "dbo.MatchSetup",
                c => new
                    {
                        MatchSetupId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        NumberOfSets = c.Int(nullable: false),
                        NumberOfLegs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchSetupId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Round",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.Match", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Round", "MatchId", "dbo.Match");
            DropForeignKey("dbo.Match", "MatchSetupId", "dbo.MatchSetup");
            DropForeignKey("dbo.MatchSetup", "PlayerId", "dbo.Player");
            DropIndex("dbo.Round", new[] { "MatchId" });
            DropIndex("dbo.MatchSetup", new[] { "PlayerId" });
            DropIndex("dbo.Match", new[] { "MatchSetupId" });
            DropTable("dbo.Round");
            DropTable("dbo.MatchSetup");
            DropTable("dbo.Match");
        }
    }
}
