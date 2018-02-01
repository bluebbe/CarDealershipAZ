using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;

namespace CarDealership.Model.ViewModel
{
    public class VechicleFormViewModel
    {
        public IEnumerable<Make> Make { get; set; }
        public IEnumerable<Mdle> Model { get; set; }
        public IEnumerable<DataModel.Typ> Types { get; set; }
        public IEnumerable<BodyStyle> BodyStyle { get; set; }
        public int Year { get; set; }
        public IEnumerable<Transmission> Transmission { get; set; }
        public IEnumerable<Color> Color { get; set; }
        public IEnumerable<Interior> Interior { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalesPrice { get; set; }
        public string Description { get; set; }
      
    }
}
