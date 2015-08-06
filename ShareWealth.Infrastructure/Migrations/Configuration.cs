namespace ShareWealth.Infrastructure.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShareWealth.Core.Entities;
    using ShareWealth.Infrastructure.DataLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        private string _systemId_1 = new Guid("33ccbfae-d01a-4d94-ba62-da0118503f13").ToString();

        protected override void Seed(ApplicationDbContext context)
        {
            SeedAdminUsers(context);
            SeedPortfolioProfiles(context);
            SeedPortfolioAdjustments(context);
        }
        /// <summary>
        /// Seed admin user
        /// </summary>
        /// <param name="context"></param>
        private void SeedAdminUsers(ApplicationDbContext context)
        {
            var adminuser = "system1@gmail.com";
            var userRole = "admin";
            var pwd = "abc123";

            if (!context.Roles.Any(r => r.Name == userRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = userRole };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == adminuser))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Id = _systemId_1, UserName = adminuser };

                manager.Create(user, pwd);
                manager.AddToRole(user.Id, userRole);
            }
        }

        private void SeedPortfolioProfiles(ApplicationDbContext context)
        {
            var portfolios = new List<Portfolio>
            {
                new Portfolio { Id = 1, Name = "Default Portfolio", System = "SPA3", Exchange = "XASX", Currency = "AUD", MinBrokerage = 30, BrokeragePercentage = 0.02 , UserId = _systemId_1, RiskOption = "Default XASX SIROC 21:08" },
                new Portfolio { Id = 2, Name = "SPA3 Portfolio", System = "SPA3", Exchange = "XASX", Currency = "AUD", MinBrokerage = 40, BrokeragePercentage = 0.02 , UserId = _systemId_1, RiskOption = "Default XASX SIROC 19:08" },
                new Portfolio { Id = 3, Name = "SPA3 ETF Portfolio", System = "SPA3 ETF", Exchange = "XASX", Currency = "AUD", MinBrokerage = 35, BrokeragePercentage = 0.02 , UserId = _systemId_1 },
                new Portfolio { Id = 4, Name = "SPA3 ETF Portfolio", System = "SPA3 ETF", Exchange = "XNYS", Currency = "USD", MinBrokerage = 20, BrokeragePercentage = 0.03 , UserId = _systemId_1 },
            };
            foreach (var pf in portfolios)
            {
                if (!context.Portfolios.Any(p => p.Id == p.Id))
                {
                    context.Portfolios.Add(pf);
                }
            }
        }
        private void SeedPortfolioAdjustments(ApplicationDbContext context)
        {
            var portfolios = new List<PortfolioAdjustment>
            {
                new PortfolioAdjustment { Id = 1, Date = new DateTime(2004,6,30), PortfolioId = 1, Amount = 50000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 2, Date = new DateTime(2004,12,22), PortfolioId = 1, Amount = 10000, Type = "Addition" },
                new PortfolioAdjustment { Id = 3, Date = new DateTime(2006,3,15), PortfolioId = 1, Amount = 2500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = 4, Date = new DateTime(2007,8,30), PortfolioId = 2, Amount = 75000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 5, Date = new DateTime(2007,11,15), PortfolioId = 2, Amount = 3500, Type = "Addition" },
                new PortfolioAdjustment { Id = 6, Date = new DateTime(2019,4,12), PortfolioId = 2, Amount = 1500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = 7, Date = new DateTime(2010,6,30), PortfolioId = 3, Amount = 50000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 8, Date = new DateTime(2011,12,22), PortfolioId = 3, Amount = 10000, Type = "Addition" },
                new PortfolioAdjustment { Id = 9, Date = new DateTime(2012,3,15), PortfolioId = 3, Amount = 2500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = 10, Date = new DateTime(2013,8,30), PortfolioId = 4, Amount = 45000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 11, Date = new DateTime(2014,11,15), PortfolioId = 4, Amount = 2700, Type = "Addition" },
                new PortfolioAdjustment { Id = 12, Date = new DateTime(2015,4,12), PortfolioId = 4, Amount = 6700, Type = "Withdrawal" }
            };
            foreach (var pa in portfolios)
            {
                if (!context.PortfolioAdjustments.Any(p => p.Id == p.Id))
                {
                    context.PortfolioAdjustments.Add(pa);
                }
            }
        }
        private void SeedSecurities(ApplicationDbContext context)
        {
            var securities = new List<Security> {
                new Security { Id=1 , SecurityCode = "$BCOM" , SecurityName = "Bloomberg Commodity" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=94.14 , High=94.36 , Low=93.19 , Close=93.29 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=2 , SecurityCode = "$BVSP" , SecurityName = "Bovespa" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=49804.289 , High=49831.461 , Low=48624.141 , Close=49245.84 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=3 , SecurityCode = "$CCI" , SecurityName = "Continuous Commodity" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=405.3 , High=405.38 , Low=402.87 , Close=403.15 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=4 , SecurityCode = "$COMP" , SecurityName = "NASDAQ Composite" , Exchange = "XNAS" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=5166.91 , High=5167.54 , Low=5084.51 , Close=5088.63 , Volume=1907500032 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=5 , SecurityCode = "$DAX" , SecurityName = "DAX (Deutscher Aktienindex)" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=11467.83 , High=11542.9 , Low=11334.77 , Close=11347.45 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=6 , SecurityCode = "$DJI" , SecurityName = "Dow Jones Industrial" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=17731.051 , High=17756.539 , Low=17553.73 , Close=17568.529 , Volume=378800000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=7 , SecurityCode = "$FT100" , SecurityName = "FTSE 100" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=6655.01 , High=6684.81 , Low=6573.96 , Close=6579.81 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=8 , SecurityCode = "$HS" , SecurityName = "Hang Seng" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=25279.949 , High=25279.949 , Low=25073.199 , Close=25128.51 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=9 , SecurityCode = "$MID" , SecurityName = "S&P MidCap 400" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=1489.8 , High=1491.96 , Low=1474.59 , Close=1476.74 , Volume=536200000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=10 , SecurityCode = "$MXX" , SecurityName = "Mexico IPC" , Exchange = "World Indices" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=44840.25 , High=44898.129 , Low=44209.531 , Close=44249.488 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=11 , SecurityCode = "$NDX" , SecurityName = "NASDAQ-100" , Exchange = "XNAS" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=4630.95 , High=4632.06 , Low=4552.4 , Close=4557.37 , Volume=666200000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=12 , SecurityCode = "$RMC" , SecurityName = "Russell Mid Cap" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=1692.17 , High=1693.81 , Low=1674.55 , Close=1677.5 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=13 , SecurityCode = "$RUI" , SecurityName = "Russell 1000" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=1172.95 , High=1173.66 , Low=1158.15 , Close=1159.58 , Volume=3370800128 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=14 , SecurityCode = "$RUMIC" , SecurityName = "Russell Micro Cap" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=494.47 , High=494.61 , Low=486.96 , Close=486.96 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=15 , SecurityCode = "$RUT" , SecurityName = "Russell 2000" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=1242.39 , High=1243.58 , Low=1225.43 , Close=1225.99 , Volume=1179399936 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=16 , SecurityCode = "$SML" , SecurityName = "S&P SmallCap 600" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=710.5 , High=710.5 , Low=700.86 , Close=701.72 , Volume=302000000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=17 , SecurityCode = "$SPX" , SecurityName = "S&P 500" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=2102.24 , High=2106.01 , Low=2077.09 , Close=2079.65 , Volume=2465400064 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=18 , SecurityCode = "$SPXEW" , SecurityName = "S&P 500 Equal Weight" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=3258.32 , High=3258.32 , Low=3217.89 , Close=3222.92 , Volume=2465400064 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=19 , SecurityCode = "$W5000" , SecurityName = "Wilshire 5000 Total Market" , Exchange = "XNAS" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=22131.98 , High=22171.891 , Low=21882.811 , Close=21906.75 , Volume=0 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=20 , SecurityCode = "$XAO" , SecurityName = "ASX All Ordinaries" , Exchange = "XASX" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=5581.3 , High=5595.5 , Low=5539 , Close=5556.804 , Volume=621667584 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=21 , SecurityCode = "$XDJ" , SecurityName = "S&P/ASX 200 Consumer Discretionary" , Exchange = "XASX" , Type = "Index" , GicsSector = "Consumer Discretionary" , IcbIndustry = "-" , Open=1891.9 , High=1892.1 , Low=1867.6 , Close=1874.552 , Volume=54612196 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=22 , SecurityCode = "$XEJ" , SecurityName = "S&P/ASX 200 Energy" , Exchange = "XASX" , Type = "Index" , GicsSector = "Energy" , IcbIndustry = "-" , Open=10584.2 , High=10675.4 , Low=10547.1 , Close=10603.989 , Volume=43016160 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=23 , SecurityCode = "$XFJ" , SecurityName = "S&P/ASX 200 Financials" , Exchange = "XASX" , Type = "Index" , GicsSector = "Financials" , IcbIndustry = "-" , Open=6555.7 , High=6589 , Low=6506.8 , Close=6523.139 , Volume=129889560 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=24 , SecurityCode = "$XFL" , SecurityName = "S&P/ASX 50" , Exchange = "XASX" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=5734.4 , High=5757.9 , Low=5695.1 , Close=5713.326 , Volume=214366960 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=25 , SecurityCode = "$XHJ" , SecurityName = "S&P/ASX 200 Health Care" , Exchange = "XASX" , Type = "Index" , GicsSector = "Health Care" , IcbIndustry = "-" , Open=19045.6 , High=19073.1 , Low=18908.699 , Close=18962.254 , Volume=16526974 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=26 , SecurityCode = "$XIJ" , SecurityName = "S&P/ASX 200 Information Technology" , Exchange = "XASX" , Type = "Index" , GicsSector = "Information Technology" , IcbIndustry = "-" , Open=808.5 , High=808.9 , Low=797.5 , Close=805.145 , Volume=2527942 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=27 , SecurityCode = "$XMJ" , SecurityName = "S&P/ASX 200 Materials" , Exchange = "XASX" , Type = "Index" , GicsSector = "Materials" , IcbIndustry = "-" , Open=8441.3 , High=8441.3 , Low=8334.2 , Close=8388.772 , Volume=131641520 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=28 , SecurityCode = "$XNJ" , SecurityName = "S&P/ASX 200 Industrials (Sector)" , Exchange = "XASX" , Type = "Index" , GicsSector = "Industrials" , IcbIndustry = "-" , Open=4804.1 , High=4810.1 , Low=4757.6 , Close=4790.019 , Volume=59647616 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=29 , SecurityCode = "$XPJ" , SecurityName = "S&P/ASX200 A-Reit (Sector)" , Exchange = "XASX" , Type = "Index" , GicsSector = "Financials" , IcbIndustry = "-" , Open=1264.9 , High=1277.4 , Low=1251.7 , Close=1257.765 , Volume=62078060 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=30 , SecurityCode = "$XSJ" , SecurityName = "S&P/ASX 200 Consumer Staples" , Exchange = "XASX" , Type = "Index" , GicsSector = "Consumer Staples" , IcbIndustry = "-" , Open=8840.1 , High=8857 , Low=8724.8 , Close=8784.719 , Volume=18262942 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=31 , SecurityCode = "$XSO" , SecurityName = "S&P/ASX Small Ordinaries" , Exchange = "XASX" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=2105.7 , High=2105.7 , Low=2077.6 , Close=2084.195 , Volume=196773328 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=32 , SecurityCode = "$XTJ" , SecurityName = "S&P/ASX 200 Telecommunication Services" , Exchange = "XASX" , Type = "Index" , GicsSector = "Telecommunication Services" , IcbIndustry = "-" , Open=2245.7 , High=2259.5 , Low=2235 , Close=2248.485 , Volume=16898416 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=33 , SecurityCode = "$XUJ" , SecurityName = "S&P/ASX 200 Utilities" , Exchange = "XASX" , Type = "Index" , GicsSector = "Utilities" , IcbIndustry = "-" , Open=6427.6 , High=6481.7 , Low=6401.6 , Close=6456.26 , Volume=28570452 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=34 , SecurityCode = "&C_CCB" , SecurityName = "Corn" , Exchange = "Futures Continuous" , Type = "Futures Contract" , GicsSector = "-" , IcbIndustry = "-" , Open=364 , High=367.75 , Low=359.5 , Close=360 , Volume=288153 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=35 , SecurityCode = "DIA" , SecurityName = "SPDR Dow Jones Industrial Average" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=177.23 , High=177.25 , Low=175.31 , Close=175.52 , Volume=4591323 , LastDate=DateTime.Today , MarketCap=14356283392 ,  } ,
                new Security { Id=36 , SecurityCode = "EWG" , SecurityName = "iShares MSCI Germany" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=28.6 , High=28.63 , Low=28.22 , Close=28.25 , Volume=8472333 , LastDate=DateTime.Today , MarketCap=5093474816 ,  } ,
                new Security { Id=37 , SecurityCode = "EWW" , SecurityName = "iShares MSCI Mexico Capped" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=55.63 , High=55.64 , Low=54.91 , Close=54.99 , Volume=4852018 , LastDate=DateTime.Today , MarketCap=1963143040 ,  } ,
                new Security { Id=38 , SecurityCode = "EWZ" , SecurityName = "iShares MSCI Brazil Capped" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=28.86 , High=28.9 , Low=28.15 , Close=28.5 , Volume=26799668 , LastDate=DateTime.Today , MarketCap=3105074944 ,  } ,
                new Security { Id=39 , SecurityCode = "IBB" , SecurityName = "iShares Nasdaq Biotechnology" , Exchange = "XNAS" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=386.63 , High=389 , Low=375.96 , Close=377.58 , Volume=3922083 , LastDate=DateTime.Today , MarketCap=6985229824 ,  } ,
                new Security { Id=40 , SecurityCode = "IJR" , SecurityName = "iShares Core S&P Small-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=116.51 , High=116.83 , Low=114.91 , Close=115.08 , Volume=877003 , LastDate=DateTime.Today , MarketCap=13890156544 ,  } ,
                new Security { Id=41 , SecurityCode = "IWM" , SecurityName = "iShares Russell 2000" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=123.48 , High=123.71 , Low=121.49 , Close=121.58 , Volume=39533028 , LastDate=DateTime.Today , MarketCap=28887408640 ,  } ,
                new Security { Id=42 , SecurityCode = "QQQ" , SecurityName = "PowerShares QQQ Trust Series 1" , Exchange = "XNAS" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=112.8 , High=113.003 , Low=110.93 , Close=111.1 , Volume=30844714 , LastDate=DateTime.Today , MarketCap=52933591040 ,  } ,
                new Security { Id=43 , SecurityCode = "RSP" , SecurityName = "Guggenheim Invest S&P 500 Eql Wght" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=80.2 , High=80.2 , Low=79.201 , Close=79.34 , Volume=994383 , LastDate=DateTime.Today , MarketCap=5891698176 ,  } ,
                new Security { Id=44 , SecurityCode = "SLYG" , SecurityName = "SPDR S&P 600 Small Cap Growth" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=191.23 , High=191.23 , Low=188.464 , Close=188.807 , Volume=5750 , LastDate=DateTime.Today , MarketCap=311532896 ,  } ,
                new Security { Id=45 , SecurityCode = "SPY" , SecurityName = "SPDR S&P 500" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=210.3 , High=210.37 , Low=207.6 , Close=208 , Volume=117754976 , LastDate=DateTime.Today , MarketCap=175870672896 ,  } ,
                new Security { Id=46 , SecurityCode = "STW" , SecurityName = "SPDR S&P/ASX 200 Fund" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=51.87 , High=52.3 , Low=51.73 , Close=51.91 , Volume=219209 , LastDate=DateTime.Today , MarketCap=3048709632 ,  } ,
                new Security { Id=47 , SecurityCode = "VTI" , SecurityName = "Vanguard Total Stock Market Index" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=108.75 , High=108.83 , Low=107.389 , Close=107.56 , Volume=2073472 , LastDate=DateTime.Today , MarketCap=41337896960 ,  } ,
                new Security { Id=48 , SecurityCode = "XLB" , SecurityName = "Materials Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=46.08 , High=46.1 , Low=44.785 , Close=45.08 , Volume=7262228 , LastDate=DateTime.Today , MarketCap=3215273728 ,  } ,
                new Security { Id=49 , SecurityCode = "XLE" , SecurityName = "Energy Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=70.87 , High=70.9 , Low=69.25 , Close=69.51 , Volume=12554077 , LastDate=DateTime.Today , MarketCap=6577328128 ,  } ,
                new Security { Id=50 , SecurityCode = "XLF" , SecurityName = "Financial Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=25.33 , High=25.35 , Low=25.08 , Close=25.12 , Volume=26116668 , LastDate=DateTime.Today , MarketCap=18949156864 ,  } ,
                new Security { Id=51 , SecurityCode = "XLI" , SecurityName = "Industrial Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=53.58 , High=53.62 , Low=52.81 , Close=52.9 , Volume=10889114 , LastDate=DateTime.Today , MarketCap=7116425728 ,  } ,
                new Security { Id=52 , SecurityCode = "XLK" , SecurityName = "Technology Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=42.8 , High=42.86 , Low=42.325 , Close=42.36 , Volume=9746087 , LastDate=DateTime.Today , MarketCap=15205371904 ,  } ,
                new Security { Id=53 , SecurityCode = "AIG" , SecurityName = "American International Group Inc" , Exchange = "XNYS" , Type = "Fully Paid Ordinary/Common Stock" , GicsSector = "Financials" , IcbIndustry = "Financials" , Open=64.19 , High=64.35 , Low=63.57 , Close=63.64 , Volume=4468544 , LastDate=DateTime.Today , MarketCap=93954965504 ,  } ,
                new Security { Id=54 , SecurityCode = "DBC" , SecurityName = "PowerShares DB Commodity Index Tracking" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=16.2 , High=16.23 , Low=16.065 , Close=16.14 , Volume=1264790 , LastDate=DateTime.Today , MarketCap=3993036544 ,  } ,
                new Security { Id=55 , SecurityCode = "EWH" , SecurityName = "iShares MSCI Hong Kong" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=22.41 , High=22.441 , Low=22.26 , Close=22.31 , Volume=2177659 , LastDate=DateTime.Today , MarketCap=2580151552 ,  } ,
                new Security { Id=56 , SecurityCode = "GCC" , SecurityName = "GreenHaven Continuous Commodity Index" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=20.45 , High=20.45 , Low=20.3 , Close=20.36 , Volume=82625 , LastDate=DateTime.Today , MarketCap=276896000 ,  } ,
                new Security { Id=57 , SecurityCode = "IJH" , SecurityName = "iShares Core S&P Mid-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=148.68 , High=148.95 , Low=147.11 , Close=147.38 , Volume=922986 , LastDate=DateTime.Today , MarketCap=23396575232 ,  } ,
                new Security { Id=58 , SecurityCode = "ISO" , SecurityName = "iShares S&P/ASX Small Ordinaries ETF" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=3.77 , High=3.77 , Low=3.77 , Close=3.77 , Volume=4920 , LastDate=DateTime.Today , MarketCap=31835192 ,  } ,
                new Security { Id=59 , SecurityCode = "IVOO" , SecurityName = "Vanguard S&P Mid Cap 400" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=100.74 , High=100.8 , Low=99.6 , Close=99.79 , Volume=11675 , LastDate=DateTime.Today , MarketCap=239496240 ,  } ,
                new Security { Id=60 , SecurityCode = "IWB" , SecurityName = "iShares Russell 1000" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=117.67 , High=117.67 , Low=116.12 , Close=116.32 , Volume=626697 , LastDate=DateTime.Today , MarketCap=9863936000 ,  } ,
                new Security { Id=61 , SecurityCode = "IWC" , SecurityName = "iShares Micro-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=79.45 , High=79.45 , Low=78.02 , Close=78.14 , Volume=93249 , LastDate=DateTime.Today , MarketCap=906424000 ,  } ,
                new Security { Id=62 , SecurityCode = "IWR" , SecurityName = "iShares Russell Mid-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=170.11 , High=170.197 , Low=168.22 , Close=168.51 , Volume=250667 , LastDate=DateTime.Today , MarketCap=10178003968 ,  } ,
                new Security { Id=63 , SecurityCode = "JKG" , SecurityName = "iShares Morningstar Mid-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=150.72 , High=150.72 , Low=148.96 , Close=149.21 , Volume=18235 , LastDate=DateTime.Today , MarketCap=283499008 ,  } ,
                new Security { Id=64 , SecurityCode = "JKJ" , SecurityName = "iShares Morningstar Small-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=139.707 , High=139.71 , Low=138.91 , Close=138.96 , Volume=2950 , LastDate=DateTime.Today , MarketCap=208440016 ,  } ,
                new Security { Id=65 , SecurityCode = "SLY" , SecurityName = "SPDR S&P 600 Small Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=107.98 , High=107.98 , Low=105.63 , Close=105.78 , Volume=10804 , LastDate=DateTime.Today , MarketCap=407255424 ,  } ,
                new Security { Id=66 , SecurityCode = "SSO" , SecurityName = "SPDR S&P/ASX Small Ordinaries Fund" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=11.07 , High=11.07 , Low=11.07 , Close=11.07 , Volume=8941 , LastDate=DateTime.Today , MarketCap=7781978 ,  } ,
                new Security { Id=67 , SecurityCode = "VB" , SecurityName = "Vanguard Small-Cap Index" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=120.7 , High=120.94 , Low=119.1 , Close=119.27 , Volume=518745 , LastDate=DateTime.Today , MarketCap=8595350528 ,  } ,
                new Security { Id=68 , SecurityCode = "VIOO" , SecurityName = "Vanguard S&P Small Cap 600" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=105.67 , High=105.7 , Low=104.21 , Close=104.36 , Volume=7983 , LastDate=DateTime.Today , MarketCap=104360000 ,  } ,
                new Security { Id=69 , SecurityCode = "VO" , SecurityName = "Vanguard Mid-Cap Index" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=127.65 , High=127.97 , Low=126.46 , Close=126.72 , Volume=271426 , LastDate=DateTime.Today , MarketCap=7077476864 ,  } ,
                new Security { Id=70 , SecurityCode = "VONE" , SecurityName = "Vanguard Russell 1000 Index" , Exchange = "XNAS" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=97.18 , High=97.18 , Low=95.983 , Close=96.06 , Volume=12935 , LastDate=DateTime.Today , MarketCap=278573984 ,  } ,
                new Security { Id=71 , SecurityCode = "VSO" , SecurityName = "Vanguard MSCI Australian Small Companies Index ETF" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=43.3 , High=43.3 , Low=42.96 , Close=42.96 , Volume=2747 , LastDate=DateTime.Today , MarketCap=75925400 ,  } ,
                new Security { Id=72 , SecurityCode = "VTWO" , SecurityName = "Vanguard Russell 2000 Index" , Exchange = "XNAS" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=99.41 , High=99.44 , Low=97.88 , Close=97.89 , Volume=26883 , LastDate=DateTime.Today , MarketCap=313248000 ,  } ,
                new Security { Id=73 , SecurityCode = "VV" , SecurityName = "Vanguard Large-Cap Index" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=96.83 , High=96.83 , Low=95.525 , Close=95.66 , Volume=131055 , LastDate=DateTime.Today , MarketCap=5216196096 ,  } ,
                new Security { Id=74 , SecurityCode = "$DJUSBM" , SecurityName = "DJ US Basic Materials" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Basic Materials" , Open=304.5 , High=304.5 , Low=295.83 , Close=297.55 , Volume=234800000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=75 , SecurityCode = "$DJUSCY" , SecurityName = "DJ US Consumer Services" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Consumer Services" , Open=750.94 , High=761.29 , Low=748.6 , Close=749.27 , Volume=540099968 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=76 , SecurityCode = "$DJUSEN" , SecurityName = "DJ US Oil & Gas" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Oil & Gas" , Open=593.19 , High=593.19 , Low=578.79 , Close=580.83 , Volume=456800000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=77 , SecurityCode = "$DJUSFN" , SecurityName = "DJ US Financials" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Financials" , Open=461.92 , High=463.26 , Low=458.84 , Close=459.32 , Volume=634499968 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=78 , SecurityCode = "$DJUSHC" , SecurityName = "DJ US Health Care" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Health Care" , Open=821.68 , High=821.68 , Low=800.3 , Close=801.43 , Volume=256400000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=79 , SecurityCode = "$DJUSIN" , SecurityName = "DJ US Industrials" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Industrials" , Open=503.68 , High=503.87 , Low=497.28 , Close=497.99 , Volume=329300000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=80 , SecurityCode = "$DJUSNC" , SecurityName = "DJ US Consumer Goods" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Consumer Goods" , Open=538.25 , High=538.45 , Low=532.81 , Close=533.88 , Volume=258100000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=81 , SecurityCode = "$DJUSTC" , SecurityName = "DJ US Technology" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Technology" , Open=1107.07 , High=1109.91 , Low=1095.65 , Close=1097.72 , Volume=653000000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=82 , SecurityCode = "$DJUSTL" , SecurityName = "DJ US Telecommunications" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Telecommunications" , Open=159.34 , High=161.37 , Low=158.99 , Close=159 , Volume=194900000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=83 , SecurityCode = "$DJUSUT" , SecurityName = "DJ US Utilities" , Exchange = "XASE" , Type = "Index" , GicsSector = "-" , IcbIndustry = "Utilities" , Open=209.22 , High=209.98 , Low=208.64 , Close=209.21 , Volume=108800000 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=84 , SecurityCode = "GLD" , SecurityName = "SPDR Gold Shares" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=103.61 , High=105.59 , Low=103.431 , Close=105.35 , Volume=11572679 , LastDate=DateTime.Today , MarketCap=32026398720 ,  } ,
                new Security { Id=85 , SecurityCode = "XLP" , SecurityName = "Consumer Staples Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=50.08 , High=50.08 , Low=49.62 , Close=49.68 , Volume=9950133 , LastDate=DateTime.Today , MarketCap=7694031360 ,  } ,
                new Security { Id=86 , SecurityCode = "XLU" , SecurityName = "Utilities Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=42.31 , High=42.48 , Low=42.18 , Close=42.33 , Volume=8589088 , LastDate=DateTime.Today , MarketCap=6117707776 ,  } ,
                new Security { Id=87 , SecurityCode = "XLV" , SecurityName = "Health Care Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=76 , High=76.05 , Low=74.71 , Close=74.85 , Volume=13229714 , LastDate=DateTime.Today , MarketCap=10989126656 ,  } ,
                new Security { Id=88 , SecurityCode = "XLY" , SecurityName = "Consumer Discretionary Select Sector SPDR" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=80.4 , High=80.4 , Low=78.71 , Close=78.85 , Volume=5169588 , LastDate=DateTime.Today , MarketCap=8449033216 ,  } ,
                new Security { Id=89 , SecurityCode = "$XJO" , SecurityName = "S&P/ASX 200" , Exchange = "XASX" , Type = "Index" , GicsSector = "-" , IcbIndustry = "-" , Open=5590.3 , High=5607.2 , Low=5548 , Close=5566.104 , Volume=501593760 , LastDate=DateTime.Today , MarketCap=0 ,  } ,
                new Security { Id=90 , SecurityCode = "EWJ" , SecurityName = "iShares MSCI Japan" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=12.85 , High=12.86 , Low=12.74 , Close=12.75 , Volume=34955536 , LastDate=DateTime.Today , MarketCap=12262949888 ,  } ,
                new Security { Id=91 , SecurityCode = "FXI" , SecurityName = "iShares China Large-Cap" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=42.15 , High=42.17 , Low=41.47 , Close=41.74 , Volume=25727056 , LastDate=DateTime.Today , MarketCap=6298566144 ,  } ,
                new Security { Id=92 , SecurityCode = "IYR" , SecurityName = "iShares US Real Estate" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=73.96 , High=74.28 , Low=73.7 , Close=73.95 , Volume=5631997 , LastDate=DateTime.Today , MarketCap=4947254784 ,  } ,
                new Security { Id=93 , SecurityCode = "MDY" , SecurityName = "SPDR S&P MidCap 400" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=270.89 , High=271.47 , Low=268.09 , Close=268.52 , Volume=2469589 , LastDate=DateTime.Today , MarketCap=16474650624 ,  } ,
                new Security { Id=94 , SecurityCode = "IVV" , SecurityName = "iShares Core S&P 500" , Exchange = "ARCX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "Financials" , Open=211.56 , High=211.64 , Low=208.86 , Close=209.25 , Volume=3545266 , LastDate=DateTime.Today , MarketCap=55346626560 ,  } ,
                new Security { Id=95 , SecurityCode = "SFY" , SecurityName = "SPDR S&P/ASX 50 Fund" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=54.43 , High=54.67 , Low=54.18 , Close=54.27 , Volume=24134 , LastDate=DateTime.Today , MarketCap=441048128 ,  } ,
                new Security { Id=96 , SecurityCode = "SLF" , SecurityName = "SPDR S&P/ASX 200 Listed Property Fund" , Exchange = "XASX" , Type = "Exchange Traded Fund" , GicsSector = "-" , IcbIndustry = "-" , Open=11.62 , High=11.7 , Low=11.46 , Close=11.52 , Volume=118828 , LastDate=DateTime.Today , MarketCap=564480000 ,  } ,

            };
            foreach (var sec in securities)
            {
                if (!context.Securities.Any(s => s.Id == s.Id))
                {
                    context.Securities.Add(sec);
                }
            }
        }
    }
}
