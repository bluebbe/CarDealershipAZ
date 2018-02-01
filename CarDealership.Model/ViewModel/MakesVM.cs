using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.DataModel;

namespace CarDealership.Model.ViewModel
{
    public class MakesVM 
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime Created { get; set; }
        public int AdminId { get; set; }
        public string User { get; set; }
    }
}
