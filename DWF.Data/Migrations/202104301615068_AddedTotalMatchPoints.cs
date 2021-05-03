namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTotalMatchPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "PlayerOneTotalMatchPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Match", "PlayerTwoTotalMatchPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "PlayerTwoTotalMatchPoints");
            DropColumn("dbo.Match", "PlayerOneTotalMatchPoints");
        }
    }
}
