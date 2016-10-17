using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models
{
    public class MeterInvoiceInfo
    {
        public int MeterInvoiceInfoId { get; set; }

        public DateTime Period { get; set; }

        public decimal PeriodConsumeTotalPrice { get; set; }

        public decimal? ClearingConsumeTotalPrice { get; set; }

        public decimal? CorrectionConsumeTotalPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalPriceWithTax { get; set; }


        public virtual MeterInfo MeterInfo { get; set; }

        public virtual ICollection<MeterInvoiceDetailInfo> MeterInvoiceDetailInfos { get; set; }

    }
}
