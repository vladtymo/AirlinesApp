namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Phone");
        }
    }
}
