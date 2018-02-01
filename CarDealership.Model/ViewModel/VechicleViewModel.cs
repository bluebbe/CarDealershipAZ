using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarDealership.Model.ViewModel
{
    public class VechicleViewModel
    {


        public int InventoryId { get; set; }
        public string Make{ get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string BodyStyle { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalesPrice { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase File { get; set; }
        public bool FeatureVehicle { get; set; }
        public string StillAvailable { get; set; }
        public int? SalesId { get; set; }
        public decimal? PurchasedPrice { get; set; }
        public DateTime? PurhasedDate { get; set; }
    }
}
