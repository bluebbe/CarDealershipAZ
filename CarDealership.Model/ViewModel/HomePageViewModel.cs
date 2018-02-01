using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;

namespace CarDealership.Model.ViewModel
{
    public class HomePageViewModel
    {
        public List<SpecialAd> Specials { get; set; }
        public List<VechicleViewModel> Featured { get; set; }
    }
}
