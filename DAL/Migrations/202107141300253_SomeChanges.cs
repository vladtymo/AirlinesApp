namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clients", "Phone", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Phone", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
