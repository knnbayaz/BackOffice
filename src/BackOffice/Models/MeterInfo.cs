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

        public int PmumId { get; set; }

        public string MeterName { get; set; }

        public string DistrictName { get; set; }

        public string CityName { get; set; }

        public enum Tariff {
            Sanayi = 1,
            Ticarethane = 2,
            Mesken = 6
        }

        public enum AGOG {
            AG = 1,
            OG = 2
        }

        public int MunicipalityTaxRatio { get; set; }

        public virtual ICollection<MeterInvoiceInfo> MeterInvoiceInfos { get; set; }
        public virtual ICollection<GDDKTracking> GDDTrackings { get; set; }

    }
}
