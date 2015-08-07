namespace ShareWealth.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioAdjustments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(),
                        PortfolioId = c.Guid(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DefaultPortfolioId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ScanProfiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                        Id = c.Guid(nullable: false),
                        SecurityCode = c.String(),
                        SignalDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        SignalName = c.String(),
                        SignalType = c.String(),
                        SignalPrice = c.Double(nullable: false),
                        ScanProfileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScanProfiles", t => t.ScanProfileId, cascadeDelete: true)
                .Index(t => t.ScanProfileId);
            
            CreateTable(
                "dbo.Securities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SecurityCode = c.String(),
                        SecurityName = c.String(),
                        Exchange = c.String(),
                        Type = c.String(),
                        GicsSector = c.String(),
                        IcbIndustry = c.String(),
                        Open = c.Double(nullable: false),
                        High = c.Double(nullable: false),
                        Low = c.Double(nullable: false),
                        Close = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                        LastDate = c.DateTime(nullable: false),
                        MarketCap = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockPrices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SecurityId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Open = c.Double(nullable: false),
                        High = c.Double(nullable: false),
                        Low = c.Double(nullable: false),
                        Close = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Securities", t => t.SecurityId, cascadeDelete: true)
                .Index(t => t.SecurityId);
            
            CreateTable(
                "dbo.WatchlistSecurities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WatchlistId = c.Guid(nullable: false),
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
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        SecurityId = c.Int(nullable: false),
                        SignalName = c.String(),
                        TransactionType = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Securities", t => t.SecurityId, cascadeDelete: true)
                .Index(t => t.SecurityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockTransactions", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.WatchlistSecurities", "WatchlistId", "dbo.Watchlists");
            DropForeignKey("dbo.WatchlistSecurities", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.StockPrices", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.ScanResults", "ScanProfileId", "dbo.ScanProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Portfolios", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PortfolioAdjustments", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.StockTransactions", new[] { "SecurityId" });
            DropIndex("dbo.WatchlistSecurities", new[] { "SecurityId" });
            DropIndex("dbo.WatchlistSecurities", new[] { "WatchlistId" });
            DropIndex("dbo.StockPrices", new[] { "SecurityId" });
            DropIndex("dbo.ScanResults", new[] { "ScanProfileId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Portfolios", new[] { "UserId" });
            DropIndex("dbo.PortfolioAdjustments", new[] { "PortfolioId" });
            DropTable("dbo.StockTransactions");
            DropTable("dbo.Watchlists");
            DropTable("dbo.WatchlistSecurities");
            DropTable("dbo.StockPrices");
            DropTable("dbo.Securities");
            DropTable("dbo.ScanResults");
            DropTable("dbo.ScanProfiles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Portfolios");
            DropTable("dbo.PortfolioAdjustments");
        }
    }
}
