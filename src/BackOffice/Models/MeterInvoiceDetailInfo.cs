using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models
{
    public class MeterInvoiceDetailInfo
    {
        public int MeterInvoiceDetailInfoId { get; set; }

        public ConsumeType ConsumeType { get; set; }

        public decimal Consume { get; set; }

        public decimal EnergyPrice { get; set; }

        public decimal DistributionPrice { get; set; }

        public decimal MunicipalityTax { get; set; }

        public decimal EnergyFundTax { get; set; }

        public decimal TRTTax { get; set; }


        public virtual MeterInvoiceInfo MeterInvoiceInfo { get; set; }

        public GDDKTracking GDDKTracking { get; set; }

    }
}
