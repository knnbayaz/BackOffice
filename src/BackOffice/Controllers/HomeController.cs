using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackOffice.Models;
using BackOffice.BusinessLayer;

namespace BackOffice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            List<MeterInfo> meterList = new List<MeterInfo>();

            meterList.Add(new MeterInfo()
            {
                EnxpId = 1,
                EtsoCode = "40Z0001",
                PmumId = 1,
                MeterName = "Meter_1",
                MeterGroup = "AG",
                DistrictName = "Bedas",
                CityName = "İstanbul",
                TariffType = Tariff.Ticarethane,
                AGOG = AGOG.AG,
                MunicipalityTaxRatio = false,
                IsInPortfolio = true,
            });

            meterList.Add(new MeterInfo()
            {
                EnxpId = 2,
                EtsoCode = "40Z0002",
                PmumId = 2,
                MeterName = "Meter_2",
                MeterGroup = "OG",
                DistrictName = "Ayedas",
                CityName = "İstanbul",
                TariffType = Tariff.Ticarethane,
                AGOG = AGOG.OG,
                MunicipalityTaxRatio = true,
                IsInPortfolio = true,
            });

            List<ConsumeProfile> periodConsumeList = new List<ConsumeProfile>();

            periodConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.AG,
                CalculateMunicipalityTax = false,
                Consume = 1000M,
                EtsoCode = "40Z0001",
                Period = new DateTime(2016, 8, 1)
            });

            periodConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.OG,
                CalculateMunicipalityTax = false,
                Consume = 2000M,
                EtsoCode = "40Z0002",
                Period = new DateTime(2016, 8, 1)
            });


            List<ConsumeProfile> clearingConsumeList = new List<ConsumeProfile>();

            clearingConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.AG,
                CalculateMunicipalityTax = false,
                Consume = -500M,
                EtsoCode = "40Z0001",
                Period = new DateTime(2016, 7, 1)
            });

            clearingConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.OG,
                CalculateMunicipalityTax = false,
                Consume = 400M,
                EtsoCode = "40Z0002",
                Period = new DateTime(2016, 7, 1)
            });


            List<ConsumeProfile> correctionConsumeList = new List<ConsumeProfile>();

            correctionConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.AG,
                CalculateMunicipalityTax = false,
                Consume = -100M,
                EtsoCode = "40Z0001",
                Period = new DateTime(2016, 5, 1)
            });

            correctionConsumeList.Add(new ConsumeProfile()
            {
                AGOG = (int)AGOG.OG,
                CalculateMunicipalityTax = false,
                Consume = 100M,
                EtsoCode = "40Z0002",
                Period = new DateTime(2016, 5, 1)
            });

            List<TariffPrice> tariffPriceList = new List<TariffPrice>();


            tariffPriceList.Add(new TariffPrice()
            {
                StartPeriod = new DateTime(2016, 7, 1),
                EndPeriod = new DateTime(2016, 9, 1),
                AGDistributionUnitPrice = 0.08M,
                OGDistributionUnitPrice = 0.07M

            });

            tariffPriceList.Add(new TariffPrice()
            {
                StartPeriod = new DateTime(2016, 7, 1),
                EndPeriod = new DateTime(2016, 9, 1),
                AGDistributionUnitPrice = 0.09M,
                OGDistributionUnitPrice = 0.08M

            });

            tariffPriceList.Add(new TariffPrice()
            {
                StartPeriod = new DateTime(2016,10, 1),
                EndPeriod = new DateTime(2016, 12, 1),
                AGDistributionUnitPrice = 0.10M,
                OGDistributionUnitPrice = 0.09M
                
            });

            InvoiceCalculator calculator = new InvoiceCalculator(new DateTime(2016, 8, 1), tariffPriceList);

            var result = calculator.CalculateOverallInvoice(meterList, periodConsumeList, clearingConsumeList, correctionConsumeList);


            return View(result);
        }
    }
}
