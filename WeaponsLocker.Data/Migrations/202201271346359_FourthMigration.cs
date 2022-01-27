namespace WeaponsLocker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "Firearm_FirearmId", c => c.Int());
            CreateIndex("dbo.Attachments", "Firearm_FirearmId");
            AddForeignKey("dbo.Attachments", "Firearm_FirearmId", "dbo.Firearms", "FirearmId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "Firearm_FirearmId", "dbo.Firearms");
            DropIndex("dbo.Attachments", new[] { "Firearm_FirearmId" });
            DropColumn("dbo.Attachments", "Firearm_FirearmId");
        }
    }
}
