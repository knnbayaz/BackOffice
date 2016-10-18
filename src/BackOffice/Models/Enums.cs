using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models
{
    public enum ConsumeType
    {
        Period = 1,
        Clearing = 2,
        Correction = 3
    }

    public enum Tariff
    {
        Sanayi = 1,
        Ticarethane = 2,
        Mesken = 6
    }

    public enum AGOG
    {
        AG = 1,
        OG = 2
    }
}
