namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegratedPlayerIntoIdentityUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MatchSetup", "PlayerId", "dbo.Player");
            DropIndex("dbo.MatchSetup", new[] { "PlayerId" });
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "FiveOOne_AvgBest", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "FiveOOne_AvgWorst", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "CheckOutBest", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "CheckOutWorst", c => c.Int(nullable: false));
            AlterColumn("dbo.MatchSetup", "PlayerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MatchSetup", "PlayerId");
            AddForeignKey("dbo.MatchSetup", "PlayerId", "dbo.ApplicationUser", "Id");
            DropTable("dbo.Player");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FiveOOne_AvgBest = c.Int(nullable: false),
                        FiveOOne_AvgWorst = c.Int(nullable: false),
                        CheckOutBest = c.Int(nullable: false),
                        CheckOutWorst = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            DropForeignKey("dbo.MatchSetup", "PlayerId", "dbo.ApplicationUser");
            DropIndex("dbo.MatchSetup", new[] { "PlayerId" });
            AlterColumn("dbo.MatchSetup", "PlayerId", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "CheckOutWorst");
            DropColumn("dbo.ApplicationUser", "CheckOutBest");
            DropColumn("dbo.ApplicationUser", "FiveOOne_AvgWorst");
            DropColumn("dbo.ApplicationUser", "FiveOOne_AvgBest");
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
            CreateIndex("dbo.MatchSetup", "PlayerId");
            AddForeignKey("dbo.MatchSetup", "PlayerId", "dbo.Player", "PlayerId", cascadeDelete: true);
        }
    }
}
