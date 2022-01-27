namespace WeaponsLocker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Firearms", "LastCleaned", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Firearms", "LastCleaned", c => c.DateTime(nullable: false));
        }
    }
}
