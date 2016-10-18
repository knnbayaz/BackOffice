using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models
{
    public class MeterInfo
    {
        public int MeterInfoId { get; set; }

        public int EnxpId { get; set; }

        public string EtsoCode { get; set; }

        public int PmumId { get; set; }

        public string MeterName { get; set; }

        public string MeterGroup { get; set; }

        public string DistrictName { get; set; }

        public string CityName { get; set; }

        public Tariff TariffType { get; set; }

        public AGOG AGOG { get; set; }

        public bool MunicipalityTaxRatio { get; set; }

        public bool IsInPortfolio { get; set; }

        public virtual ICollection<MeterInvoiceInfo> MeterInvoiceInfos { get; set; }
        public virtual ICollection<GDDKTracking> GDDTrackings { get; set; }

    }
}
