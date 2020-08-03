namespace HostelData.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SoldCola", c => c.Byte());
            AddColumn("dbo.Customers", "SoldFanta", c => c.Byte());
            AddColumn("dbo.Customers", "SoldSoda", c => c.Byte());
            AddColumn("dbo.Customers", "SoldToast", c => c.Byte());
            AddColumn("dbo.Customers", "SoldHamburger", c => c.Byte());
            AddColumn("dbo.Customers", "SoldChips", c => c.Byte());
            AddColumn("dbo.Customers", "TotalAmount", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Stocks", "Toast", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Hamburger", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Cola", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Fanta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Soda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "Chips", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "TotalBeverage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "TotalFood", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stocks", "TotalFood", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "TotalBeverage", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Chips", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Soda", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Fanta", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Cola", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Hamburger", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Toast", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "TotalAmount");
            DropColumn("dbo.Customers", "SoldChips");
            DropColumn("dbo.Customers", "SoldHamburger");
            DropColumn("dbo.Customers", "SoldToast");
            DropColumn("dbo.Customers", "SoldSoda");
            DropColumn("dbo.Customers", "SoldFanta");
            DropColumn("dbo.Customers", "SoldCola");
        }
    }
}
