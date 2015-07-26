materialAdmin
    // =========================================================================
    // Securities used by security Explorer
    // =========================================================================

    .service('securitiesExploreService', ['$resource', function ($resource) {
        this.getSecurities = function (id, securityCode, securityName, exchange) {
            var gsList = $resource("data/securities-explorer.json");
            return gsList.get({
                id: id,
                securityCode: securityCode,
                securityName: securityName,
                exchange: exchange
            });
        }
    }])

    // =========================================================================
    // Securities used by security grid
    // =========================================================================
    .service('securitiesList', ['$resource', function ($resource) {
        var vm = this;
        vm.getSecurities =
            [{ "code": "$BCOM", "securityName": "Bloomberg Commodity", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 94.14, "high": 94.36, "low": 93.19, "close": 93.29, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$BVSP", "securityName": "Bovespa", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 49804.289, "high": 49831.461, "low": 48624.141, "close": 49245.84, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$CCI", "securityName": "Continuous Commodity", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 405.3, "high": 405.38, "low": 402.87, "close": 403.15, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$COMP", "securityName": "NASDAQ Composite", "exchange": "XNAS", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 5166.91, "high": 5167.54, "low": 5084.51, "close": 5088.63, "volume": "1,907,500,032", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$COMP" },
{ "code": "$DAX", "securityName": "DAX (Deutscher Aktienindex)", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 11467.83, "high": 11542.9, "low": 11334.77, "close": 11347.45, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$DJI", "securityName": "Dow Jones Industrial", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 17731.051, "high": 17756.539, "low": 17553.73, "close": 17568.529, "volume": "378,800,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJI" },
{ "code": "$FT100", "securityName": "FTSE 100", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 6655.01, "high": 6684.81, "low": 6573.96, "close": 6579.81, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$HS", "securityName": "Hang Seng", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 25279.949, "high": 25279.949, "low": 25073.199, "close": 25128.51, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$MID", "securityName": "S&P MidCap 400", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 1489.8, "high": 1491.96, "low": 1474.59, "close": 1476.74, "volume": "536,200,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$MID" },
{ "code": "$MXX", "securityName": "Mexico IPC", "exchange": "World Indices", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 44840.25, "high": 44898.129, "low": 44209.531, "close": 44249.488, "volume": "0", "lastDate": "2015-07-24", "marketCap": 0, "exist": "#N/A" },
{ "code": "$NDX", "securityName": "NASDAQ-100", "exchange": "XNAS", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 4630.95, "high": 4632.06, "low": 4552.4, "close": 4557.37, "volume": "666,200,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$NDX" },
{ "code": "$RMC", "securityName": "Russell Mid Cap", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 1692.17, "high": 1693.81, "low": 1674.55, "close": 1677.5, "volume": "", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$RMC" },
{ "code": "$RUI", "securityName": "Russell 1000", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 1172.95, "high": 1173.66, "low": 1158.15, "close": 1159.58, "volume": "3,370,800,128", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$RUI" },
{ "code": "$RUMIC", "securityName": "Russell Micro Cap", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 494.47, "high": 494.61, "low": 486.96, "close": 486.96, "volume": "", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$RUMIC" },
{ "code": "$RUT", "securityName": "Russell 2000", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 1242.39, "high": 1243.58, "low": 1225.43, "close": 1225.99, "volume": "1,179,399,936", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$RUT" },
{ "code": "$SML", "securityName": "S&P SmallCap 600", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 710.5, "high": 710.5, "low": 700.86, "close": 701.72, "volume": "302,000,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$SML" },
{ "code": "$SPX", "securityName": "S&P 500", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 2102.24, "high": 2106.01, "low": 2077.09, "close": 2079.65, "volume": "2,465,400,064", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$SPX" },
{ "code": "$SPXEW", "securityName": "S&P 500 Equal Weight", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 3258.32, "high": 3258.32, "low": 3217.89, "close": 3222.92, "volume": "2,465,400,064", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$SPXEW" },
{ "code": "$W5000", "securityName": "Wilshire 5000 Total Market", "exchange": "XNAS", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 22131.98, "high": 22171.891, "low": 21882.811, "close": 21906.75, "volume": "", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$W5000" },
{ "code": "$XAO", "securityName": "ASX All Ordinaries", "exchange": "XASX", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 5581.3, "high": 5595.5, "low": 5539, "close": 5556.804, "volume": "621,667,584", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XAO" },
{ "code": "$XDJ", "securityName": "S&P/ASX 200 Consumer Discretionary", "exchange": "XASX", "type": "Index", "gicsSector": "Consumer Discretionary", "icbIndustry": "-", "open": 1891.9, "high": 1892.1, "low": 1867.6, "close": 1874.552, "volume": "54,612,196", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XDJ" },
{ "code": "$XEJ", "securityName": "S&P/ASX 200 Energy", "exchange": "XASX", "type": "Index", "gicsSector": "Energy", "icbIndustry": "-", "open": 10584.2, "high": 10675.4, "low": 10547.1, "close": 10603.989, "volume": "43,016,160", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XEJ" },
{ "code": "$XFJ", "securityName": "S&P/ASX 200 Financials", "exchange": "XASX", "type": "Index", "gicsSector": "Financials", "icbIndustry": "-", "open": 6555.7, "high": 6589, "low": 6506.8, "close": 6523.139, "volume": "129,889,560", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XFJ" },
{ "code": "$XFL", "securityName": "S&P/ASX 50", "exchange": "XASX", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 5734.4, "high": 5757.9, "low": 5695.1, "close": 5713.326, "volume": "214,366,960", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XFL" },
{ "code": "$XHJ", "securityName": "S&P/ASX 200 Health Care", "exchange": "XASX", "type": "Index", "gicsSector": "Health Care", "icbIndustry": "-", "open": 19045.6, "high": 19073.1, "low": 18908.699, "close": 18962.254, "volume": "16,526,974", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XHJ" },
{ "code": "$XIJ", "securityName": "S&P/ASX 200 Information Technology", "exchange": "XASX", "type": "Index", "gicsSector": "Information Technology", "icbIndustry": "-", "open": 808.5, "high": 808.9, "low": 797.5, "close": 805.145, "volume": "2,527,942", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XIJ" },
{ "code": "$XMJ", "securityName": "S&P/ASX 200 Materials", "exchange": "XASX", "type": "Index", "gicsSector": "Materials", "icbIndustry": "-", "open": 8441.3, "high": 8441.3, "low": 8334.2, "close": 8388.772, "volume": "131,641,520", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XMJ" },
{ "code": "$XNJ", "securityName": "S&P/ASX 200 Industrials (Sector)", "exchange": "XASX", "type": "Index", "gicsSector": "Industrials", "icbIndustry": "-", "open": 4804.1, "high": 4810.1, "low": 4757.6, "close": 4790.019, "volume": "59,647,616", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XNJ" },
{ "code": "$XPJ", "securityName": "S&P/ASX200 A-Reit (Sector)", "exchange": "XASX", "type": "Index", "gicsSector": "Financials", "icbIndustry": "-", "open": 1264.9, "high": 1277.4, "low": 1251.7, "close": 1257.765, "volume": "62,078,060", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XPJ" },
{ "code": "$XSJ", "securityName": "S&P/ASX 200 Consumer Staples", "exchange": "XASX", "type": "Index", "gicsSector": "Consumer Staples", "icbIndustry": "-", "open": 8840.1, "high": 8857, "low": 8724.8, "close": 8784.719, "volume": "18,262,942", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XSJ" },
{ "code": "$XSO", "securityName": "S&P/ASX Small Ordinaries", "exchange": "XASX", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 2105.7, "high": 2105.7, "low": 2077.6, "close": 2084.195, "volume": "196,773,328", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XSO" },
{ "code": "$XTJ", "securityName": "S&P/ASX 200 Telecommunication Services", "exchange": "XASX", "type": "Index", "gicsSector": "Telecommunication Services", "icbIndustry": "-", "open": 2245.7, "high": 2259.5, "low": 2235, "close": 2248.485, "volume": "16,898,416", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XTJ" },
{ "code": "$XUJ", "securityName": "S&P/ASX 200 Utilities", "exchange": "XASX", "type": "Index", "gicsSector": "Utilities", "icbIndustry": "-", "open": 6427.6, "high": 6481.7, "low": 6401.6, "close": 6456.26, "volume": "28,570,452", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XUJ" },
{ "code": "&C_CCB", "securityName": "Corn", "exchange": "Futures Continuous", "type": "Futures Contract", "gicsSector": "-", "icbIndustry": "-", "open": 364, "high": 367.75, "low": 359.5, "close": 360, "volume": "288.153", "lastDate": "2015-05-22", "marketCap": 0, "exist": "#N/A" },
{ "code": "DIA", "securityName": "SPDR Dow Jones Industrial Average", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 177.23, "high": 177.25, "low": 175.31, "close": 175.52, "volume": "4,591,323", "lastDate": "2015-07-24", "marketCap": 14356283392, "exist": "DIA" },
{ "code": "EWG", "securityName": "iShares MSCI Germany", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 28.6, "high": 28.63, "low": 28.22, "close": 28.25, "volume": "8,472,333", "lastDate": "2015-07-24", "marketCap": 5093474816, "exist": "EWG" },
{ "code": "EWW", "securityName": "iShares MSCI Mexico Capped", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 55.63, "high": 55.64, "low": 54.91, "close": 54.99, "volume": "4,852,018", "lastDate": "2015-07-24", "marketCap": 1963143040, "exist": "EWW" },
{ "code": "EWZ", "securityName": "iShares MSCI Brazil Capped", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 28.86, "high": 28.9, "low": 28.15, "close": 28.5, "volume": "26,799,668", "lastDate": "2015-07-24", "marketCap": 3105074944, "exist": "EWZ" },
{ "code": "IBB", "securityName": "iShares Nasdaq Biotechnology", "exchange": "XNAS", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 386.63, "high": 389, "low": 375.96, "close": 377.58, "volume": "3,922,083", "lastDate": "2015-07-24", "marketCap": 6985229824, "exist": "IBB" },
{ "code": "IJR", "securityName": "iShares Core S&P Small-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 116.51, "high": 116.83, "low": 114.91, "close": 115.08, "volume": "877.003", "lastDate": "2015-07-24", "marketCap": 13890156544, "exist": "IJR" },
{ "code": "IWM", "securityName": "iShares Russell 2000", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 123.48, "high": 123.71, "low": 121.49, "close": 121.58, "volume": "39,533,028", "lastDate": "2015-07-24", "marketCap": 28887408640, "exist": "IWM" },
{ "code": "QQQ", "securityName": "PowerShares QQQ Trust Series 1", "exchange": "XNAS", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 112.8, "high": 113.003, "low": 110.93, "close": 111.1, "volume": "30,844,714", "lastDate": "2015-07-24", "marketCap": 52933591040, "exist": "QQQ" },
{ "code": "RSP", "securityName": "Guggenheim Invest S&P 500 Eql Wght", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 80.2, "high": 80.2, "low": 79.201, "close": 79.34, "volume": "994.383", "lastDate": "2015-07-24", "marketCap": 5891698176, "exist": "RSP" },
{ "code": "SLYG", "securityName": "SPDR S&P 600 Small Cap Growth", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 191.23, "high": 191.23, "low": 188.464, "close": 188.807, "volume": "5.750", "lastDate": "2015-07-24", "marketCap": 311532896, "exist": "SLYG" },
{ "code": "SPY", "securityName": "SPDR S&P 500", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 210.3, "high": 210.37, "low": 207.6, "close": 208, "volume": "117,754,976", "lastDate": "2015-07-24", "marketCap": 1.75871E+11, "exist": "SPY" },
{ "code": "STW", "securityName": "SPDR S&P/ASX 200 Fund", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 51.87, "high": 52.3, "low": 51.73, "close": 51.91, "volume": "219.209", "lastDate": "2015-07-24", "marketCap": 3048709632, "exist": "STW" },
{ "code": "VTI", "securityName": "Vanguard Total Stock Market Index", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 108.75, "high": 108.83, "low": 107.389, "close": 107.56, "volume": "2,073,472", "lastDate": "2015-07-24", "marketCap": 41337896960, "exist": "VTI" },
{ "code": "XLB", "securityName": "Materials Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 46.08, "high": 46.1, "low": 44.785, "close": 45.08, "volume": "7,262,228", "lastDate": "2015-07-24", "marketCap": 3215273728, "exist": "XLB" },
{ "code": "XLE", "securityName": "Energy Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 70.87, "high": 70.9, "low": 69.25, "close": 69.51, "volume": "12,554,077", "lastDate": "2015-07-24", "marketCap": 6577328128, "exist": "XLE" },
{ "code": "XLF", "securityName": "Financial Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 25.33, "high": 25.35, "low": 25.08, "close": 25.12, "volume": "26,116,668", "lastDate": "2015-07-24", "marketCap": 18949156864, "exist": "XLF" },
{ "code": "XLI", "securityName": "Industrial Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 53.58, "high": 53.62, "low": 52.81, "close": 52.9, "volume": "10,889,114", "lastDate": "2015-07-24", "marketCap": 7116425728, "exist": "XLI" },
{ "code": "XLK", "securityName": "Technology Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 42.8, "high": 42.86, "low": 42.325, "close": 42.36, "volume": "9,746,087", "lastDate": "2015-07-24", "marketCap": 15205371904, "exist": "XLK" },
{ "code": "AIG", "securityName": "American International Group Inc", "exchange": "XNYS", "type": "Fully Paid Ordinary/Common Stock", "gicsSector": "Financials", "icbIndustry": "Financials", "open": 64.19, "high": 64.35, "low": 63.57, "close": 63.64, "volume": "4,468,544", "lastDate": "2015-07-24", "marketCap": 93954965504, "exist": "AIG" },
{ "code": "DBC", "securityName": "PowerShares DB Commodity Index Tracking", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 16.2, "high": 16.23, "low": 16.065, "close": 16.14, "volume": "1,264,790", "lastDate": "2015-07-24", "marketCap": 3993036544, "exist": "DBC" },
{ "code": "EWH", "securityName": "iShares MSCI Hong Kong", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 22.41, "high": 22.441, "low": 22.26, "close": 22.31, "volume": "2,177,659", "lastDate": "2015-07-24", "marketCap": 2580151552, "exist": "EWH" },
{ "code": "GCC", "securityName": "GreenHaven Continuous Commodity Index", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 20.45, "high": 20.45, "low": 20.3, "close": 20.36, "volume": "82.625", "lastDate": "2015-07-24", "marketCap": 276896000, "exist": "GCC" },
{ "code": "IJH", "securityName": "iShares Core S&P Mid-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 148.68, "high": 148.95, "low": 147.11, "close": 147.38, "volume": "922.986", "lastDate": "2015-07-24", "marketCap": 23396575232, "exist": "IJH" },
{ "code": "ISO", "securityName": "iShares S&P/ASX Small Ordinaries ETF", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 3.77, "high": 3.77, "low": 3.77, "close": 3.77, "volume": "4.920", "lastDate": "2015-07-24", "marketCap": 31835192, "exist": "ISO" },
{ "code": "IVOO", "securityName": "Vanguard S&P Mid Cap 400", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 100.74, "high": 100.8, "low": 99.6, "close": 99.79, "volume": "11.675", "lastDate": "2015-07-24", "marketCap": 239496240, "exist": "IVOO" },
{ "code": "IWB", "securityName": "iShares Russell 1000", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 117.67, "high": 117.67, "low": 116.12, "close": 116.32, "volume": "626.697", "lastDate": "2015-07-24", "marketCap": 9863936000, "exist": "IWB" },
{ "code": "IWC", "securityName": "iShares Micro-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 79.45, "high": 79.45, "low": 78.02, "close": 78.14, "volume": "93.249", "lastDate": "2015-07-24", "marketCap": 906424000, "exist": "IWC" },
{ "code": "IWR", "securityName": "iShares Russell Mid-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 170.11, "high": 170.197, "low": 168.22, "close": 168.51, "volume": "250.667", "lastDate": "2015-07-24", "marketCap": 10178003968, "exist": "IWR" },
{ "code": "JKG", "securityName": "iShares Morningstar Mid-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 150.72, "high": 150.72, "low": 148.96, "close": 149.21, "volume": "18.235", "lastDate": "2015-07-24", "marketCap": 283499008, "exist": "JKG" },
{ "code": "JKJ", "securityName": "iShares Morningstar Small-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 139.707, "high": 139.71, "low": 138.91, "close": 138.96, "volume": "2.950", "lastDate": "2015-07-24", "marketCap": 208440016, "exist": "JKJ" },
{ "code": "SLY", "securityName": "SPDR S&P 600 Small Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 107.98, "high": 107.98, "low": 105.63, "close": 105.78, "volume": "10.804", "lastDate": "2015-07-24", "marketCap": 407255424, "exist": "SLY" },
{ "code": "SSO", "securityName": "SPDR S&P/ASX Small Ordinaries Fund", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 11.07, "high": 11.07, "low": 11.07, "close": 11.07, "volume": "8.941", "lastDate": "2015-07-24", "marketCap": 7781978, "exist": "SSO" },
{ "code": "VB", "securityName": "Vanguard Small-Cap Index", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 120.7, "high": 120.94, "low": 119.1, "close": 119.27, "volume": "518.745", "lastDate": "2015-07-24", "marketCap": 8595350528, "exist": "VB" },
{ "code": "VIOO", "securityName": "Vanguard S&P Small Cap 600", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 105.67, "high": 105.7, "low": 104.21, "close": 104.36, "volume": "7.983", "lastDate": "2015-07-24", "marketCap": 104360000, "exist": "VIOO" },
{ "code": "VO", "securityName": "Vanguard Mid-Cap Index", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 127.65, "high": 127.97, "low": 126.46, "close": 126.72, "volume": "271.426", "lastDate": "2015-07-24", "marketCap": 7077476864, "exist": "VO" },
{ "code": "VONE", "securityName": "Vanguard Russell 1000 Index", "exchange": "XNAS", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 97.18, "high": 97.18, "low": 95.983, "close": 96.06, "volume": "12.935", "lastDate": "2015-07-24", "marketCap": 278573984, "exist": "VONE" },
{ "code": "VSO", "securityName": "Vanguard MSCI Australian Small Companies Index ETF", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 43.3, "high": 43.3, "low": 42.96, "close": 42.96, "volume": "2.747", "lastDate": "2015-07-24", "marketCap": 75925400, "exist": "VSO" },
{ "code": "VTWO", "securityName": "Vanguard Russell 2000 Index", "exchange": "XNAS", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 99.41, "high": 99.44, "low": 97.88, "close": 97.89, "volume": "26.883", "lastDate": "2015-07-24", "marketCap": 313248000, "exist": "VTWO" },
{ "code": "VV", "securityName": "Vanguard Large-Cap Index", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 96.83, "high": 96.83, "low": 95.525, "close": 95.66, "volume": "131.055", "lastDate": "2015-07-24", "marketCap": 5216196096, "exist": "VV" },
{ "code": "$DJUSBM", "securityName": "DJ US Basic Materials", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Basic Materials", "open": 304.5, "high": 304.5, "low": 295.83, "close": 297.55, "volume": "234,800,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSBM" },
{ "code": "$DJUSCY", "securityName": "DJ US Consumer Services", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Consumer Services", "open": 750.94, "high": 761.29, "low": 748.6, "close": 749.27, "volume": "540,099,968", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSCY" },
{ "code": "$DJUSEN", "securityName": "DJ US Oil & Gas", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Oil & Gas", "open": 593.19, "high": 593.19, "low": 578.79, "close": 580.83, "volume": "456,800,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSEN" },
{ "code": "$DJUSFN", "securityName": "DJ US Financials", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Financials", "open": 461.92, "high": 463.26, "low": 458.84, "close": 459.32, "volume": "634,499,968", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSFN" },
{ "code": "$DJUSHC", "securityName": "DJ US Health Care", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Health Care", "open": 821.68, "high": 821.68, "low": 800.3, "close": 801.43, "volume": "256,400,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSHC" },
{ "code": "$DJUSIN", "securityName": "DJ US Industrials", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Industrials", "open": 503.68, "high": 503.87, "low": 497.28, "close": 497.99, "volume": "329,300,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSIN" },
{ "code": "$DJUSNC", "securityName": "DJ US Consumer Goods", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Consumer Goods", "open": 538.25, "high": 538.45, "low": 532.81, "close": 533.88, "volume": "258,100,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSNC" },
{ "code": "$DJUSTC", "securityName": "DJ US Technology", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Technology", "open": 1107.07, "high": 1109.91, "low": 1095.65, "close": 1097.72, "volume": "653,000,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSTC" },
{ "code": "$DJUSTL", "securityName": "DJ US Telecommunications", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Telecommunications", "open": 159.34, "high": 161.37, "low": 158.99, "close": 159, "volume": "194,900,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSTL" },
{ "code": "$DJUSUT", "securityName": "DJ US Utilities", "exchange": "XASE", "type": "Index", "gicsSector": "-", "icbIndustry": "Utilities", "open": 209.22, "high": 209.98, "low": 208.64, "close": 209.21, "volume": "108,800,000", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$DJUSUT" },
{ "code": "GLD", "securityName": "SPDR Gold Shares", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 103.61, "high": 105.59, "low": 103.431, "close": 105.35, "volume": "11,572,679", "lastDate": "2015-07-24", "marketCap": 32026398720, "exist": "GLD" },
{ "code": "XLP", "securityName": "Consumer Staples Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 50.08, "high": 50.08, "low": 49.62, "close": 49.68, "volume": "9,950,133", "lastDate": "2015-07-24", "marketCap": 7694031360, "exist": "XLP" },
{ "code": "XLU", "securityName": "Utilities Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 42.31, "high": 42.48, "low": 42.18, "close": 42.33, "volume": "8,589,088", "lastDate": "2015-07-24", "marketCap": 6117707776, "exist": "XLU" },
{ "code": "XLV", "securityName": "Health Care Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 76, "high": 76.05, "low": 74.71, "close": 74.85, "volume": "13,229,714", "lastDate": "2015-07-24", "marketCap": 10989126656, "exist": "XLV" },
{ "code": "XLY", "securityName": "Consumer Discretionary Select Sector SPDR", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 80.4, "high": 80.4, "low": 78.71, "close": 78.85, "volume": "5,169,588", "lastDate": "2015-07-24", "marketCap": 8449033216, "exist": "XLY" },
{ "code": "$XJO", "securityName": "S&P/ASX 200", "exchange": "XASX", "type": "Index", "gicsSector": "-", "icbIndustry": "-", "open": 5590.3, "high": 5607.2, "low": 5548, "close": 5566.104, "volume": "501,593,760", "lastDate": "2015-07-24", "marketCap": 0, "exist": "$XJO" },
{ "code": "EWJ", "securityName": "iShares MSCI Japan", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 12.85, "high": 12.86, "low": 12.74, "close": 12.75, "volume": "34,955,536", "lastDate": "2015-07-24", "marketCap": 12262949888, "exist": "EWJ" },
{ "code": "FXI", "securityName": "iShares China Large-Cap", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 42.15, "high": 42.17, "low": 41.47, "close": 41.74, "volume": "25,727,056", "lastDate": "2015-07-24", "marketCap": 6298566144, "exist": "FXI" },
{ "code": "IYR", "securityName": "iShares US Real Estate", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 73.96, "high": 74.28, "low": 73.7, "close": 73.95, "volume": "5,631,997", "lastDate": "2015-07-24", "marketCap": 4947254784, "exist": "IYR" },
{ "code": "MDY", "securityName": "SPDR S&P MidCap 400", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 270.89, "high": 271.47, "low": 268.09, "close": 268.52, "volume": "2,469,589", "lastDate": "2015-07-24", "marketCap": 16474650624, "exist": "MDY" },
{ "code": "IVV", "securityName": "iShares Core S&P 500", "exchange": "ARCX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "Financials", "open": 211.56, "high": 211.64, "low": 208.86, "close": 209.25, "volume": "3,545,266", "lastDate": "2015-07-24", "marketCap": 55346626560, "exist": "IVV" },
{ "code": "SFY", "securityName": "SPDR S&P/ASX 50 Fund", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 54.43, "high": 54.67, "low": 54.18, "close": 54.27, "volume": "24.134", "lastDate": "2015-07-24", "marketCap": 441048128, "exist": "SFY" },
{ "code": "SLF", "securityName": "SPDR S&P/ASX 200 Listed Property Fund", "exchange": "XASX", "type": "Exchange Traded Fund", "gicsSector": "-", "icbIndustry": "-", "open": 11.62, "high": 11.7, "low": 11.46, "close": 11.52, "volume": "118.828", "lastDate": "2015-07-24", "marketCap": 564480000, "exist": "SLF" }];
    }])

    // =========================================================================
    // Header Messages and Notifications list Data
    // =========================================================================

    .service('messageService', ['$resource', function ($resource) {
        this.getMessage = function (img, user, text) {
            var gmList = $resource("data/messages-notifications.json");
            return gmList.get({
                img: img,
                user: user,
                text: text
            });
        }
    }])


    // =========================================================================
    // Best Selling Widget Data (Home Page)
    // =========================================================================

    .service('bestsellingService', ['$resource', function ($resource) {
        this.getBestselling = function (img, name, range) {
            var gbList = $resource("data/best-selling.json");

            return gbList.get({
                img: img,
                name: name,
                range: range,
            });
        }
    }])


    // =========================================================================
    // Todo List Widget Data
    // =========================================================================

    .service('todoService', ['$resource', function ($resource) {
        this.getTodo = function (todo) {
            var todoList = $resource("data/todo.json");

            return todoList.get({
                todo: todo
            });
        }
    }])


    // =========================================================================
    // Recent Items Widget Data
    // =========================================================================

    .service('recentitemService', ['$resource', function ($resource) {
        this.getRecentitem = function (id, name, price) {
            var recentitemList = $resource("data/recent-items.json");

            return recentitemList.get({
                id: id,
                name: name,
                price: price
            })
        }
    }])


    // =========================================================================
    // Recent Posts Widget Data
    // =========================================================================

    .service('recentpostService', ['$resource', function ($resource) {
        this.getRecentpost = function (img, user, text) {
            var recentpostList = $resource("data/messages-notifications.json");

            return recentpostList.get({
                img: img,
                user: user,
                text: text
            })
        }
    }])


    // =========================================================================
    // Nice Scroll - Custom Scroll bars
    // =========================================================================
    .service('nicescrollService', function () {
        var ns = {};
        ns.niceScroll = function (selector, color, cursorWidth) {
            $(selector).niceScroll({
                cursorcolor: color,
                cursorborder: 0,
                cursorborderradius: 0,
                cursorwidth: cursorWidth,
                bouncescroll: true,
                mousescrollstep: 100,
                autohidemode: false
            });
        }

        return ns;
    })


    //==============================================
    // BOOTSTRAP GROWL
    //==============================================

    .service('growlService', function () {
        var gs = {};
        gs.growl = function (message, type) {
            $.growl({
                message: message
            }, {
                type: type,
                allow_dismiss: false,
                label: 'Cancel',
                className: 'btn-xs btn-inverse',
                placement: {
                    from: 'top',
                    align: 'right'
                },
                delay: 2500,
                animate: {
                    enter: 'animated bounceIn',
                    exit: 'animated bounceOut'
                },
                offset: {
                    x: 20,
                    y: 85
                }
            });
        }

        return gs;
    })
