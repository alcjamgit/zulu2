using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShareWealth.Core.Entities;

namespace ShareWealth.Infrastructure.DataLayer
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("swscon", throwIfV1Schema: false)
        {
        }
        public DbSet<Security> Securities { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<WatchlistSecurity> WatchlistSecurities { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<ScanProfile> ScanProfiles { get; set; }
        public DbSet<ScanResult> ScanResults { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioAdjustment> PortfolioAdjustments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}