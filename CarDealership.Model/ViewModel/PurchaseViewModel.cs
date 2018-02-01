using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;
namespace CarDealership.Model.ViewModel
{
    public class PurchaseViewModel
    {
        public VechicleViewModel PurchasingVechicle { get; set; }
        public IEnumerable<PurchaseType> PurchaseType { get; set; }
        
    }
}
