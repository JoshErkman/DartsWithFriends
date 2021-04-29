namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationAddedRoundsToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "Rounds", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "Rounds");
        }
    }
}
