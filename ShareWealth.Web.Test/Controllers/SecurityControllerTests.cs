using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareWealth.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.Entity.Migrations;
using System.Reflection;
using CsvHelper;
using ShareWealth.Core.Entities;
using ShareWealth.Infrastructure.DataLayer;
namespace ShareWealth.Web.Controllers.Tests
{
    [TestClass()]
    public class SecurityControllerTests
    {
        [TestMethod()]
        public void SecurityControllerTest()
        {
            //http://www.davepaquette.com/archive/2014/03/18/seeding-entity-framework-database-from-csv.aspx
            //http://adrianmejia.com/blog/2011/07/18/cs-getmanifestresourcestream-gotcha
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "ShareWealth.Web.Test.SeedData.stockPrice.csv";
            ApplicationDbContext context = new ApplicationDbContext();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var stockPrice = csvReader.GetRecords<StockPrice>().ToArray();
                    for (int i = 1; i < 4 ; i++)
                    {
                        var sp = new StockPrice { 
                           Id = i,
                           TradingDate = new DateTime(2013,12,5),
                           SecurityId = stockPrice[i].SecurityId,
                           Open = stockPrice[i].Open,
                           High = stockPrice[i].High,
                           Low = stockPrice[i].Low,
                           Close = stockPrice[i].Close,
                        };
                        context.StockPrices.Add(sp);
                        
                    }
                    context.SaveChanges();
                    
                }
            }
        }
    }
}
