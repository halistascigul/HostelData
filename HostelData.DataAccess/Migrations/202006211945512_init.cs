namespace HostelData.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Phone = c.String(maxLength: 30),
                        Email = c.String(maxLength: 100),
                        IdentityNumber = c.Long(nullable: false),
                        RoomId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Pay = c.Decimal(nullable: false, storeType: "money"),
                        EntryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReleaseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.IdentityNumber, unique: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Electrical = c.Decimal(nullable: false, storeType: "money"),
                        Water = c.Decimal(nullable: false, storeType: "money"),
                        Warm = c.Decimal(nullable: false, storeType: "money"),
                        Internet = c.Decimal(nullable: false, storeType: "money"),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        NoticeText = c.String(maxLength: 500),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Toast = c.Int(nullable: false),
                        Hamburger = c.Int(nullable: false),
                        Cola = c.Int(nullable: false),
                        Fanta = c.Int(nullable: false),
                        Soda = c.Int(nullable: false),
                        Chips = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 6),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Customers", new[] { "RoomId" });
            DropIndex("dbo.Customers", new[] { "IdentityNumber" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropTable("dbo.Users");
            DropTable("dbo.Stocks");
            DropTable("dbo.Notices");
            DropTable("dbo.Invoices");
            DropTable("dbo.Rooms");
            DropTable("dbo.Customers");
        }
    }
}
