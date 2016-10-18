using BackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.BusinessLayer
{
    public class InvoiceCalculator
    {

        public InvoiceCalculator()
        {
            InvoiceDetails = new List<MeterInvoiceDetailInfo>();
        }


        public InvoiceCalculator(DateTime period, List<ITariffPriceList> tariffPriceList)
        {
            Period = period;

            TariffPriceList = new List<ITariffPriceList>();

            TariffPriceList = tariffPriceList;
        }

        public InvoiceCalculator(DateTime period, List<ITariffPriceList> tariffPriceList, List<IConsumeProfile> consumeList)
        {
            Period = period;

            TariffPriceList = new List<ITariffPriceList>();

            TariffPriceList = tariffPriceList;

            PeriodConsumeList = new List<IConsumeProfile>();

            PeriodConsumeList = consumeList;
        }

        public DateTime Period { get; set; }

        public List<ITariffPriceList> TariffPriceList { get; set; }

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

        public MeterInvoiceDetailInfo CalculateUnitInvoice(MeterInfo meter, IConsumeProfile consume, ConsumeType consumeType)
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


        public List<MeterInvoiceInfo> CalculateOverallInvoice(List<MeterInfo> meterList, List<IConsumeProfile> periodConsumeList, List<IConsumeProfile> clearingConsumeList, List<IConsumeProfile> correctionConsumeList )
        {
            var invoiceList = new List<MeterInvoiceInfo>();
            var periodInvoiceDetail = new MeterInvoiceDetailInfo();
            var clearingInvoiceDetail = new MeterInvoiceDetailInfo();
            var correctionInvoiceDetail = new MeterInvoiceDetailInfo();

            foreach (var meter in meterList)
            {
                 
                var periodConsumeInfo = periodConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(periodConsumeInfo.EtsoCode))
                    periodInvoiceDetail = CalculateUnitInvoice(meter, periodConsumeInfo, ConsumeType.Period);


                var clearingConsumeInfo = clearingConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(clearingConsumeInfo.EtsoCode))
                    clearingInvoiceDetail = periodInvoiceDetail = CalculateUnitInvoice(meter, periodConsumeInfo, ConsumeType.Clearing);


                var correctionConsumeInfo = correctionConsumeList.Where(p => p.EtsoCode == meter.EtsoCode).FirstOrDefault();

                if (!string.IsNullOrEmpty(correctionConsumeInfo.EtsoCode))
                    correctionInvoiceDetail = CalculateUnitInvoice(meter, periodConsumeInfo, ConsumeType.Correction);

                var meterInvoiceInfo =new MeterInvoiceInfo()
                {
                    Period = Period,
                    MeterInfo = meter

                };
            }



            return invoiceList;
        }





    }
}
