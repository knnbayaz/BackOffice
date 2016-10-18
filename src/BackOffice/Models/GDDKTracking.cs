using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models
{
    public class GDDKTracking
    {
        public int GDDKTrackingId { get; set; }

        public int EnxpConsumeId { get; set; }

        public DateTime ConsumePeriod { get; set; }

        public decimal ConsumeBefore { get; set; }

        public decimal ConsumeAfter { get; set; }

        public decimal RemainedConsume { get; set; }


        public virtual MeterInfo MeterInfo { get; set; }

        
        public MeterInvoiceDetailInfo MeterInvoiceDetailInfo { get; set; }

    }
}
