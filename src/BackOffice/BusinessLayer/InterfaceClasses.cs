using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.BusinessLayer
{
    public interface IConsumeProfile
    {
        DateTime Period { get; set; }

        string EtsoCode { get; set; }

        decimal Consume { get; set; }

        bool CalculateMunicipalityTax { get; set; }

        int AGOG { get; set; }

    }

    public interface ITariffPriceList
    {
        DateTime StartPeriod { get; set; }

        DateTime EndPeriod { get; set; }

        decimal AGDistributionUnitPrice { get; set; }

        decimal OGDistributionUnitPrice { get; set; }
    }
}
