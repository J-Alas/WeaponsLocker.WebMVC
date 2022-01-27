namespace WeaponsLocker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Firearms", "GunModel", c => c.String(nullable: false));
            DropColumn("dbo.Firearms", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Firearms", "Model", c => c.String(nullable: false));
            DropColumn("dbo.Firearms", "GunModel");
        }
    }
}
