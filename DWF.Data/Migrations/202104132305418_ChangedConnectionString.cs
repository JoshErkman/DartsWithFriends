namespace DWF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedConnectionString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Player", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Player", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "LastName", c => c.String());
            AlterColumn("dbo.Player", "FirstName", c => c.String());
        }
    }
}
