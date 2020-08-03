namespace HostelData.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Customers", new[] { "RoomId" });
            CreateTable(
                "dbo.RoomsCustomers",
                c => new
                    {
                        Rooms = c.Int(nullable: false),
                        Customers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rooms, t.Customers })
                .ForeignKey("dbo.Customers", t => t.Rooms, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Customers, cascadeDelete: true)
                .Index(t => t.Rooms)
                .Index(t => t.Customers);
            
            AlterColumn("dbo.Customers", "Gender", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Customers", "Updated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rooms", "Updated", c => c.DateTime());
            AlterColumn("dbo.Invoices", "Electrical", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Invoices", "Water", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Invoices", "Warm", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Invoices", "Internet", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Invoices", "Updated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Notices", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Notices", "NoticeText", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Notices", "Updated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Stocks", "Updated", c => c.DateTime());
            AlterColumn("dbo.Users", "Updated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Customers", "RoomId");
            DropColumn("dbo.Customers", "RoomNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "RoomNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "RoomId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RoomsCustomers", "Customers", "dbo.Rooms");
            DropForeignKey("dbo.RoomsCustomers", "Rooms", "dbo.Customers");
            DropIndex("dbo.RoomsCustomers", new[] { "Customers" });
            DropIndex("dbo.RoomsCustomers", new[] { "Rooms" });
            AlterColumn("dbo.Users", "Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Stocks", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notices", "Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Notices", "NoticeText", c => c.String(maxLength: 500));
            AlterColumn("dbo.Notices", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Invoices", "Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Invoices", "Internet", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Invoices", "Warm", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Invoices", "Water", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Invoices", "Electrical", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Rooms", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "Gender", c => c.Int(nullable: false));
            DropTable("dbo.RoomsCustomers");
            CreateIndex("dbo.Customers", "RoomId");
            AddForeignKey("dbo.Customers", "RoomId", "dbo.Rooms", "Id");
        }
    }
}
