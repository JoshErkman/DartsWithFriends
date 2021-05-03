namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalRoundPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Round", "TotalRoundPoints", c => c.Int(nullable: false));
            DropColumn("dbo.Round", "TotalPoints");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Round", "TotalPoints", c => c.Int(nullable: false));
            DropColumn("dbo.Round", "TotalRoundPoints");
        }
    }
}
