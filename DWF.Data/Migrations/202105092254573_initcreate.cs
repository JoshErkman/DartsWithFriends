namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchSetupId = c.Int(nullable: false),
                        PlayerOneNeededScore = c.Int(nullable: false),
                        PlayerTwoNeededScore = c.Int(nullable: false),
                        PlayerOneAvgRoundScore = c.Int(nullable: false),
                        PlayerTwoAvgRoundScore = c.Int(nullable: false),
                        PlayerOneRound = c.Int(nullable: false),
                        PlayerTwoRound = c.Int(nullable: false),
                        IsTurn = c.Boolean(nullable: false),
                        PlayerOneTotalMatchPoints = c.Int(nullable: false),
                        PlayerTwoTotalMatchPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.MatchSetup", t => t.MatchSetupId, cascadeDelete: true)
                .Index(t => t.MatchSetupId);
            
            CreateTable(
                "dbo.MatchSetup",
                c => new
                    {
                        MatchSetupId = c.Int(nullable: false, identity: true),
                        PlayerOneId = c.String(maxLength: 128),
                        PlayerTwoId = c.String(maxLength: 128),
                        PlayerOneIsStarred = c.Boolean(nullable: false),
                        PlayerTwoIsStarred = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MatchSetupId)
                .ForeignKey("dbo.ApplicationUser", t => t.PlayerOneId)
                .ForeignKey("dbo.ApplicationUser", t => t.PlayerTwoId)
                .Index(t => t.PlayerOneId)
                .Index(t => t.PlayerTwoId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FiveOOne_AvgBest = c.Int(nullable: false),
                        FiveOOne_AvgWorst = c.Int(nullable: false),
                        CheckOutBest = c.Int(nullable: false),
                        CheckOutWorst = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Round",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        TotalRoundPoints = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.Match", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Round", "MatchId", "dbo.Match");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Match", "MatchSetupId", "dbo.MatchSetup");
            DropForeignKey("dbo.MatchSetup", "PlayerTwoId", "dbo.ApplicationUser");
            DropForeignKey("dbo.MatchSetup", "PlayerOneId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Round", new[] { "MatchId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MatchSetup", new[] { "PlayerTwoId" });
            DropIndex("dbo.MatchSetup", new[] { "PlayerOneId" });
            DropIndex("dbo.Match", new[] { "MatchSetupId" });
            DropTable("dbo.Round");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.MatchSetup");
            DropTable("dbo.Match");
        }
    }
}
