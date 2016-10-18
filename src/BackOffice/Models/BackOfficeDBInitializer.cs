using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Data;

namespace BackOffice.Models
{
    public static class BackOfficeDBInitializer
    {

        public static void Initialize(BackOfficeContext context)
        {
            
            context.Database.EnsureCreated();
            

            if (context.MeterInfos.Any())
            {
                return;
            }

            var meters = new MeterInfo[]
            {
                new MeterInfo {EnxpId = 1, PmumId = 1, CityName = "İstanbul", DistrictName = "Bedaş", MeterName = "Meter1", MunicipalityTaxRatio = 1},
                new MeterInfo {EnxpId = 2, PmumId = 2, CityName = "İstanbul", DistrictName = "Ayedaş", MeterName = "Meter2", MunicipalityTaxRatio = 1},
                new MeterInfo {EnxpId = 3, PmumId = 3, CityName = "Ankara", DistrictName = "Başkent", MeterName = "Meter3", MunicipalityTaxRatio = 1}


            };

            context.AddRange(meters);
            context.SaveChanges();





        }
    }
}
