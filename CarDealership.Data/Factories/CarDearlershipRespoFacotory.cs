using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.Interfaces;
using CarDealership.Data.MockRepository;
using CarDealership.Data.EF;

namespace CarDealership.Data.Factories
{
    public static class CarDearlershipRespoFacotory
    {
        public static ICarDealershipRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new CarListingsMockRepository();
                case "PROD":
                    return new EFProdRepo();
                default:
                    throw new Exception("Could not find valid Repository configuration value");
            }
        }
    }
}
