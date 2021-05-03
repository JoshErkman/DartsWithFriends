namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsTurn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "IsTurn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "IsTurn");
        }
    }
}
