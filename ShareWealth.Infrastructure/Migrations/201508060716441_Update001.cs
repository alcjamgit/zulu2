namespace ShareWealth.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioAdjustments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(),
                        PortfolioId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        System = c.String(),
                        Currency = c.String(),
                        Exchange = c.String(),
                        WatchlistName = c.String(),
                        RiskOption = c.String(),
                        MaxOpenPositions = c.Int(nullable: false),
                        AllocationRisk = c.Double(nullable: false),
                        MinBrokerage = c.Double(nullable: false),
                        BrokeragePercentage = c.Double(nullable: false),
                        BrokerageThreshold = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ScanProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        System = c.String(),
                        Locked = c.Boolean(nullable: false),
                        ScanType = c.String(),
                        Parameters = c.String(),
                        ChartOptions = c.String(),
                        Entry = c.Boolean(nullable: false),
                        Exit = c.Boolean(nullable: false),
                        Pyramid = c.Boolean(nullable: false),
                        Lighten = c.Boolean(nullable: false),
                        TimeFrameType = c.String(),
                        Period = c.Int(nullable: false),
                        PeriodType = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScanResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecurityCode = c.String(),
                        SignalDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        SignalName = c.String(),
                        SignalType = c.String(),
                        SignalPrice = c.Double(nullable: false),
                        ScanProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScanProfiles", t => t.ScanProfileId, cascadeDelete: true)
                .Index(t => t.ScanProfileId);
            
            CreateTable(
                "dbo.Securities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecurityCode = c.String(),
                        SecurityName = c.String(),
                        Exchange = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WatchlistSecurities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WatchlistId = c.Int(nullable: false),
                        SecurityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Securities", t => t.SecurityId, cascadeDelete: true)
                .ForeignKey("dbo.Watchlists", t => t.WatchlistId, cascadeDelete: true)
                .Index(t => t.WatchlistId)
                .Index(t => t.SecurityId);
            
            CreateTable(
                "dbo.Watchlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        SecurityCode = c.String(),
                        SignalName = c.String(),
                        TransactionType = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "DefaultPortfolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockPrices", "SecurityId");
            AddForeignKey("dbo.StockPrices", "SecurityId", "dbo.Securities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchlistSecurities", "WatchlistId", "dbo.Watchlists");
            DropForeignKey("dbo.WatchlistSecurities", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.StockPrices", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.ScanResults", "ScanProfileId", "dbo.ScanProfiles");
            DropForeignKey("dbo.Portfolios", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PortfolioAdjustments", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.WatchlistSecurities", new[] { "SecurityId" });
            DropIndex("dbo.WatchlistSecurities", new[] { "WatchlistId" });
            DropIndex("dbo.StockPrices", new[] { "SecurityId" });
            DropIndex("dbo.ScanResults", new[] { "ScanProfileId" });
            DropIndex("dbo.Portfolios", new[] { "UserId" });
            DropIndex("dbo.PortfolioAdjustments", new[] { "PortfolioId" });
            DropColumn("dbo.AspNetUsers", "DefaultPortfolioId");
            DropTable("dbo.StockTransactions");
            DropTable("dbo.Watchlists");
            DropTable("dbo.WatchlistSecurities");
            DropTable("dbo.Securities");
            DropTable("dbo.ScanResults");
            DropTable("dbo.ScanProfiles");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioAdjustments");
        }
    }
}
