namespace ShareWealth.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPrices", "TradingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.StockPrices", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockPrices", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.StockPrices", "TradingDate");
        }
    }
}
