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
    using System.Reflection;
    using System.IO;
    using CsvHelper;
    using System.Text;
    using System.Diagnostics;
    using EntityFramework.Seeder;

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
            SeedSecurities(context);
            SeedWatclist(context);
            SeedWatchlistSecurities(context);
            SeedScanProfiles(context);
            SeedScanResults(context);
            SeedStockTransaction(context);

            SeedStockPrice(context);

            context.SaveChanges();
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
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "ShareWealth.Infrastructure.Migrations.SeedData.PortfolioProfiles.csv";
            context.Portfolios.SeedFromResource(resourceName, p => p.Id);

        }

        private void SeedPortfolioAdjustments(ApplicationDbContext context)
        {
            var portfolios = new List<PortfolioAdjustment>
            {
                new PortfolioAdjustment { Id = new Guid("f2c4e1bd-ba1b-4e86-9a33-7fb0cde128dd"), Date = new DateTime(2004,6,30), PortfolioId = new Guid("ad78931a-4bc3-4acd-8f9e-28d049e2e943"), Amount = 50000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = new Guid("ca1994c9-47fc-4f58-b47f-0b078e750d4e"), Date = new DateTime(2004,12,22), PortfolioId = new Guid("ad78931a-4bc3-4acd-8f9e-28d049e2e943"), Amount = 10000, Type = "Addition" },
                new PortfolioAdjustment { Id = new Guid("d462939b-f04a-4c6e-84ce-62037bd58746"), Date = new DateTime(2006,3,15), PortfolioId = new Guid("ad78931a-4bc3-4acd-8f9e-28d049e2e943"), Amount = 2500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = new Guid("998b9983-5765-4e38-90fd-5951daf09a3e"), Date = new DateTime(2007,8,30), PortfolioId = new Guid("b92bb8c6-ac24-43e0-8c54-b7e515392eda"), Amount = 75000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = new Guid("ad16846a-c38b-4531-8a91-581fe1acace1"), Date = new DateTime(2007,11,15), PortfolioId = new Guid("b92bb8c6-ac24-43e0-8c54-b7e515392eda"), Amount = 3500, Type = "Addition" },
                new PortfolioAdjustment { Id = new Guid("a496cbc6-99a4-4ddf-aa4a-a0c3a79bc7c3"), Date = new DateTime(2019,4,12), PortfolioId = new Guid("b92bb8c6-ac24-43e0-8c54-b7e515392eda"), Amount = 1500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = new Guid("2a09466d-ae35-4260-ab09-9c5cf745a435"), Date = new DateTime(2010,6,30), PortfolioId = new Guid("2a0063b6-d019-406c-a502-cbee64b96f3f"), Amount = 50000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = new Guid("02199b0e-18cd-4a97-874d-11494d3972f0"), Date = new DateTime(2011,12,22), PortfolioId = new Guid("2a0063b6-d019-406c-a502-cbee64b96f3f"), Amount = 10000, Type = "Addition" },
                new PortfolioAdjustment { Id = new Guid("5ba50714-75b9-45ec-80af-3893dbfe3bed"), Date = new DateTime(2012,3,15), PortfolioId = new Guid("2a0063b6-d019-406c-a502-cbee64b96f3f"), Amount = 2500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = new Guid("f69d71d6-8264-4cbb-b65f-26d2fde712b3"), Date = new DateTime(2013,8,30), PortfolioId = new Guid("020cd4ae-7663-4af7-836f-e1836a061d78"), Amount = 45000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = new Guid("23f94c68-f133-4fd1-abd5-ef9bd6a6af4c"), Date = new DateTime(2014,11,15), PortfolioId = new Guid("020cd4ae-7663-4af7-836f-e1836a061d78"), Amount = 2700, Type = "Addition" },
                new PortfolioAdjustment { Id = new Guid("9dd5d730-8ea9-4590-9da1-be3294fc4728"), Date = new DateTime(2015,4,12), PortfolioId = new Guid("020cd4ae-7663-4af7-836f-e1836a061d78"), Amount = 6700, Type = "Withdrawal" }
            };
            foreach (var pa in portfolios)
            {
                if (!context.PortfolioAdjustments.Any(p => p.Id == pa.Id))
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
                if (!context.Securities.Any(s => s.Id == sec.Id))
                {
                    context.Securities.Add(sec);
                }
            }
        }
        private void SeedWatclist(ApplicationDbContext context)
        {
            var watchlist = new List<Watchlist> {
                new Watchlist { Id= new Guid("343910c8-bac2-4a27-8c9d-04553331b890") , Name = "ETF Watch List" , Type = "User Defined" },
                new Watchlist { Id= new Guid("2b6a9605-6788-4ad3-bd7e-58d875871ce9") , Name = "SPA3 Watch List" , Type = "User Defined" },
                new Watchlist { Id= new Guid("450c5f05-310a-497a-a551-1a5a0b007f4c") , Name = "Portfolio Watch List" , Type = "Portfolio" },
                new Watchlist { Id= new Guid("91ce62ac-3599-4918-bb23-a4ca9ff16c68") , Name = "Prospect Watch List" , Type = "Portfolio" },
                new Watchlist { Id= new Guid("28ebc087-53ce-40b5-a70c-9cb6737a03b2") , Name = "All Ordinaries" , Type = "Industry" },
                new Watchlist { Id= new Guid("796eff1d-fa32-40d6-85c8-31474012ccb4") , Name = "ASX Dividend Paying Securities" , Type = "Industry" },
                new Watchlist { Id= new Guid("407c8f1d-ff00-4506-a735-5977bcb986e7") , Name = "ASX Franked Dividend Paying Securities" , Type = "Industry" },
                new Watchlist { Id= new Guid("baa40c00-bd1d-4f8c-a2ac-411db81641f2") , Name = "ASX Fully Paid Ordinary" , Type = "Industry" },
                new Watchlist { Id= new Guid("e898083f-245d-4616-ac77-1b467f6ee9c6") , Name = "ASX Positive PE Ratio Securities" , Type = "Industry" },
                new Watchlist { Id= new Guid("545e684f-1c71-48ec-bfa6-b63fb2ac0e33") , Name = "Dow Jones Composite Average" , Type = "Industry" },
                new Watchlist { Id= new Guid("8e090e5b-a599-43b0-b7e5-38724fc37377") , Name = "Dow Jones Industrial Average" , Type = "Industry" },
                new Watchlist { Id= new Guid("604cff4d-9ce6-4513-8db7-d4bd5e6342e5") , Name = "Dow Jones Transportation Average" , Type = "Industry" },
                new Watchlist { Id= new Guid("abe23978-1f61-4a4c-9156-af86ca76e549") , Name = "Dow Jones US Index" , Type = "Industry" },
                new Watchlist { Id= new Guid("aa87a9c9-3fc6-4893-9353-02bebe7e782f") , Name = "Dow Jones Utility Average" , Type = "Industry" },
                new Watchlist { Id= new Guid("80a54d7c-4bc9-4662-8aa5-753a6f32f5cd") , Name = "IG Markets ASX Share CFDs" , Type = "Industry" },
                new Watchlist { Id= new Guid("9ac71354-5f74-4aba-ba36-3dcab9ebaa44") , Name = "IG Markets ASX Share CFDs Shortable" , Type = "Industry" },
                new Watchlist { Id= new Guid("db39e260-101d-4582-a0c3-8ef6eba34b1c") , Name = "IG Markets US Share CFDs" , Type = "Industry" },
                new Watchlist { Id= new Guid("9b6205d3-5bd4-4d13-86eb-a49bcee4528d") , Name = "IG Markets US Share CFDs Shortable" , Type = "Industry" },
                new Watchlist { Id= new Guid("01a1137c-5a27-4c24-afe8-7f0fe2302d29") , Name = "NASDAQ 100" , Type = "Industry" },
                new Watchlist { Id= new Guid("a2b18656-0648-44f5-ac68-43444eca6b86") , Name = "NASDAQ Bank" , Type = "Industry" },
                new Watchlist { Id= new Guid("bb8de9b3-857d-4a81-9608-cf883d43d90f") , Name = "NASDAQ Biotechnology" , Type = "Industry" },
                new Watchlist { Id= new Guid("0c13f891-ecad-4be4-ba64-d9519b59bb92") , Name = "NASDAQ Common Shares" , Type = "Industry" },
                new Watchlist { Id= new Guid("8020c7ea-d7d0-447c-9c01-c4212b32e17f") , Name = "NASDAQ Computer" , Type = "Industry" },
                new Watchlist { Id= new Guid("01c43c01-eb08-4f08-bcee-56aba256075f") , Name = "NASDAQ Financial 100" , Type = "Industry" },
                new Watchlist { Id= new Guid("5cb67667-08f3-4966-8370-a905d388cdab") , Name = "NASDAQ Industrial" , Type = "Industry" },
                new Watchlist { Id= new Guid("b3e8ebd1-c8f7-4502-992d-846f7b356c19") , Name = "NASDAQ Insurance" , Type = "Industry" },
                new Watchlist { Id= new Guid("c9b505f0-3a52-4389-a55b-accc390c0cee") , Name = "NASDAQ Other Finance" , Type = "Industry" },
                new Watchlist { Id= new Guid("ed245cb4-d809-484b-9c38-ff447451ba7c") , Name = "NASDAQ Telecommunications" , Type = "Industry" },
                new Watchlist { Id= new Guid("abfb2557-0aa9-4342-acf1-40d0851300d5") , Name = "NASDAQ Transportation" , Type = "Industry" },
                new Watchlist { Id= new Guid("484db3e9-f9d5-4ae2-a173-624f2f0e6d72") , Name = "Russell 1000" , Type = "Industry" },
                new Watchlist { Id= new Guid("69ee6688-f1b9-4e88-8f6e-4cc3b5f737af") , Name = "Russell 2000" , Type = "Industry" },
                new Watchlist { Id= new Guid("aa68bb72-bf2f-481b-92e1-0f9acab96f4d") , Name = "Russell 3000" , Type = "Industry" },
                new Watchlist { Id= new Guid("b6dadfac-4137-41b0-a924-2a547b9d8d13") , Name = "Russell Micro Cap" , Type = "Industry" },
                new Watchlist { Id= new Guid("0ee86fc0-60d7-487a-981c-5fcb337b8b97") , Name = "Russell Mid Cap" , Type = "Industry" },
                new Watchlist { Id= new Guid("3432bbb1-6ff6-42f2-9174-3546abce1add") , Name = "S&P 100" , Type = "Industry" },
                new Watchlist { Id= new Guid("6dec1419-4264-46bd-9ced-3efe9309a590") , Name = "S&P 500" , Type = "Industry" },
                new Watchlist { Id= new Guid("9e5b2fdc-2b2d-417d-929e-d0c076fa9a63") , Name = "S&P ASX100" , Type = "Industry" },
                new Watchlist { Id= new Guid("35d00703-469a-4b87-8e82-cab8eb26d17d") , Name = "S&P ASX20" , Type = "Industry" },
                new Watchlist { Id= new Guid("6298f232-6993-48e1-bfe2-2465822ae1d0") , Name = "S&P ASX200" , Type = "Industry" },
                new Watchlist { Id= new Guid("3e3fb52f-a11c-455d-b747-f50669df1cd4") , Name = "S&P ASX300" , Type = "Industry" },
                new Watchlist { Id= new Guid("49d215c4-a60c-4518-97b9-717b407f607a") , Name = "S&P ASX50" , Type = "Industry" },
                new Watchlist { Id= new Guid("2c2f0f42-82ba-4fd7-a115-8e25b9b84c34") , Name = "S&P Composite 1500" , Type = "Industry" },
                new Watchlist { Id= new Guid("cf2dfed0-753c-47be-be1d-fd6e92e1547d") , Name = "S&P MidCap 400" , Type = "Industry" },
                new Watchlist { Id= new Guid("f11e452e-9a35-4afa-8f54-75191771abd6") , Name = "S&P SmallCap 600" , Type = "Industry" },
                new Watchlist { Id= new Guid("91eea4cb-3768-4e99-9960-96c1c352fe60") , Name = "S&P/ASX Emerging Companies" , Type = "Industry" },
                new Watchlist { Id= new Guid("f6a7c172-1d03-4117-8097-1b8a6e21e72d") , Name = "S&P/ASX MidCap 50" , Type = "Industry" },
                new Watchlist { Id= new Guid("0b394c44-50ed-4f5e-adad-59713fac4399") , Name = "S&P/ASX MidCap 50 Industrials" , Type = "Industry" },
                new Watchlist { Id= new Guid("9274d528-794b-4ead-ae53-98f042a50856") , Name = "S&P/ASX MidCap 50 Resources" , Type = "Industry" },
                new Watchlist { Id= new Guid("741cd6bb-f36a-4af5-bda2-37e11a7eea28") , Name = "S&P/ASX Small Industrials" , Type = "Industry" },
                new Watchlist { Id= new Guid("32da8ce6-8557-4bb1-a05d-a78393798168") , Name = "S&P/ASX Small Ordinaries" , Type = "Industry" },
                new Watchlist { Id= new Guid("73b0b71d-d9cf-4bd2-91a9-9b654386e190") , Name = "S&P/ASX Small Resources" , Type = "Industry" },
                new Watchlist { Id= new Guid("b8f243e5-ee6b-4827-871d-9d23c227f321") , Name = "Saxo Capital Markets ASX Share CFDs" , Type = "Industry" },
                new Watchlist { Id= new Guid("a773c637-681c-4f33-9ea5-e3e56f88214e") , Name = "Saxo Capital Markets ASX Share CFDs Shortable" , Type = "Industry" },
                new Watchlist { Id= new Guid("0a15dce5-cffd-447b-b14a-536edcaff1bd") , Name = "Saxo Capital Markets US Share CFDs" , Type = "Industry" },
                new Watchlist { Id= new Guid("58eaa8b4-f76d-4818-9753-34d442e0fb0d") , Name = "Saxo Capital Markets US Share CFDs Shortable" , Type = "Industry" },
                new Watchlist { Id= new Guid("07766517-9d61-42b3-a657-406ecc8d94a7") , Name = "USA - Closed-End Fund Share" , Type = "Industry" },
                new Watchlist { Id= new Guid("cfd30050-341e-4453-80b8-0fe14634290e") , Name = "USA - Common" , Type = "Industry" },
                new Watchlist { Id= new Guid("9b0d7b68-6f99-4361-bf88-f8fd69ee304c") , Name = "USA - Exchange Traded Fund" , Type = "Industry" },
                new Watchlist { Id= new Guid("d7a8934b-e958-4094-9e1d-0cb7f68c6fa5") , Name = "USA - Exchange Traded Note" , Type = "Industry" },
                new Watchlist { Id= new Guid("e51144a2-ae17-4fcc-8c6a-6d04fdc36d8d") , Name = "USA - OTCBB" , Type = "Industry" },
                new Watchlist { Id= new Guid("462d661e-7d5a-45e4-98c9-3c78aa1710df") , Name = "USA - Other OTC" , Type = "Industry" },
                new Watchlist { Id= new Guid("2b687a26-13d4-42cd-8759-b49164b07c4f") , Name = "USA - Pink OTC Markets" , Type = "Industry" },
                new Watchlist { Id= new Guid("0cc849ed-a76d-4928-a828-a90c0773cdbe") , Name = "USA - Preference" , Type = "Industry" },

            };

            foreach (var wl in watchlist)
            {
                if (!context.Watchlists.Any(w => w.Name == wl.Name))
                {
                    context.Watchlists.Add(wl);
                }
            }
        }
        private void SeedWatchlistSecurities(ApplicationDbContext context)
        {
            var watchlistSec = new List<WatchlistSecurity> 
            {
                new WatchlistSecurity { Id= new Guid("745efb32-18e7-49df-a39a-941feebb1ff6") , WatchlistId= new Guid("343910c8-bac2-4a27-8c9d-04553331b890") , SecurityId = 1 },
                new WatchlistSecurity { Id= new Guid("cac7d560-d598-40a8-8662-44bed9a7ee5f") , WatchlistId= new Guid("2b6a9605-6788-4ad3-bd7e-58d875871ce9") , SecurityId = 2 },
                new WatchlistSecurity { Id= new Guid("88de4629-6580-4ab2-b024-eea2733c5b70") , WatchlistId= new Guid("450c5f05-310a-497a-a551-1a5a0b007f4c") , SecurityId = 3 },
                new WatchlistSecurity { Id= new Guid("41f3b249-0357-473b-909f-7e0585a2323b") , WatchlistId= new Guid("91ce62ac-3599-4918-bb23-a4ca9ff16c68") , SecurityId = 4 },
                new WatchlistSecurity { Id= new Guid("af48aa7d-eee4-4878-a581-1acf84ed6dfd") , WatchlistId= new Guid("28ebc087-53ce-40b5-a70c-9cb6737a03b2") , SecurityId = 5 },
                new WatchlistSecurity { Id= new Guid("7a695b66-da32-49a2-8fb3-01cb7abe0397") , WatchlistId= new Guid("796eff1d-fa32-40d6-85c8-31474012ccb4") , SecurityId = 6 },
                new WatchlistSecurity { Id= new Guid("9593c2b2-b19d-40f9-b25e-a31dec3ae940") , WatchlistId= new Guid("407c8f1d-ff00-4506-a735-5977bcb986e7") , SecurityId = 7 },
                new WatchlistSecurity { Id= new Guid("acd20114-18c2-4f10-963b-495faceddb14") , WatchlistId= new Guid("baa40c00-bd1d-4f8c-a2ac-411db81641f2") , SecurityId = 8 },
                new WatchlistSecurity { Id= new Guid("281d2b37-6002-4a9d-8eaf-71a12281b5e4") , WatchlistId= new Guid("e898083f-245d-4616-ac77-1b467f6ee9c6") , SecurityId = 9 },
                new WatchlistSecurity { Id= new Guid("e7e2a87a-599f-4a36-92b3-85ffb96deb44") , WatchlistId= new Guid("545e684f-1c71-48ec-bfa6-b63fb2ac0e33") , SecurityId = 10 },
                new WatchlistSecurity { Id= new Guid("e49e2ddd-8ca0-4585-b087-5aafdfa561b2") , WatchlistId= new Guid("8e090e5b-a599-43b0-b7e5-38724fc37377") , SecurityId = 11 },
                new WatchlistSecurity { Id= new Guid("9f26fd3a-2d5a-45e1-84c5-e41bd612ac02") , WatchlistId= new Guid("604cff4d-9ce6-4513-8db7-d4bd5e6342e5") , SecurityId = 12 },
                new WatchlistSecurity { Id= new Guid("8f6978f8-1da6-4e15-9cd2-ef2c757ac26f") , WatchlistId= new Guid("abe23978-1f61-4a4c-9156-af86ca76e549") , SecurityId = 13 },
                new WatchlistSecurity { Id= new Guid("4345412a-e2a8-4edb-b565-3ae457ab6f4d") , WatchlistId= new Guid("aa87a9c9-3fc6-4893-9353-02bebe7e782f") , SecurityId = 14 },
                new WatchlistSecurity { Id= new Guid("129e754e-d696-4f31-98df-3e97161a15fb") , WatchlistId= new Guid("80a54d7c-4bc9-4662-8aa5-753a6f32f5cd") , SecurityId = 15 },
                new WatchlistSecurity { Id= new Guid("e2379161-39d2-41ac-998b-6d1cfe0090c5") , WatchlistId= new Guid("9ac71354-5f74-4aba-ba36-3dcab9ebaa44") , SecurityId = 16 },
                new WatchlistSecurity { Id= new Guid("23b7a93e-7656-4f0a-bf53-8a03e8cee905") , WatchlistId= new Guid("db39e260-101d-4582-a0c3-8ef6eba34b1c") , SecurityId = 17 },
                new WatchlistSecurity { Id= new Guid("e4f5df53-aa8d-4d49-8816-6252db90dccb") , WatchlistId= new Guid("9b6205d3-5bd4-4d13-86eb-a49bcee4528d") , SecurityId = 18 },
                new WatchlistSecurity { Id= new Guid("7f330be0-a734-4c65-85b5-cd64cbeb08f9") , WatchlistId= new Guid("01a1137c-5a27-4c24-afe8-7f0fe2302d29") , SecurityId = 19 },
                new WatchlistSecurity { Id= new Guid("d3f2e925-568b-45d8-8623-d75e88a450eb") , WatchlistId= new Guid("a2b18656-0648-44f5-ac68-43444eca6b86") , SecurityId = 20 },
                new WatchlistSecurity { Id= new Guid("c1d092d6-67b4-44c0-80ee-66d8fb28ce53") , WatchlistId= new Guid("bb8de9b3-857d-4a81-9608-cf883d43d90f") , SecurityId = 21 },
                new WatchlistSecurity { Id= new Guid("abdb473c-ef9c-489c-ac1a-984d2aaaae05") , WatchlistId= new Guid("0c13f891-ecad-4be4-ba64-d9519b59bb92") , SecurityId = 22 },
                new WatchlistSecurity { Id= new Guid("123df277-f94e-487d-af55-6b0c07b44000") , WatchlistId= new Guid("8020c7ea-d7d0-447c-9c01-c4212b32e17f") , SecurityId = 23 },
                new WatchlistSecurity { Id= new Guid("f3acc25d-e212-4c2e-8f97-92b29f788031") , WatchlistId= new Guid("01c43c01-eb08-4f08-bcee-56aba256075f") , SecurityId = 24 },
                new WatchlistSecurity { Id= new Guid("3c836eae-b5d0-4a2d-88b8-5000b3bcf725") , WatchlistId= new Guid("5cb67667-08f3-4966-8370-a905d388cdab") , SecurityId = 25 },
                new WatchlistSecurity { Id= new Guid("bdb9dd29-4de5-4844-88ae-a1e3ca0137bd") , WatchlistId= new Guid("b3e8ebd1-c8f7-4502-992d-846f7b356c19") , SecurityId = 26 },
                new WatchlistSecurity { Id= new Guid("81257e67-3df5-4b34-9cf0-6e831317cf6c") , WatchlistId= new Guid("c9b505f0-3a52-4389-a55b-accc390c0cee") , SecurityId = 27 },
                new WatchlistSecurity { Id= new Guid("86326d7c-97a3-4fef-a697-a93d3268dae0") , WatchlistId= new Guid("ed245cb4-d809-484b-9c38-ff447451ba7c") , SecurityId = 28 },
                new WatchlistSecurity { Id= new Guid("4413fb9e-3c79-4e60-ae0a-e5e222f5f9a8") , WatchlistId= new Guid("abfb2557-0aa9-4342-acf1-40d0851300d5") , SecurityId = 29 },
                new WatchlistSecurity { Id= new Guid("b735eb50-8250-4b59-b91a-3444f162e9a3") , WatchlistId= new Guid("484db3e9-f9d5-4ae2-a173-624f2f0e6d72") , SecurityId = 30 },
                new WatchlistSecurity { Id= new Guid("a941dc68-99dc-4a78-9a6c-17fa0e047de2") , WatchlistId= new Guid("69ee6688-f1b9-4e88-8f6e-4cc3b5f737af") , SecurityId = 31 },
                new WatchlistSecurity { Id= new Guid("8ab85f68-d054-44db-b8d4-6daf71904857") , WatchlistId= new Guid("aa68bb72-bf2f-481b-92e1-0f9acab96f4d") , SecurityId = 32 },
                new WatchlistSecurity { Id= new Guid("c138da71-dfd8-4f9c-a536-e0b1707d19e6") , WatchlistId= new Guid("b6dadfac-4137-41b0-a924-2a547b9d8d13") , SecurityId = 33 },
                new WatchlistSecurity { Id= new Guid("856fe818-9047-42f7-835c-fb564d7b944a") , WatchlistId= new Guid("0ee86fc0-60d7-487a-981c-5fcb337b8b97") , SecurityId = 34 },
                new WatchlistSecurity { Id= new Guid("08b5e731-5401-479a-94f7-41abcc314849") , WatchlistId= new Guid("3432bbb1-6ff6-42f2-9174-3546abce1add") , SecurityId = 35 },
                new WatchlistSecurity { Id= new Guid("f99e431f-55de-49c8-82e2-f1a7d6f37691") , WatchlistId= new Guid("6dec1419-4264-46bd-9ced-3efe9309a590") , SecurityId = 36 },
                new WatchlistSecurity { Id= new Guid("1ee555ff-fbfa-452e-9750-27340918ed92") , WatchlistId= new Guid("9e5b2fdc-2b2d-417d-929e-d0c076fa9a63") , SecurityId = 37 },
                new WatchlistSecurity { Id= new Guid("22d5196a-5586-4cf3-ad35-a89c6d6e79b0") , WatchlistId= new Guid("35d00703-469a-4b87-8e82-cab8eb26d17d") , SecurityId = 38 },
                new WatchlistSecurity { Id= new Guid("58a462c9-de12-4802-8ab1-e5d6161566b4") , WatchlistId= new Guid("6298f232-6993-48e1-bfe2-2465822ae1d0") , SecurityId = 39 },
                new WatchlistSecurity { Id= new Guid("ac9e49a4-66e8-476f-82a5-8fdb61230047") , WatchlistId= new Guid("3e3fb52f-a11c-455d-b747-f50669df1cd4") , SecurityId = 40 },
                new WatchlistSecurity { Id= new Guid("070315bb-36c8-408f-8080-9ce5cbe630cd") , WatchlistId= new Guid("49d215c4-a60c-4518-97b9-717b407f607a") , SecurityId = 41 },
                new WatchlistSecurity { Id= new Guid("8cc9d778-47ef-4121-b9ef-3fbc61520ac4") , WatchlistId= new Guid("2c2f0f42-82ba-4fd7-a115-8e25b9b84c34") , SecurityId = 42 },
                new WatchlistSecurity { Id= new Guid("f6ca684b-6409-4b2d-b8ad-b92b1cd3c536") , WatchlistId= new Guid("cf2dfed0-753c-47be-be1d-fd6e92e1547d") , SecurityId = 43 },
                new WatchlistSecurity { Id= new Guid("3622240b-b2ed-437c-990b-8f6636b3b0ce") , WatchlistId= new Guid("f11e452e-9a35-4afa-8f54-75191771abd6") , SecurityId = 44 },
                new WatchlistSecurity { Id= new Guid("3dc40ab5-24b3-4ef8-973e-5c98761421d2") , WatchlistId= new Guid("91eea4cb-3768-4e99-9960-96c1c352fe60") , SecurityId = 45 },
                new WatchlistSecurity { Id= new Guid("37e87cd1-5c41-42b6-ba2f-58278859a682") , WatchlistId= new Guid("f6a7c172-1d03-4117-8097-1b8a6e21e72d") , SecurityId = 46 },
                new WatchlistSecurity { Id= new Guid("49fc1d95-6f49-4aaa-8443-f9a73779e2ef") , WatchlistId= new Guid("0b394c44-50ed-4f5e-adad-59713fac4399") , SecurityId = 47 },
                new WatchlistSecurity { Id= new Guid("90a7ff42-2a2f-4029-a51b-4c442bba2c0c") , WatchlistId= new Guid("9274d528-794b-4ead-ae53-98f042a50856") , SecurityId = 48 },
                new WatchlistSecurity { Id= new Guid("199a516a-3ba5-497c-8bff-72a59c2354e3") , WatchlistId= new Guid("741cd6bb-f36a-4af5-bda2-37e11a7eea28") , SecurityId = 49 },
                new WatchlistSecurity { Id= new Guid("6d9f638e-c93f-4c24-8047-509e1b56f45c") , WatchlistId= new Guid("32da8ce6-8557-4bb1-a05d-a78393798168") , SecurityId = 50 },
                new WatchlistSecurity { Id= new Guid("52977cda-df2b-41a2-ac3f-c73260b5b140") , WatchlistId= new Guid("73b0b71d-d9cf-4bd2-91a9-9b654386e190") , SecurityId = 51 },
                new WatchlistSecurity { Id= new Guid("af73e284-dac2-4933-94cc-75de383b870d") , WatchlistId= new Guid("b8f243e5-ee6b-4827-871d-9d23c227f321") , SecurityId = 52 },
                new WatchlistSecurity { Id= new Guid("9580bc05-2b2b-4842-aa7e-13f801ed4ac9") , WatchlistId= new Guid("a773c637-681c-4f33-9ea5-e3e56f88214e") , SecurityId = 53 },
                new WatchlistSecurity { Id= new Guid("2c467a0b-d9b5-4a71-a465-a10d2d821edb") , WatchlistId= new Guid("0a15dce5-cffd-447b-b14a-536edcaff1bd") , SecurityId = 54 },
                new WatchlistSecurity { Id= new Guid("46d8e384-c2a6-4cf7-9b3f-8218ddcf68ef") , WatchlistId= new Guid("58eaa8b4-f76d-4818-9753-34d442e0fb0d") , SecurityId = 55 },
                new WatchlistSecurity { Id= new Guid("e69a6b95-ffab-44a2-8489-3d4fd6231aa1") , WatchlistId= new Guid("07766517-9d61-42b3-a657-406ecc8d94a7") , SecurityId = 56 },
                new WatchlistSecurity { Id= new Guid("c5151237-8fd8-4fae-8284-f56b7bb860a0") , WatchlistId= new Guid("cfd30050-341e-4453-80b8-0fe14634290e") , SecurityId = 57 },
                new WatchlistSecurity { Id= new Guid("8f86bbf4-1905-4380-8a20-1aaa3179395a") , WatchlistId= new Guid("9b0d7b68-6f99-4361-bf88-f8fd69ee304c") , SecurityId = 58 },
                new WatchlistSecurity { Id= new Guid("76d13c60-01dd-4905-ba44-e74d219b1c3d") , WatchlistId= new Guid("d7a8934b-e958-4094-9e1d-0cb7f68c6fa5") , SecurityId = 59 },
                new WatchlistSecurity { Id= new Guid("dd1362cf-a8a7-41c7-9b8d-7447a297e0dd") , WatchlistId= new Guid("e51144a2-ae17-4fcc-8c6a-6d04fdc36d8d") , SecurityId = 60 },
                new WatchlistSecurity { Id= new Guid("0baaecd5-ccc0-48a3-8225-6a45c94517ce") , WatchlistId= new Guid("462d661e-7d5a-45e4-98c9-3c78aa1710df") , SecurityId = 61 },
                new WatchlistSecurity { Id= new Guid("a06f6a1c-7c63-41b8-be8c-2ced777b287b") , WatchlistId= new Guid("2b687a26-13d4-42cd-8759-b49164b07c4f") , SecurityId = 62 },
                new WatchlistSecurity { Id= new Guid("66d5c6d6-01cb-4e88-9a9a-3692da3c91ea") , WatchlistId= new Guid("0cc849ed-a76d-4928-a828-a90c0773cdbe") , SecurityId = 63 },
                new WatchlistSecurity { Id= new Guid("139734c9-f58d-4af4-a1eb-b1285170c196") , WatchlistId= new Guid("343910c8-bac2-4a27-8c9d-04553331b890") , SecurityId = 64 },
                new WatchlistSecurity { Id= new Guid("2d0c8167-e80d-489a-b5c8-b1f01ef67536") , WatchlistId= new Guid("2b6a9605-6788-4ad3-bd7e-58d875871ce9") , SecurityId = 65 },
                new WatchlistSecurity { Id= new Guid("76a916ad-11f6-4f67-806a-b9a9894fb406") , WatchlistId= new Guid("450c5f05-310a-497a-a551-1a5a0b007f4c") , SecurityId = 66 },
                new WatchlistSecurity { Id= new Guid("9a6b4396-c7c1-4282-b7eb-9f4925aff094") , WatchlistId= new Guid("91ce62ac-3599-4918-bb23-a4ca9ff16c68") , SecurityId = 67 },
                new WatchlistSecurity { Id= new Guid("e6f36cc9-4ecf-4859-8bde-13bd78e33212") , WatchlistId= new Guid("28ebc087-53ce-40b5-a70c-9cb6737a03b2") , SecurityId = 68 },
                new WatchlistSecurity { Id= new Guid("db4cf27d-d820-40e0-a24c-0522b7d5a470") , WatchlistId= new Guid("796eff1d-fa32-40d6-85c8-31474012ccb4") , SecurityId = 69 },
                new WatchlistSecurity { Id= new Guid("b1db957a-038e-4d88-9fd5-de619cb69a02") , WatchlistId= new Guid("407c8f1d-ff00-4506-a735-5977bcb986e7") , SecurityId = 70 },
                new WatchlistSecurity { Id= new Guid("4e771d6c-2222-47a8-8920-b6a8aa11121a") , WatchlistId= new Guid("baa40c00-bd1d-4f8c-a2ac-411db81641f2") , SecurityId = 71 },
                new WatchlistSecurity { Id= new Guid("f53c5f42-6611-46a9-b597-3f464a6819b5") , WatchlistId= new Guid("e898083f-245d-4616-ac77-1b467f6ee9c6") , SecurityId = 72 },
                new WatchlistSecurity { Id= new Guid("ed2c575a-018d-4eb8-a2b1-bdbdc778b4c5") , WatchlistId= new Guid("545e684f-1c71-48ec-bfa6-b63fb2ac0e33") , SecurityId = 73 },
                new WatchlistSecurity { Id= new Guid("40afc3f8-60ec-482e-acaf-80f5f7e3d689") , WatchlistId= new Guid("8e090e5b-a599-43b0-b7e5-38724fc37377") , SecurityId = 74 },
                new WatchlistSecurity { Id= new Guid("85a04cc3-316f-40d2-89cc-138b5bb8ff26") , WatchlistId= new Guid("604cff4d-9ce6-4513-8db7-d4bd5e6342e5") , SecurityId = 75 },
                new WatchlistSecurity { Id= new Guid("68f0326a-7dc9-49dc-9cba-1961c118e876") , WatchlistId= new Guid("abe23978-1f61-4a4c-9156-af86ca76e549") , SecurityId = 76 },
                new WatchlistSecurity { Id= new Guid("cddfe784-9276-4aec-8f58-7576e8afc474") , WatchlistId= new Guid("aa87a9c9-3fc6-4893-9353-02bebe7e782f") , SecurityId = 77 },
                new WatchlistSecurity { Id= new Guid("bdd0b85d-9e87-4edc-809f-fe1d7eeaae26") , WatchlistId= new Guid("80a54d7c-4bc9-4662-8aa5-753a6f32f5cd") , SecurityId = 78 },
                new WatchlistSecurity { Id= new Guid("71d2dabd-1acd-48b5-8221-630bd472728a") , WatchlistId= new Guid("9ac71354-5f74-4aba-ba36-3dcab9ebaa44") , SecurityId = 79 },
                new WatchlistSecurity { Id= new Guid("385912e5-d421-4b4d-a2d7-7dafdc9d6039") , WatchlistId= new Guid("db39e260-101d-4582-a0c3-8ef6eba34b1c") , SecurityId = 80 },
                new WatchlistSecurity { Id= new Guid("cabaa6aa-6d2a-49d6-8f12-4fbdfcf581d2") , WatchlistId= new Guid("9b6205d3-5bd4-4d13-86eb-a49bcee4528d") , SecurityId = 81 },
                new WatchlistSecurity { Id= new Guid("b950b38e-eeb5-415b-877b-667bff593a9d") , WatchlistId= new Guid("01a1137c-5a27-4c24-afe8-7f0fe2302d29") , SecurityId = 82 },
                new WatchlistSecurity { Id= new Guid("d42dd4d8-2228-411a-bbdc-4d0f8a9433f7") , WatchlistId= new Guid("a2b18656-0648-44f5-ac68-43444eca6b86") , SecurityId = 83 },
                new WatchlistSecurity { Id= new Guid("a665858d-e486-4585-addc-245305046182") , WatchlistId= new Guid("bb8de9b3-857d-4a81-9608-cf883d43d90f") , SecurityId = 84 },
                new WatchlistSecurity { Id= new Guid("349ef21d-3ff4-454d-b29a-5841817b3d41") , WatchlistId= new Guid("0c13f891-ecad-4be4-ba64-d9519b59bb92") , SecurityId = 85 },
                new WatchlistSecurity { Id= new Guid("c82eefd2-249b-443d-83b6-8b795d7cc1c4") , WatchlistId= new Guid("8020c7ea-d7d0-447c-9c01-c4212b32e17f") , SecurityId = 86 },
                new WatchlistSecurity { Id= new Guid("962fd5af-d9b3-4ab1-9a37-ce629129e049") , WatchlistId= new Guid("01c43c01-eb08-4f08-bcee-56aba256075f") , SecurityId = 87 },
                new WatchlistSecurity { Id= new Guid("d7fc65f4-e7c8-4b77-a4ea-401984763e61") , WatchlistId= new Guid("5cb67667-08f3-4966-8370-a905d388cdab") , SecurityId = 88 },
                new WatchlistSecurity { Id= new Guid("7026eb6d-01ea-49e2-83f8-d9ff8df041c0") , WatchlistId= new Guid("b3e8ebd1-c8f7-4502-992d-846f7b356c19") , SecurityId = 89 },
                new WatchlistSecurity { Id= new Guid("6a8da1d3-aac2-415c-98de-57e0465947a9") , WatchlistId= new Guid("c9b505f0-3a52-4389-a55b-accc390c0cee") , SecurityId = 90 },
                new WatchlistSecurity { Id= new Guid("bde50726-dce0-434f-b720-a0f68a773e6b") , WatchlistId= new Guid("ed245cb4-d809-484b-9c38-ff447451ba7c") , SecurityId = 91 },
                new WatchlistSecurity { Id= new Guid("ddf03344-63b5-4085-9dfe-e20b2983775b") , WatchlistId= new Guid("abfb2557-0aa9-4342-acf1-40d0851300d5") , SecurityId = 92 },
                new WatchlistSecurity { Id= new Guid("29706a26-f2a7-477b-a27b-0327dd88ca52") , WatchlistId= new Guid("484db3e9-f9d5-4ae2-a173-624f2f0e6d72") , SecurityId = 93 },
                new WatchlistSecurity { Id= new Guid("6a3371e5-4de8-422e-b5a1-d16ff059be6b") , WatchlistId= new Guid("69ee6688-f1b9-4e88-8f6e-4cc3b5f737af") , SecurityId = 94 },
                new WatchlistSecurity { Id= new Guid("d8f104ef-7ba1-49ea-8f7b-68dde57eb8be") , WatchlistId= new Guid("aa68bb72-bf2f-481b-92e1-0f9acab96f4d") , SecurityId = 95 },
                new WatchlistSecurity { Id= new Guid("c85343bd-7eb6-479c-bf9f-55a2a583db0d") , WatchlistId= new Guid("b6dadfac-4137-41b0-a924-2a547b9d8d13") , SecurityId = 96 },
                new WatchlistSecurity { Id= new Guid("00fdc2c6-f80c-4292-996a-d5abf4bfb9b3") , WatchlistId= new Guid("0ee86fc0-60d7-487a-981c-5fcb337b8b97") , SecurityId = 1 },
                new WatchlistSecurity { Id= new Guid("b07fa645-0eda-4403-a39d-d91879d26dce") , WatchlistId= new Guid("3432bbb1-6ff6-42f2-9174-3546abce1add") , SecurityId = 2 },
                new WatchlistSecurity { Id= new Guid("18ddc665-7f38-4928-8e96-b240f1e0b2ed") , WatchlistId= new Guid("6dec1419-4264-46bd-9ced-3efe9309a590") , SecurityId = 3 },
                new WatchlistSecurity { Id= new Guid("06a7938b-ac8c-48ec-98d7-b6415767a6c7") , WatchlistId= new Guid("9e5b2fdc-2b2d-417d-929e-d0c076fa9a63") , SecurityId = 4 },
                new WatchlistSecurity { Id= new Guid("cc6db208-4da9-4db8-8675-a477dec4e066") , WatchlistId= new Guid("35d00703-469a-4b87-8e82-cab8eb26d17d") , SecurityId = 5 },
                new WatchlistSecurity { Id= new Guid("44be3038-adf6-4f59-922b-328a6266cb61") , WatchlistId= new Guid("6298f232-6993-48e1-bfe2-2465822ae1d0") , SecurityId = 6 },
                new WatchlistSecurity { Id= new Guid("105bf76c-ca41-4c3a-9c64-f7cc81edf49f") , WatchlistId= new Guid("3e3fb52f-a11c-455d-b747-f50669df1cd4") , SecurityId = 7 },
                new WatchlistSecurity { Id= new Guid("6567cd07-adc2-4a1e-ab1c-8f90b985c3bc") , WatchlistId= new Guid("49d215c4-a60c-4518-97b9-717b407f607a") , SecurityId = 8 },
                new WatchlistSecurity { Id= new Guid("a9759c85-cbc0-48df-aa1f-74e0554886b4") , WatchlistId= new Guid("2c2f0f42-82ba-4fd7-a115-8e25b9b84c34") , SecurityId = 9 },
                new WatchlistSecurity { Id= new Guid("842ea0a5-14d9-45d2-96ac-b2f5eb09bd3b") , WatchlistId= new Guid("cf2dfed0-753c-47be-be1d-fd6e92e1547d") , SecurityId = 10 },
                new WatchlistSecurity { Id= new Guid("acee64ab-b920-468b-849a-677764dd84ef") , WatchlistId= new Guid("f11e452e-9a35-4afa-8f54-75191771abd6") , SecurityId = 11 },
                new WatchlistSecurity { Id= new Guid("bfbfbb28-ce6a-4ccf-b6e5-8e78f53424e7") , WatchlistId= new Guid("91eea4cb-3768-4e99-9960-96c1c352fe60") , SecurityId = 12 },
                new WatchlistSecurity { Id= new Guid("09388fe8-a870-4658-87de-cd5959ab83b5") , WatchlistId= new Guid("f6a7c172-1d03-4117-8097-1b8a6e21e72d") , SecurityId = 13 },
                new WatchlistSecurity { Id= new Guid("69d74e44-84e3-4241-b976-2a64cc9797ff") , WatchlistId= new Guid("0b394c44-50ed-4f5e-adad-59713fac4399") , SecurityId = 14 },
                new WatchlistSecurity { Id= new Guid("4d471da3-23b1-4582-8a15-edc39a8408a0") , WatchlistId= new Guid("9274d528-794b-4ead-ae53-98f042a50856") , SecurityId = 15 },
                new WatchlistSecurity { Id= new Guid("f8222b77-d760-4e82-893a-509f7a019be4") , WatchlistId= new Guid("741cd6bb-f36a-4af5-bda2-37e11a7eea28") , SecurityId = 16 },
                new WatchlistSecurity { Id= new Guid("c31d5dde-20b3-41be-b727-048ec62ed8d4") , WatchlistId= new Guid("32da8ce6-8557-4bb1-a05d-a78393798168") , SecurityId = 17 },
                new WatchlistSecurity { Id= new Guid("2f25b34d-8d17-4c56-9f81-15b141c257c4") , WatchlistId= new Guid("73b0b71d-d9cf-4bd2-91a9-9b654386e190") , SecurityId = 18 },
                new WatchlistSecurity { Id= new Guid("6db2c3d4-d5bf-435c-9951-66ee22f176b6") , WatchlistId= new Guid("b8f243e5-ee6b-4827-871d-9d23c227f321") , SecurityId = 19 },
                new WatchlistSecurity { Id= new Guid("60ab547f-fed3-46b4-aeb9-c31610726601") , WatchlistId= new Guid("a773c637-681c-4f33-9ea5-e3e56f88214e") , SecurityId = 20 },
                new WatchlistSecurity { Id= new Guid("a15674c4-6d81-4035-a440-b474b14eca34") , WatchlistId= new Guid("0a15dce5-cffd-447b-b14a-536edcaff1bd") , SecurityId = 21 },
                new WatchlistSecurity { Id= new Guid("a4267733-d0ef-4156-b87b-fa4f68917cec") , WatchlistId= new Guid("58eaa8b4-f76d-4818-9753-34d442e0fb0d") , SecurityId = 22 },
                new WatchlistSecurity { Id= new Guid("1f707990-cd2b-4a19-b1e4-b884f51a84b2") , WatchlistId= new Guid("07766517-9d61-42b3-a657-406ecc8d94a7") , SecurityId = 23 },
                new WatchlistSecurity { Id= new Guid("a2508cea-2d00-40a9-abfc-679b50580fd5") , WatchlistId= new Guid("cfd30050-341e-4453-80b8-0fe14634290e") , SecurityId = 24 },
                new WatchlistSecurity { Id= new Guid("544528c6-1c3a-4223-bd8d-56354afa2d0b") , WatchlistId= new Guid("9b0d7b68-6f99-4361-bf88-f8fd69ee304c") , SecurityId = 25 },
                new WatchlistSecurity { Id= new Guid("1c304004-3b3c-4ce3-9cc6-5190da084dd3") , WatchlistId= new Guid("d7a8934b-e958-4094-9e1d-0cb7f68c6fa5") , SecurityId = 26 },
                new WatchlistSecurity { Id= new Guid("952894bc-79cd-4962-a6fc-d4551572280d") , WatchlistId= new Guid("e51144a2-ae17-4fcc-8c6a-6d04fdc36d8d") , SecurityId = 27 },
                new WatchlistSecurity { Id= new Guid("5a478148-99e9-4b0b-9970-1805e08e7f2b") , WatchlistId= new Guid("462d661e-7d5a-45e4-98c9-3c78aa1710df") , SecurityId = 28 },
                new WatchlistSecurity { Id= new Guid("b06ef3cd-de5e-4ce2-856f-d38e7410a91c") , WatchlistId= new Guid("2b687a26-13d4-42cd-8759-b49164b07c4f") , SecurityId = 29 },
                new WatchlistSecurity { Id= new Guid("026f3dbe-a4a0-46a5-b277-023a99b3b3ce") , WatchlistId= new Guid("0cc849ed-a76d-4928-a828-a90c0773cdbe") , SecurityId = 30 },
                new WatchlistSecurity { Id= new Guid("54196911-9586-47fd-87e2-9a320f8d755f") , WatchlistId= new Guid("343910c8-bac2-4a27-8c9d-04553331b890") , SecurityId = 31 },
                new WatchlistSecurity { Id= new Guid("b709170d-4136-493e-9299-01a018d4636f") , WatchlistId= new Guid("2b6a9605-6788-4ad3-bd7e-58d875871ce9") , SecurityId = 32 },
                new WatchlistSecurity { Id= new Guid("cd5dfad0-4a68-4eff-9bd0-b6fccd42f2ee") , WatchlistId= new Guid("450c5f05-310a-497a-a551-1a5a0b007f4c") , SecurityId = 33 },
                new WatchlistSecurity { Id= new Guid("daa6e421-1866-44d6-93f3-c6050ed8647f") , WatchlistId= new Guid("91ce62ac-3599-4918-bb23-a4ca9ff16c68") , SecurityId = 34 },
                new WatchlistSecurity { Id= new Guid("025fc42d-695f-4699-96e2-f0b4b42ffe8a") , WatchlistId= new Guid("28ebc087-53ce-40b5-a70c-9cb6737a03b2") , SecurityId = 35 },
                new WatchlistSecurity { Id= new Guid("a9737bea-8e1a-4381-8634-05900f7ab2a5") , WatchlistId= new Guid("796eff1d-fa32-40d6-85c8-31474012ccb4") , SecurityId = 36 },
                new WatchlistSecurity { Id= new Guid("b5e53942-fd04-499d-bc6d-24cb079724e3") , WatchlistId= new Guid("407c8f1d-ff00-4506-a735-5977bcb986e7") , SecurityId = 37 },
                new WatchlistSecurity { Id= new Guid("def67193-afe9-4712-b635-e1fe681f0e16") , WatchlistId= new Guid("baa40c00-bd1d-4f8c-a2ac-411db81641f2") , SecurityId = 38 },
                new WatchlistSecurity { Id= new Guid("799129d3-ee34-49b6-956b-78bbf66a180d") , WatchlistId= new Guid("e898083f-245d-4616-ac77-1b467f6ee9c6") , SecurityId = 39 },
                new WatchlistSecurity { Id= new Guid("28bb4c5b-c589-479e-89b8-69d73b8b31ac") , WatchlistId= new Guid("545e684f-1c71-48ec-bfa6-b63fb2ac0e33") , SecurityId = 40 },
                new WatchlistSecurity { Id= new Guid("67e27c9a-0f4b-4286-a788-483f852b7461") , WatchlistId= new Guid("8e090e5b-a599-43b0-b7e5-38724fc37377") , SecurityId = 41 },
                new WatchlistSecurity { Id= new Guid("a10c62d0-01a0-4982-88c3-b267c994728c") , WatchlistId= new Guid("604cff4d-9ce6-4513-8db7-d4bd5e6342e5") , SecurityId = 42 },
                new WatchlistSecurity { Id= new Guid("6fa65e3a-d80a-4cbe-bff8-b7758aca707c") , WatchlistId= new Guid("abe23978-1f61-4a4c-9156-af86ca76e549") , SecurityId = 43 },
                new WatchlistSecurity { Id= new Guid("9feb1fcb-eb77-4d39-aec9-aca790936b96") , WatchlistId= new Guid("aa87a9c9-3fc6-4893-9353-02bebe7e782f") , SecurityId = 44 },
                new WatchlistSecurity { Id= new Guid("706623da-0c71-40b7-95ca-778501eba0c9") , WatchlistId= new Guid("80a54d7c-4bc9-4662-8aa5-753a6f32f5cd") , SecurityId = 45 },
                new WatchlistSecurity { Id= new Guid("071b8db8-84ce-40f2-84a7-4c8427c62031") , WatchlistId= new Guid("9ac71354-5f74-4aba-ba36-3dcab9ebaa44") , SecurityId = 46 },
                new WatchlistSecurity { Id= new Guid("d1f614ed-98f9-4ac0-99a1-317bd6ace0e4") , WatchlistId= new Guid("db39e260-101d-4582-a0c3-8ef6eba34b1c") , SecurityId = 47 },
                new WatchlistSecurity { Id= new Guid("103093c6-148f-432a-a9fa-8855ecc52b63") , WatchlistId= new Guid("9b6205d3-5bd4-4d13-86eb-a49bcee4528d") , SecurityId = 48 },
                new WatchlistSecurity { Id= new Guid("ebe0234b-cb9c-4abe-8091-168b9fb643d8") , WatchlistId= new Guid("01a1137c-5a27-4c24-afe8-7f0fe2302d29") , SecurityId = 49 },
                new WatchlistSecurity { Id= new Guid("ebc68c69-2b2e-4e12-bdd3-ea1471ec2233") , WatchlistId= new Guid("a2b18656-0648-44f5-ac68-43444eca6b86") , SecurityId = 50 },
                new WatchlistSecurity { Id= new Guid("1d9a6044-a0ca-49c3-ae25-768bdaa4d384") , WatchlistId= new Guid("bb8de9b3-857d-4a81-9608-cf883d43d90f") , SecurityId = 51 },
                new WatchlistSecurity { Id= new Guid("8b1d7d76-7306-4ec7-a0cd-2c62004db923") , WatchlistId= new Guid("0c13f891-ecad-4be4-ba64-d9519b59bb92") , SecurityId = 52 },
                new WatchlistSecurity { Id= new Guid("9b614972-100b-4c48-b50c-cf194d4adfb4") , WatchlistId= new Guid("8020c7ea-d7d0-447c-9c01-c4212b32e17f") , SecurityId = 53 },
                new WatchlistSecurity { Id= new Guid("c5fb13f9-d6a3-4e23-9ae3-aabf821d66c8") , WatchlistId= new Guid("01c43c01-eb08-4f08-bcee-56aba256075f") , SecurityId = 54 },
                new WatchlistSecurity { Id= new Guid("d1ab38db-cc5d-4723-b43d-d4f0d536f1c5") , WatchlistId= new Guid("5cb67667-08f3-4966-8370-a905d388cdab") , SecurityId = 55 },
                new WatchlistSecurity { Id= new Guid("063bd3f1-5be7-4a6e-89e7-8dbdecc99531") , WatchlistId= new Guid("b3e8ebd1-c8f7-4502-992d-846f7b356c19") , SecurityId = 56 },
                new WatchlistSecurity { Id= new Guid("72f59f98-d813-4423-a1ad-d3939740be8b") , WatchlistId= new Guid("c9b505f0-3a52-4389-a55b-accc390c0cee") , SecurityId = 57 },
                new WatchlistSecurity { Id= new Guid("c716e184-6648-45e4-84eb-14d3b650e92c") , WatchlistId= new Guid("ed245cb4-d809-484b-9c38-ff447451ba7c") , SecurityId = 58 },
                new WatchlistSecurity { Id= new Guid("d85a83b6-1228-4aae-930f-0b03e97beccf") , WatchlistId= new Guid("abfb2557-0aa9-4342-acf1-40d0851300d5") , SecurityId = 59 },
                new WatchlistSecurity { Id= new Guid("9144ca0b-8da3-4d8e-8364-78ee5ce0157f") , WatchlistId= new Guid("484db3e9-f9d5-4ae2-a173-624f2f0e6d72") , SecurityId = 60 },
                new WatchlistSecurity { Id= new Guid("49fdd27f-9a84-4ae0-b8ae-5212784473c1") , WatchlistId= new Guid("69ee6688-f1b9-4e88-8f6e-4cc3b5f737af") , SecurityId = 61 },
                new WatchlistSecurity { Id= new Guid("bc01d6db-8bac-4836-bfe8-bec9a9cf57fd") , WatchlistId= new Guid("aa68bb72-bf2f-481b-92e1-0f9acab96f4d") , SecurityId = 62 },
                new WatchlistSecurity { Id= new Guid("22fdf473-c790-4e23-8cfb-ba07323d0e72") , WatchlistId= new Guid("b6dadfac-4137-41b0-a924-2a547b9d8d13") , SecurityId = 63 },
                new WatchlistSecurity { Id= new Guid("70c435ba-9bc0-4c57-935c-1791d81cd412") , WatchlistId= new Guid("0ee86fc0-60d7-487a-981c-5fcb337b8b97") , SecurityId = 64 },
                new WatchlistSecurity { Id= new Guid("b35a912e-cb8a-478e-b423-2e04d955340e") , WatchlistId= new Guid("3432bbb1-6ff6-42f2-9174-3546abce1add") , SecurityId = 65 },
                new WatchlistSecurity { Id= new Guid("8b716e51-542b-43e7-bcf0-e94cb5de9a92") , WatchlistId= new Guid("6dec1419-4264-46bd-9ced-3efe9309a590") , SecurityId = 66 },
                new WatchlistSecurity { Id= new Guid("dc34a8c9-66bd-4d2b-97af-33a9b4ac2477") , WatchlistId= new Guid("9e5b2fdc-2b2d-417d-929e-d0c076fa9a63") , SecurityId = 67 },
                new WatchlistSecurity { Id= new Guid("6bcd9f8c-70ce-4821-bcbb-593d88c6f721") , WatchlistId= new Guid("35d00703-469a-4b87-8e82-cab8eb26d17d") , SecurityId = 68 },
                new WatchlistSecurity { Id= new Guid("33203113-bf85-4404-94bb-6e98bd091deb") , WatchlistId= new Guid("6298f232-6993-48e1-bfe2-2465822ae1d0") , SecurityId = 69 },
                new WatchlistSecurity { Id= new Guid("1bb1f7d6-bfa6-4b2f-bec1-76a4bf375eed") , WatchlistId= new Guid("3e3fb52f-a11c-455d-b747-f50669df1cd4") , SecurityId = 70 },
                new WatchlistSecurity { Id= new Guid("4a7e27b2-aebd-4481-959d-3aa86177eef4") , WatchlistId= new Guid("49d215c4-a60c-4518-97b9-717b407f607a") , SecurityId = 71 },
                new WatchlistSecurity { Id= new Guid("b7da3e23-c8e7-4db4-9d98-64a1407e01ab") , WatchlistId= new Guid("2c2f0f42-82ba-4fd7-a115-8e25b9b84c34") , SecurityId = 72 },
                new WatchlistSecurity { Id= new Guid("34472b8b-0bfb-4d10-a1c2-cc79db43cc64") , WatchlistId= new Guid("cf2dfed0-753c-47be-be1d-fd6e92e1547d") , SecurityId = 73 },
                new WatchlistSecurity { Id= new Guid("3abeb315-5ff4-4dbc-af57-b04c44132686") , WatchlistId= new Guid("f11e452e-9a35-4afa-8f54-75191771abd6") , SecurityId = 74 },
                new WatchlistSecurity { Id= new Guid("e2cc597a-96e1-4a02-a265-ec602ae30b2a") , WatchlistId= new Guid("91eea4cb-3768-4e99-9960-96c1c352fe60") , SecurityId = 75 },
                new WatchlistSecurity { Id= new Guid("3710c50c-167f-4260-a2ef-0802f113fed9") , WatchlistId= new Guid("f6a7c172-1d03-4117-8097-1b8a6e21e72d") , SecurityId = 76 },
                new WatchlistSecurity { Id= new Guid("442573f1-c4f8-47ec-891a-51c09be87062") , WatchlistId= new Guid("0b394c44-50ed-4f5e-adad-59713fac4399") , SecurityId = 77 },
                new WatchlistSecurity { Id= new Guid("476e7ab7-af50-47bc-8362-c418601f50af") , WatchlistId= new Guid("9274d528-794b-4ead-ae53-98f042a50856") , SecurityId = 78 },
                new WatchlistSecurity { Id= new Guid("4d465e05-6799-428c-b99f-a7c8e0ce323a") , WatchlistId= new Guid("741cd6bb-f36a-4af5-bda2-37e11a7eea28") , SecurityId = 79 },
                new WatchlistSecurity { Id= new Guid("fe9a7bbc-4416-46ef-b06b-0d09e4ec2936") , WatchlistId= new Guid("32da8ce6-8557-4bb1-a05d-a78393798168") , SecurityId = 80 },
                new WatchlistSecurity { Id= new Guid("0fe0af48-1287-4ff4-b144-86f815aa89fe") , WatchlistId= new Guid("73b0b71d-d9cf-4bd2-91a9-9b654386e190") , SecurityId = 81 },
                new WatchlistSecurity { Id= new Guid("ccdb6855-90f7-44ca-a1c2-ef1a0a465c7b") , WatchlistId= new Guid("b8f243e5-ee6b-4827-871d-9d23c227f321") , SecurityId = 82 },
                new WatchlistSecurity { Id= new Guid("1597b091-cd29-48b6-a0e5-ce0c876252d4") , WatchlistId= new Guid("a773c637-681c-4f33-9ea5-e3e56f88214e") , SecurityId = 83 },
                new WatchlistSecurity { Id= new Guid("e0630c1d-c993-475b-b659-7d023d2359dc") , WatchlistId= new Guid("0a15dce5-cffd-447b-b14a-536edcaff1bd") , SecurityId = 84 },
                new WatchlistSecurity { Id= new Guid("b274a0a5-0305-40ae-8c48-bc800afae35c") , WatchlistId= new Guid("58eaa8b4-f76d-4818-9753-34d442e0fb0d") , SecurityId = 85 },
                new WatchlistSecurity { Id= new Guid("d464dedb-f717-4813-851f-a3d61dd7e908") , WatchlistId= new Guid("07766517-9d61-42b3-a657-406ecc8d94a7") , SecurityId = 86 },
                new WatchlistSecurity { Id= new Guid("2bb103a1-f391-4f55-8750-9435873acf1e") , WatchlistId= new Guid("cfd30050-341e-4453-80b8-0fe14634290e") , SecurityId = 87 },
                new WatchlistSecurity { Id= new Guid("8c4437b4-f2ba-402b-9ed8-fa7154577669") , WatchlistId= new Guid("9b0d7b68-6f99-4361-bf88-f8fd69ee304c") , SecurityId = 88 },
                new WatchlistSecurity { Id= new Guid("fb0a9029-384d-423f-a585-e0b345ca6d43") , WatchlistId= new Guid("d7a8934b-e958-4094-9e1d-0cb7f68c6fa5") , SecurityId = 89 },
                new WatchlistSecurity { Id= new Guid("7914c537-6aa5-4603-9c73-5f2d56cf60b9") , WatchlistId= new Guid("e51144a2-ae17-4fcc-8c6a-6d04fdc36d8d") , SecurityId = 90 },
                new WatchlistSecurity { Id= new Guid("0695f0d4-41c1-4945-9d04-6a2795464dff") , WatchlistId= new Guid("462d661e-7d5a-45e4-98c9-3c78aa1710df") , SecurityId = 91 },
                new WatchlistSecurity { Id= new Guid("4aea3836-d8df-4a43-a5a6-f6829c2acd1c") , WatchlistId= new Guid("2b687a26-13d4-42cd-8759-b49164b07c4f") , SecurityId = 92 },
                new WatchlistSecurity { Id= new Guid("dd4c83a1-d414-48a9-968b-031f6408d14f") , WatchlistId= new Guid("0cc849ed-a76d-4928-a828-a90c0773cdbe") , SecurityId = 93 },
                new WatchlistSecurity { Id= new Guid("a67345f4-ff67-4ef9-b37a-a96141a15ae7") , WatchlistId= new Guid("343910c8-bac2-4a27-8c9d-04553331b890") , SecurityId = 94 },
                new WatchlistSecurity { Id= new Guid("72ee8ca2-ca95-446b-8508-409b8cdea6fc") , WatchlistId= new Guid("2b6a9605-6788-4ad3-bd7e-58d875871ce9") , SecurityId = 95 },
                new WatchlistSecurity { Id= new Guid("d88abdd8-8c5d-4c8c-a633-75c5b1f20db7") , WatchlistId= new Guid("450c5f05-310a-497a-a551-1a5a0b007f4c") , SecurityId = 96 },
                new WatchlistSecurity { Id= new Guid("32f081f0-a39e-4830-9b77-0f2b6105b73a") , WatchlistId= new Guid("91ce62ac-3599-4918-bb23-a4ca9ff16c68") , SecurityId = 1 },
                new WatchlistSecurity { Id= new Guid("852bde46-5a29-47a9-8469-f4becd75a796") , WatchlistId= new Guid("28ebc087-53ce-40b5-a70c-9cb6737a03b2") , SecurityId = 2 },
                new WatchlistSecurity { Id= new Guid("cbc5b718-586e-4323-9ed0-5ea2409c1ecb") , WatchlistId= new Guid("796eff1d-fa32-40d6-85c8-31474012ccb4") , SecurityId = 3 },
                new WatchlistSecurity { Id= new Guid("f2f801e4-8684-43ea-92dd-661f14031acb") , WatchlistId= new Guid("407c8f1d-ff00-4506-a735-5977bcb986e7") , SecurityId = 4 },
                new WatchlistSecurity { Id= new Guid("7504cb0e-498d-46e3-910a-54d3ab8bfba4") , WatchlistId= new Guid("baa40c00-bd1d-4f8c-a2ac-411db81641f2") , SecurityId = 5 },
                new WatchlistSecurity { Id= new Guid("acf83887-59e7-464e-b942-3469aec1ccf9") , WatchlistId= new Guid("e898083f-245d-4616-ac77-1b467f6ee9c6") , SecurityId = 6 },
                new WatchlistSecurity { Id= new Guid("319dde4a-660a-415b-8309-ba9aa2aa00d2") , WatchlistId= new Guid("545e684f-1c71-48ec-bfa6-b63fb2ac0e33") , SecurityId = 7 },
                new WatchlistSecurity { Id= new Guid("70287248-462e-48a5-a0d5-19eb67128264") , WatchlistId= new Guid("8e090e5b-a599-43b0-b7e5-38724fc37377") , SecurityId = 8 },
                new WatchlistSecurity { Id= new Guid("f50a1cd5-6f7e-47f8-bcd7-6c150374f129") , WatchlistId= new Guid("604cff4d-9ce6-4513-8db7-d4bd5e6342e5") , SecurityId = 9 },
                new WatchlistSecurity { Id= new Guid("508e507e-7828-4356-b7db-267b53648313") , WatchlistId= new Guid("abe23978-1f61-4a4c-9156-af86ca76e549") , SecurityId = 10 },
                new WatchlistSecurity { Id= new Guid("6335c235-ffd1-427d-9489-bb231f522f8c") , WatchlistId= new Guid("aa87a9c9-3fc6-4893-9353-02bebe7e782f") , SecurityId = 11 },
                new WatchlistSecurity { Id= new Guid("527c0bbe-757c-4084-ae08-25b99d84fc88") , WatchlistId= new Guid("80a54d7c-4bc9-4662-8aa5-753a6f32f5cd") , SecurityId = 12 },
                new WatchlistSecurity { Id= new Guid("b261704e-03ff-4372-b506-ff04797c849b") , WatchlistId= new Guid("9ac71354-5f74-4aba-ba36-3dcab9ebaa44") , SecurityId = 13 },
                new WatchlistSecurity { Id= new Guid("bbebb15c-abe1-4aaa-aa53-cf1c6e04b92b") , WatchlistId= new Guid("db39e260-101d-4582-a0c3-8ef6eba34b1c") , SecurityId = 14 },
                new WatchlistSecurity { Id= new Guid("9b4a730c-1a72-4da3-b02f-1e6ab3ceff99") , WatchlistId= new Guid("9b6205d3-5bd4-4d13-86eb-a49bcee4528d") , SecurityId = 15 },
                new WatchlistSecurity { Id= new Guid("e6eb0555-5b34-4db1-b9fe-668290228d8e") , WatchlistId= new Guid("01a1137c-5a27-4c24-afe8-7f0fe2302d29") , SecurityId = 16 },
                new WatchlistSecurity { Id= new Guid("c015548a-5fe9-4771-8607-1d265d7cd671") , WatchlistId= new Guid("a2b18656-0648-44f5-ac68-43444eca6b86") , SecurityId = 17 },
                new WatchlistSecurity { Id= new Guid("619fe790-48fb-4197-b0f1-425769181143") , WatchlistId= new Guid("bb8de9b3-857d-4a81-9608-cf883d43d90f") , SecurityId = 18 },
                new WatchlistSecurity { Id= new Guid("607333aa-f74e-4c73-bf0c-26e572f68153") , WatchlistId= new Guid("0c13f891-ecad-4be4-ba64-d9519b59bb92") , SecurityId = 19 },
                new WatchlistSecurity { Id= new Guid("a358f491-72f2-4a3d-8f72-425201e4ad0f") , WatchlistId= new Guid("8020c7ea-d7d0-447c-9c01-c4212b32e17f") , SecurityId = 20 },
                new WatchlistSecurity { Id= new Guid("57d92a8c-6729-4a87-bc64-e8e748ac85a9") , WatchlistId= new Guid("01c43c01-eb08-4f08-bcee-56aba256075f") , SecurityId = 21 },
                new WatchlistSecurity { Id= new Guid("8a74abd7-7f81-4514-9aac-1c660e94ec09") , WatchlistId= new Guid("5cb67667-08f3-4966-8370-a905d388cdab") , SecurityId = 22 },
                new WatchlistSecurity { Id= new Guid("37ad9157-6177-4156-8080-3a883b46933c") , WatchlistId= new Guid("b3e8ebd1-c8f7-4502-992d-846f7b356c19") , SecurityId = 23 },
                new WatchlistSecurity { Id= new Guid("0eaccbbe-830e-4f43-b7f5-451a733c5be1") , WatchlistId= new Guid("c9b505f0-3a52-4389-a55b-accc390c0cee") , SecurityId = 24 },
                new WatchlistSecurity { Id= new Guid("a85d3962-0364-47bd-a2c9-1587da2ed0c6") , WatchlistId= new Guid("ed245cb4-d809-484b-9c38-ff447451ba7c") , SecurityId = 25 },
                new WatchlistSecurity { Id= new Guid("c622d147-d4bf-4947-a0b9-1ab2ee56460c") , WatchlistId= new Guid("abfb2557-0aa9-4342-acf1-40d0851300d5") , SecurityId = 26 },
                new WatchlistSecurity { Id= new Guid("e2f27373-cddb-43b0-a608-24e039ff4d01") , WatchlistId= new Guid("484db3e9-f9d5-4ae2-a173-624f2f0e6d72") , SecurityId = 27 },
                new WatchlistSecurity { Id= new Guid("3a23144c-6f4a-404a-805f-7a1f64c0e802") , WatchlistId= new Guid("69ee6688-f1b9-4e88-8f6e-4cc3b5f737af") , SecurityId = 28 },
                new WatchlistSecurity { Id= new Guid("9a17c13a-d1de-498a-8ef5-4897dc9e517e") , WatchlistId= new Guid("aa68bb72-bf2f-481b-92e1-0f9acab96f4d") , SecurityId = 29 },
                new WatchlistSecurity { Id= new Guid("3634b3ef-a6a3-47fb-9423-3c41d4b6b3fd") , WatchlistId= new Guid("b6dadfac-4137-41b0-a924-2a547b9d8d13") , SecurityId = 30 },
                new WatchlistSecurity { Id= new Guid("6e4ce5cd-32c2-4e4a-a489-6ae3f9cd13e4") , WatchlistId= new Guid("0ee86fc0-60d7-487a-981c-5fcb337b8b97") , SecurityId = 31 },
                new WatchlistSecurity { Id= new Guid("b21a0e77-5f79-43f6-8888-e51c1a62cbab") , WatchlistId= new Guid("3432bbb1-6ff6-42f2-9174-3546abce1add") , SecurityId = 32 },
                new WatchlistSecurity { Id= new Guid("8c69135b-af39-427e-bc72-d20e1efd3b62") , WatchlistId= new Guid("6dec1419-4264-46bd-9ced-3efe9309a590") , SecurityId = 33 },
                new WatchlistSecurity { Id= new Guid("7a582316-56e7-46eb-b752-8bb1e2c8e079") , WatchlistId= new Guid("9e5b2fdc-2b2d-417d-929e-d0c076fa9a63") , SecurityId = 34 },
                new WatchlistSecurity { Id= new Guid("4923bd97-28c6-4624-a303-73215b1da790") , WatchlistId= new Guid("35d00703-469a-4b87-8e82-cab8eb26d17d") , SecurityId = 35 },
                new WatchlistSecurity { Id= new Guid("189e58cd-3cf3-4574-b051-c7a6ff30e7ee") , WatchlistId= new Guid("6298f232-6993-48e1-bfe2-2465822ae1d0") , SecurityId = 36 },
                new WatchlistSecurity { Id= new Guid("c1182931-1bc9-4aa0-aac8-1e1c3a490e50") , WatchlistId= new Guid("3e3fb52f-a11c-455d-b747-f50669df1cd4") , SecurityId = 37 },
                new WatchlistSecurity { Id= new Guid("07d6a1c9-26e2-4aa8-b7c7-b52b9f5291d2") , WatchlistId= new Guid("49d215c4-a60c-4518-97b9-717b407f607a") , SecurityId = 38 },
                new WatchlistSecurity { Id= new Guid("7386740c-7cdf-4605-84fd-b344c5288cc8") , WatchlistId= new Guid("2c2f0f42-82ba-4fd7-a115-8e25b9b84c34") , SecurityId = 39 },
                new WatchlistSecurity { Id= new Guid("d3db68a9-aa60-49f3-90ab-0c852661e921") , WatchlistId= new Guid("cf2dfed0-753c-47be-be1d-fd6e92e1547d") , SecurityId = 40 },
                new WatchlistSecurity { Id= new Guid("4e8b51ab-77a0-40ed-83f7-b9090e7ceca8") , WatchlistId= new Guid("f11e452e-9a35-4afa-8f54-75191771abd6") , SecurityId = 41 },
                new WatchlistSecurity { Id= new Guid("31b03e45-dba1-45df-840a-d7308a2b462a") , WatchlistId= new Guid("91eea4cb-3768-4e99-9960-96c1c352fe60") , SecurityId = 42 },
                new WatchlistSecurity { Id= new Guid("b348d755-8d5b-43c7-8f06-8600e6e8df3d") , WatchlistId= new Guid("f6a7c172-1d03-4117-8097-1b8a6e21e72d") , SecurityId = 43 },
                new WatchlistSecurity { Id= new Guid("7d07a345-a417-4b79-816d-b7313b8f7685") , WatchlistId= new Guid("0b394c44-50ed-4f5e-adad-59713fac4399") , SecurityId = 44 },
                new WatchlistSecurity { Id= new Guid("a6643691-11bf-4d8a-8fb9-121ed648dfbb") , WatchlistId= new Guid("9274d528-794b-4ead-ae53-98f042a50856") , SecurityId = 45 },
                new WatchlistSecurity { Id= new Guid("c488cab5-7502-4813-a86e-ec4e2291449e") , WatchlistId= new Guid("741cd6bb-f36a-4af5-bda2-37e11a7eea28") , SecurityId = 46 },
                new WatchlistSecurity { Id= new Guid("75c7e81e-952d-4992-8005-4145ef7f226a") , WatchlistId= new Guid("32da8ce6-8557-4bb1-a05d-a78393798168") , SecurityId = 47 },
                new WatchlistSecurity { Id= new Guid("77d1d741-6068-4952-9799-d0b581fe96aa") , WatchlistId= new Guid("73b0b71d-d9cf-4bd2-91a9-9b654386e190") , SecurityId = 48 },
                new WatchlistSecurity { Id= new Guid("843bee77-30f5-4612-a2c5-08d0e22beaf1") , WatchlistId= new Guid("b8f243e5-ee6b-4827-871d-9d23c227f321") , SecurityId = 49 },
                new WatchlistSecurity { Id= new Guid("8955221f-3795-40bc-922e-fee62da5c4ef") , WatchlistId= new Guid("a773c637-681c-4f33-9ea5-e3e56f88214e") , SecurityId = 50 },
                new WatchlistSecurity { Id= new Guid("4265178b-6c6b-4f73-b33a-b1768904dc4f") , WatchlistId= new Guid("0a15dce5-cffd-447b-b14a-536edcaff1bd") , SecurityId = 51 },
                new WatchlistSecurity { Id= new Guid("e3d49729-b07f-4c17-9026-ce8287190182") , WatchlistId= new Guid("58eaa8b4-f76d-4818-9753-34d442e0fb0d") , SecurityId = 52 },
                new WatchlistSecurity { Id= new Guid("b72a7b9e-8c39-4339-a0dc-4a9cfe20094d") , WatchlistId= new Guid("07766517-9d61-42b3-a657-406ecc8d94a7") , SecurityId = 53 },
                new WatchlistSecurity { Id= new Guid("3ab8ead3-c07e-4848-a670-33e76971cb46") , WatchlistId= new Guid("cfd30050-341e-4453-80b8-0fe14634290e") , SecurityId = 54 },
                new WatchlistSecurity { Id= new Guid("9de70026-720c-487e-8438-8e82a80b655d") , WatchlistId= new Guid("9b0d7b68-6f99-4361-bf88-f8fd69ee304c") , SecurityId = 55 },
                new WatchlistSecurity { Id= new Guid("aab41dd0-f216-4038-8418-6c7f696b190e") , WatchlistId= new Guid("d7a8934b-e958-4094-9e1d-0cb7f68c6fa5") , SecurityId = 56 },
                new WatchlistSecurity { Id= new Guid("68d88d3d-2bc3-49ce-8bf8-bc917e54380d") , WatchlistId= new Guid("e51144a2-ae17-4fcc-8c6a-6d04fdc36d8d") , SecurityId = 57 },
                new WatchlistSecurity { Id= new Guid("bd549106-ea24-428e-aee4-56ceb65f9a32") , WatchlistId= new Guid("462d661e-7d5a-45e4-98c9-3c78aa1710df") , SecurityId = 58 },
                new WatchlistSecurity { Id= new Guid("ffb05914-eb82-4663-a1a2-5ac0c7dcbe28") , WatchlistId= new Guid("2b687a26-13d4-42cd-8759-b49164b07c4f") , SecurityId = 59 },
                new WatchlistSecurity { Id= new Guid("8dee1d0e-f24a-48b1-bb04-fd7b38e2023f") , WatchlistId= new Guid("0cc849ed-a76d-4928-a828-a90c0773cdbe") , SecurityId = 60 },

            };

            foreach (var wSec in watchlistSec)
            {
                if (!context.WatchlistSecurities.Any(w => w.Id == wSec.Id))
                {
                    context.WatchlistSecurities.Add(wSec);
                }
            }
        }
        private void SeedScanProfiles(ApplicationDbContext context) 
        {
            var scanProfiles = new List<ScanProfile> 
            {
                new ScanProfile { Id = new Guid("40ed1ce0-5dad-43bf-9de0-533ef4295cf7"), 
                    Name = "Default SPA3", 
                    System = "SPA3", 
                    Locked = true,
                    ScanType = "PORTFOLIO",
                    Parameters = "Default XASX SIROC 9:08",
                    ChartOptions = "None",
                    Entry = true,
                    Exit = false,
                    Pyramid = true,
                    Lighten = true,
                    TimeFrameType = "All Available Data",
                    Period = 1,
                    PeriodType = "Last Trade Period",
                    StartDate = new DateTime(2014,03,15),
                    EndDate = new DateTime(2014,06,30)
                },
                new ScanProfile { Id = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), 
                    Name = "Default SPA3 ETF", 
                    System = "SPA3 ETF", 
                    Locked = true,
                    ScanType = "ADVANCED",
                    Parameters = "Default XASX SIROC 21:08",
                    ChartOptions = "None",
                    Entry = false,
                    Exit = true,
                    Pyramid = true,
                    Lighten = true,
                    TimeFrameType = "Specific Period",
                    Period = 1,
                    PeriodType = "None",
                    StartDate = new DateTime(2014,04,20),
                    EndDate = new DateTime(2014,07,30)
                },
            };
            foreach (var sp in scanProfiles)
            {
                if (!context.ScanProfiles.Any(w => w.Id == sp.Id))
                {
                    context.ScanProfiles.Add(sp);
                }
            }
        }
        private void SeedScanResults(ApplicationDbContext context)
        {
            var scanResults = new List<ScanResult> {
                new ScanResult { Id = new Guid("43570635-311e-4183-918b-5ae8de9be97d"), ScanProfileId = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), SignalName = "ATR TS", SignalDate = new DateTime(2013,10,21), ActionDate = new DateTime(2013,10,21), SecurityCode = "XAO", SignalType = "BUY", SignalPrice = 1257.50  },
                new ScanResult { Id = new Guid("f33cff6e-00ac-4ba5-bcf8-7ff23afc94b7"), ScanProfileId = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), SignalName = "ATR BO",SignalDate = new DateTime(2013,11,12), ActionDate = new DateTime(2013,11,12), SecurityCode = "XEJ", SignalType = "BUY", SignalPrice = 350.45 },
                new ScanResult { Id = new Guid("1545e813-c599-46cc-96b4-473b45498547"), ScanProfileId = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), SignalName = "ISL",SignalDate = new DateTime(2013,12,21), ActionDate = new DateTime(2013,12,21), SecurityCode = "BHP", SignalType = "EXIT", SignalPrice = 12.14 },
                new ScanResult { Id = new Guid("83ea9531-5a56-484c-807f-46e1c797e775"), ScanProfileId = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), SignalName = "L4T",SignalDate = new DateTime(2014,1,15), ActionDate = new DateTime(2014,1,15), SecurityCode = "COMP", SignalType = "EXIT", SignalPrice = 85.4 },
                new ScanResult { Id = new Guid("d06f9d89-96b0-4369-95bc-c2080be15a51"), ScanProfileId = new Guid("212fcbb4-c05d-49bd-b75b-b306b2acd5b2"), SignalName = "H&S",SignalDate = new DateTime(2014,1,23), ActionDate = new DateTime(2014,1,23), SecurityCode = "DJUCY", SignalType = "EXIT", SignalPrice = 3650.12 },
                new ScanResult { Id = new Guid("70f899a6-3fe8-4491-899d-c3719df2dc09"), ScanProfileId = new Guid("40ed1ce0-5dad-43bf-9de0-533ef4295cf7"), SignalName = "ATR TS",SignalDate = new DateTime(2014,3,27), ActionDate = new DateTime(2014,3,27), SecurityCode = "DUI", SignalType = "BUY", SignalPrice = 78.9 },
                new ScanResult { Id = new Guid("ff23d237-7cf1-4132-adcb-7421d5f1f47a"), ScanProfileId =new Guid("40ed1ce0-5dad-43bf-9de0-533ef4295cf7"), SignalName = "ATR BO",SignalDate = new DateTime(2014,4,8), ActionDate = new DateTime(2014,4,8), SecurityCode = "EWW", SignalType = "BUY", SignalPrice = 25.32 },
                new ScanResult { Id = new Guid("7b6a4560-bf71-4d8b-830e-f54bb09a691a"), ScanProfileId = new Guid("40ed1ce0-5dad-43bf-9de0-533ef4295cf7"),SignalName = "ATR TS",SignalDate = new DateTime(2014,6,12), ActionDate = new DateTime(2014,6,12), SecurityCode = "XJM", SignalType = "BUY", SignalPrice = 91.1 },
                new ScanResult { Id = new Guid("5517cf8c-1937-445c-a8a7-b7bbcb017b24"), ScanProfileId = new Guid("40ed1ce0-5dad-43bf-9de0-533ef4295cf7"),SignalName = "ATR BO",SignalDate = new DateTime(2014,7,14), ActionDate = new DateTime(2014,7,14), SecurityCode = "DIA", SignalType = "BUY", SignalPrice = 89.7 },
            };

            foreach (var sr in scanResults)
            {
                if (!context.ScanResults.Any(s => s.Id == sr.Id))
                {
                    context.ScanResults.Add(sr);
                }
            }
        }
        private void SeedStockTransaction(ApplicationDbContext context) 
        {
            var stockTrans = new List<StockTransaction> {
                new StockTransaction { Id = new Guid("3189a76d-6296-4521-95e6-6510e6d15e91"), SignalName = "ATR BO", TransactionDate = new DateTime(2012,8,15), SecurityId = 35, TransactionType = "BUY", Price = 1257.50 , Quantity = 10 },
                new StockTransaction { Id = new Guid("63e77a19-dd51-462b-b7ac-7d3ab2756be9"), SignalName = "ATR BO", TransactionDate = new DateTime(2013,10,21), SecurityId = 47, TransactionType = "BUY", Price = 450.35 , Quantity = 30 },
                new StockTransaction { Id = new Guid("33f53b87-0f77-4077-8b37-c67bea54521f"), SignalName = "ATR BO", TransactionDate = new DateTime(2013,12,23), SecurityId = 35, TransactionType = "PYRAMID", Price = 1257.75 , Quantity = 3 },
                new StockTransaction { Id = new Guid("5a1bc645-2827-45a8-97dc-a0c57f88be0a"), SignalName = "ATR TS", TransactionDate = new DateTime(2014,2,10), SecurityId = 47, TransactionType = "SELL", Price = 442.15 , Quantity = 30 },
                new StockTransaction { Id = new Guid("af1c14d6-469c-447f-bd55-9163a1bbc2b0"), SignalName = "ATR BO", TransactionDate = new DateTime(2014,2,13), SecurityId = 41, TransactionType = "BUY", Price = 331.15 , Quantity = 5 },
                new StockTransaction { Id = new Guid("9c41f734-310e-446f-99ba-2ce29ef03336"), SignalName = "ATR BO", TransactionDate = new DateTime(2014,2,24), SecurityId = 68, TransactionType = "BUY", Price = 30.35 , Quantity = 12 },
                new StockTransaction { Id = new Guid("ef25ce6e-9485-4ffe-9e32-691e0ab1a2d2"), SignalName = "H&S", TransactionDate = new DateTime(2014,3,11), SecurityId = 47, TransactionType = "LIGHTEN", Price = 450.35 , Quantity = 20 },
                new StockTransaction { Id = new Guid("ce901045-9bb0-41cd-a0ee-1dfbf1697b1f"), SignalName = "4LT", TransactionDate = new DateTime(2014,5,21), SecurityId = 41, TransactionType = "SELL", Price = 450.35 , Quantity = 5 },
                new StockTransaction { Id = new Guid("48a22436-61cf-4b08-8603-38f5953a9269"), SignalName = "ISL", TransactionDate = new DateTime(2014,6,30), SecurityId = 68, TransactionType = "SELL", Price = 327.15 , Quantity = 12 },
            };
            foreach (var st in stockTrans)
            {
                if (!context.StockTransactions.Any(s => s.Id == st.Id))
                {
                    context.StockTransactions.Add(st);
                }
            }
        }
        private void SeedStockPrice(ApplicationDbContext context)
        {
            //http://www.davepaquette.com/archive/2014/03/18/seeding-entity-framework-database-from-csv.aspx
            //http://adrianmejia.com/blog/2011/07/18/cs-getmanifestresourcestream-gotcha/
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "ShareWealth.Infrastructure.Migrations.SeedData.stockPrice.csv";
            context.StockPrices.SeedFromResource(resourceName, sp => sp.Id);
          

        }
        private static void SaveArrayAsCSV<T>(T[] arrayToSave, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (T item in arrayToSave)
                {
                    file.Write(item + ",");
                }
            }
        }

    }
}
