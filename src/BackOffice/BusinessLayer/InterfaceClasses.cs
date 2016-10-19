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

    public interface ITariffPrice
    {
        DateTime StartPeriod { get; set; }

        DateTime EndPeriod { get; set; }

        decimal AGDistributionUnitPrice { get; set; }

        decimal OGDistributionUnitPrice { get; set; }
    }

    public class ConsumeProfile : IConsumeProfile
    {
        private int _agog;
        private bool _calculateMunicipalityTax;
        private decimal _consume;
        private string _etsoCode;
        private DateTime _period;

        public int AGOG
        {
            get
            {
                return _agog;
            }

            set
            {
                _agog = value;
            }
        }

        public bool CalculateMunicipalityTax
        {
            get
            {
                return _calculateMunicipalityTax;
            }

            set
            {
                _calculateMunicipalityTax = value;
            }
        }

        public decimal Consume
        {
            get
            {
                return _consume;
            }

            set
            {
                _consume = value;
            }
        }

        public string EtsoCode
        {
            get
            {
                return _etsoCode;
            }

            set
            {
                _etsoCode = value;
            }
        }

        public DateTime Period
        {
            get
            {
                return _period;
            }

            set
            {
                _period = value;
            }
        }
    }


    public class TariffPrice : ITariffPrice
    {
        decimal _agDistributionUnitPrice;
        decimal _ogDistributionUnitPrice;
        DateTime _startPeriod;
        DateTime _endPeriod;

        public decimal AGDistributionUnitPrice
        {
            get
            {
                return _agDistributionUnitPrice;
            }

            set
            {
                _agDistributionUnitPrice = value;
            }
        }

        public DateTime EndPeriod
        {
            get
            {
                return _endPeriod;
            }

            set
            {
                _endPeriod = value;
            }
        }

        public decimal OGDistributionUnitPrice
        {
            get
            {
                return _ogDistributionUnitPrice;
            }

            set
            {
                _ogDistributionUnitPrice = value;
            }
        }

        public DateTime StartPeriod
        {
            get
            {
                return _startPeriod;
            }

            set
            {
                _startPeriod = value;
            }
        }
    }
}
