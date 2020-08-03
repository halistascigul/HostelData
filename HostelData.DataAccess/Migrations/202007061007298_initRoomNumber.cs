namespace HostelData.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initRoomNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RoomNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "TotalPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "TotalElectrical", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "TotalWater", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "TotalWarm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "TotalInternet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "TotalBeverage", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "TotalFood", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "TotalFood");
            DropColumn("dbo.Stocks", "TotalBeverage");
            DropColumn("dbo.Invoices", "TotalInternet");
            DropColumn("dbo.Invoices", "TotalWarm");
            DropColumn("dbo.Invoices", "TotalWater");
            DropColumn("dbo.Invoices", "TotalElectrical");
            DropColumn("dbo.Customers", "TotalPay");
            DropColumn("dbo.Customers", "RoomNumber");
        }
    }
}
