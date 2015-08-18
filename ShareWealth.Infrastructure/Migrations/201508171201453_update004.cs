namespace ShareWealth.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update004 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockPrices", "TradingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockPrices", "TradingDate", c => c.DateTime(nullable: false));
        }
    }
}
