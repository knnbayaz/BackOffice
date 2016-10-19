using BackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.BusinessLayer
{
    public class InvoiceCalculator
    {

        public InvoiceCalculator(DateTime period, List<TariffPrice> tariffPriceList)
        {
            Period = period;

            TariffPriceList = new List<TariffPrice>();

            TariffPriceList = tariffPriceList;

            InvoiceDetails = new List<MeterInvoiceDetailInfo>();
        }


        public DateTime Period { get; set; }

        public List<TariffPrice> TariffPriceList { get; set; }

        public List<IConsumeProfile> PeriodConsumeList { get; set; }

        public List<MeterInvoiceDetailInfo> InvoiceDetails { get; set; }


        public void CalculatePeriodInvoice()
        {
            decimal AGPrice = TariffPriceList.Where(t => t.StartPeriod <= Period && t.EndPeriod >= Period).Select(t => t.AGDistributionUnitPrice).FirstOrDefault();

            decimal OGPrice = TariffPriceList.Where(t => t.StartPeriod <= Period && t.EndPeriod >= Period).Select(t => t.OGDistributionUnitPrice).FirstOrDefault();

            foreach (var item in PeriodConsumeList)
            {

                decimal energyPrice = Math.Round(item.Consume * 0.167M, 2);

                decimal distributionPrice;

                if (item.AGOG == (int)AGOG.AG)
                    distributionPrice = Math.Round(AGPrice * item.Consume, 2);
                else
                    distributionPrice = Math.Round(OGPrice * item.Consume, 2);

                decimal municipalityTax;

                if (item.CalculateMunicipalityTax)
                    municipalityTax = Math.Round(energyPrice * 0.01M, 2);
                else
                    municipalityTax = 0M;

                decimal energyFundTax = Math.Round(energyPrice * 0.01M, 2);

                decimal trtTax = Math.Round(energyPrice * 0.02M, 2);


                InvoiceDetails.Add(new MeterInvoiceDetailInfo()
                {
                    EnergyPrice = energyPrice,
                    DistributionPrice = distributionPrice,
                    MunicipalityTax = municipalityTax,
                    EnergyFundTax = energyFundTax,
                    TRTTax = trtTax,
                    Consume = item.Consume,
                    ConsumeType = ConsumeType.Period    
                });
            }
        }

        public MeterInvoiceDetailInfo CalculateUnitInvoice(MeterInfo meter, ConsumeProfile consume, ConsumeType consumeType)
        {



            decimal AGPrice = TariffPriceList.Where(t => t.StartPeriod <= consume.Period && t.EndPeriod >= consume.Period).Select(t => t.AGDistributionUnitPrice).FirstOrDefault();

            decimal OGPrice = TariffPriceList.Where(t => t.StartPeriod <= consume.Period && t.EndPeriod >= consume.Period).Select(t => t.OGDistributionUnitPrice).FirstOrDefault();



            decimal energyPrice = Math.Round(consume.Consume * 0.167M, 2);

            decimal distributionPrice;

            if (consume.AGOG == (int)AGOG.AG)
                distributionPrice = Math.Round(AGPrice * consume.Consume, 2);
            else
                distributionPrice = Math.Round(OGPrice * consume.Consume, 2);

            decimal municipalityTax;

            if (consume.CalculateMunicipalityTax)
                municipalityTax = Math.Round(energyPrice * 0.01M, 2);
            else
                municipalityTax = 0M;

            decimal energyFundTax = Math.Round(energyPrice * 0.01M, 2);

            decimal trtTax = Math.Round(energyPrice * 0.02M, 2);


            var meterInvoice = new MeterInvoiceDetailInfo()
            {
                EnergyPrice = energyPrice,
                DistributionPrice = distributionPrice,
                MunicipalityTax = municipalityTax,
                EnergyFundTax = energyFundTax,
                TRTTax = trtTax,
                Consume = consume.Consume,
                ConsumeType = consumeType
            };


            return meterInvoice;
        }


        public List<MeterInvoiceInfo> CalculateOverallInvoice(List<MeterInfo> meterList, List<ConsumeProfile> periodConsumeList, List<ConsumeProfile> clearingConsumeList, List<ConsumeProfile> correctionConsumeList )
        {
            var invoiceList = new List<MeterInvoiceInfo>();

            var invoiceDetails = new List<MeterInvoiceDetailInfo>();

            foreach (var meter in meterList)
            {
                 
                var periodConsumeInfo = periodConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(periodConsumeInfo.EtsoCode))
                    invoiceDetails.Add(CalculateUnitInvoice(meter, periodConsumeInfo, ConsumeType.Period));


                var clearingConsumeInfo = clearingConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(clearingConsumeInfo.EtsoCode))
                    invoiceDetails.Add(CalculateUnitInvoice(meter, clearingConsumeInfo, ConsumeType.Clearing));


                var correctionConsumeInfo = correctionConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(correctionConsumeInfo.EtsoCode))
                    invoiceDetails.Add(CalculateUnitInvoice(meter, correctionConsumeInfo, ConsumeType.Correction));

                var meterInvoiceInfo =new MeterInvoiceInfo()
                {
                    Period = Period,
                    MeterInfo = meter,
                    PeriodConsumeTotalPrice = TotalPriceCalculator(invoiceDetails.Where(i => i.ConsumeType == ConsumeType.Period).ToList()),
                    ClearingConsumeTotalPrice = TotalPriceCalculator(invoiceDetails.Where(i => i.ConsumeType == ConsumeType.Clearing).ToList()),
                    CorrectionConsumeTotalPrice = TotalPriceCalculator(invoiceDetails.Where(i => i.ConsumeType == ConsumeType.Correction).ToList()),
                    Tax = TotalTaxCalculator(invoiceDetails),
                    TotalPriceWithTax = TotalPriceWithTax(invoiceDetails)
                    
                    
                };

                meterInvoiceInfo.MeterInvoiceDetailInfos = new List<MeterInvoiceDetailInfo>();

                foreach (var item in invoiceDetails)
                {
                    meterInvoiceInfo.MeterInvoiceDetailInfos.Add(item);
                }

                invoiceList.Add(meterInvoiceInfo);
            }



            return invoiceList;
        }


        private decimal TotalPriceCalculator(List<MeterInvoiceDetailInfo> invoiceDetails)
        {
            decimal price = 0;

            foreach (var item in invoiceDetails)
            {
                price += (item.EnergyPrice + item.DistributionPrice + item.MunicipalityTax + item.EnergyFundTax + item.TRTTax);
            }

            return price;
        }

        private decimal TotalTaxCalculator(List<MeterInvoiceDetailInfo> invoiceDetails)
        {

            return Math.Round(TotalPriceCalculator(invoiceDetails) * 0.18M, 2);
        }

        private decimal TotalPriceWithTax(List<MeterInvoiceDetailInfo> invoiceDetails)
        {
            return TotalPriceCalculator(invoiceDetails) + TotalTaxCalculator(invoiceDetails);
        }





    }
}
