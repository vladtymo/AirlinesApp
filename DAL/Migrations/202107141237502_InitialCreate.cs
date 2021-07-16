namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 100),
                        MaxPassengers = c.Int(nullable: false),
                        CountryId = c.Int(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        DepartureTime = c.DateTime(nullable: false),
                        DispatchCityId = c.Int(nullable: false),
                        ArrivalCityId = c.Int(nullable: false),
                        AirplaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Airplanes", t => t.AirplaneId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.ArrivalCityId)
                .ForeignKey("dbo.Cities", t => t.DispatchCityId)
                .Index(t => t.DispatchCityId)
                .Index(t => t.ArrivalCityId)
                .Index(t => t.AirplaneId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        CreditCard = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightClients",
                c => new
                    {
                        Flight_Number = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Flight_Number, t.Client_Id })
                .ForeignKey("dbo.Flights", t => t.Flight_Number, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Flight_Number)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Airplanes", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Airplanes", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Flights", "DispatchCityId", "dbo.Cities");
            DropForeignKey("dbo.FlightClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.FlightClients", "Flight_Number", "dbo.Flights");
            DropForeignKey("dbo.Flights", "ArrivalCityId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "AirplaneId", "dbo.Airplanes");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.FlightClients", new[] { "Client_Id" });
            DropIndex("dbo.FlightClients", new[] { "Flight_Number" });
            DropIndex("dbo.Flights", new[] { "AirplaneId" });
            DropIndex("dbo.Flights", new[] { "ArrivalCityId" });
            DropIndex("dbo.Flights", new[] { "DispatchCityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Airplanes", new[] { "TypeId" });
            DropIndex("dbo.Airplanes", new[] { "CountryId" });
            DropTable("dbo.FlightClients");
            DropTable("dbo.Types");
            DropTable("dbo.Clients");
            DropTable("dbo.Flights");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Airplanes");
        }
    }
}
